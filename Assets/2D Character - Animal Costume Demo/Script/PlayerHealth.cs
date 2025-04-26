using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // สำหรับใช้กับ TextMeshPro

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public TextMeshProUGUI hpText; // ลิงก์กับ UI Text

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHPText(); // อัปเดตครั้งแรก
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            currentHealth--;
            Destroy(collision.gameObject);
            UpdateHPText();

            Debug.Log("โดนกระแทก! เหลือ HP: " + currentHealth);

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
