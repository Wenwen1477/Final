using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void TryAgain()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ResetGame();
        }

        SceneManager.LoadScene("Game1"); // เปลี่ยนชื่อให้ตรงกับฉากเล่นจริง
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("ออกจากเกมแล้ว");
    }
}
