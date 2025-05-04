using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game1");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("ปิดเกมแล้ว");
    }

    public void GoToCredit()
    {
        SceneManager.LoadScene("Credit");
    }
}
