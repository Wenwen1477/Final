using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadScene("Game1"); // ����¹�繪��ͩҡ��ѡ�ͧ���
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); // ੾�е͹���� Editor ����� log
    }
}
