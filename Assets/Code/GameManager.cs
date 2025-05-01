using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    public float gameTime = 60f;
    public TextMeshProUGUI timerText;

    private bool gameEnded = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �Ӥѭ!
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
    }

    void Update()
    {
        if (gameEnded) return;

        gameTime -= Time.deltaTime;

        if (timerText != null)
            timerText.text = "Time: " + Mathf.CeilToInt(gameTime).ToString();

        if (gameTime <= 0)
        {
            WinGame();
        }
    }

    public void AddScore(int amount)
    {
        if (gameEnded) return;

        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }

    public void WinGame()
    {
        gameEnded = true;
        SceneManager.LoadScene("Win");
    }

    public void GameOver()
    {
        gameEnded = true;
        SceneManager.LoadScene("GameOver");
    }

    public void ResetGame()
    {
        score = 0;
        gameTime = 60f;
        gameEnded = false;
    }
}
