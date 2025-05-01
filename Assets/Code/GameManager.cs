using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // <== สำคัญ!

    public int score = 0;
    public TextMeshProUGUI scoreText;

    public float gameTime = 60f;
    public TextMeshProUGUI timerText;

    private bool gameEnded = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject); // ป้องกันซ้ำถ้าเปลี่ยน scene
    }

    void Start()
    {
        UpdateScoreText();
    }

    void Update()
    {
        if (gameEnded) return;

        gameTime -= Time.deltaTime;
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
}
