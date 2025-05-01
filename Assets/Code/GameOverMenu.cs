using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadScene("Game1"); // เปลี่ยนเป็นชื่อฉากหลักของนาย
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); // เฉพาะตอนเล่นใน Editor จะเห็น log
    }
}
