using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game1"); // เปลี่ยนชื่อให้ตรงกับฉากเกมจริง
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("ปิดเกมแล้ว");
    }
}
