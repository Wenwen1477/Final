using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // ����Ѻ��Ѻ TextMeshPro

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public TextMeshProUGUI hpText; // �ԧ��Ѻ UI Text

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHPText(); // �ѻവ�����á
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            currentHealth--;
            Destroy(collision.gameObject);
            UpdateHPText();

            Debug.Log("ⴹ���ᷡ! ����� HP: " + currentHealth);

            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    void UpdateHPText()
    {
        hpText.text = "HP: " + currentHealth.ToString();
    }
}
