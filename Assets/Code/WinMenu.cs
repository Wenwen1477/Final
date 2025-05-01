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

        SceneManager.LoadScene("Game1"); // ����¹�������ç�Ѻ�ҡ��蹨�ԧ
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("�͡�ҡ������");
    }
}
