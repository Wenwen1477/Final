using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        if (GameManager.instance != null && scoreText != null)
        {
            int finalScore = GameManager.instance.score;
            scoreText.text = "Your Score: " + finalScore.ToString();
        }
        else
        {
            Debug.LogWarning("GameManagerScoreText ยังไม่ตั้ง");
        }
    }
}
