using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game1"); // ����¹�������ç�Ѻ�ҡ����ԧ
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("�Դ������");
    }
}
