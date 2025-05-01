using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public TextMeshProUGUI hpText;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHPText();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            currentHealth--;
            Destroy(collision.gameObject);
            UpdateHPText();

            StartCoroutine(FlashDamage());

            if (currentHealth <= 0)
            {
                GameManager.instance.GameOver(); // เรียก GameOver ผ่าน GameManager
            }
        }
    }

    void UpdateHPText()
    {
        if (hpText != null)
            hpText.text = "HP: " + currentHealth.ToString();
    }

    System.Collections.IEnumerator FlashDamage()
    {
        for (int i = 0; i < 3; i++)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.3f); // จาง
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f); // กลับมา
            yield return new WaitForSeconds(0.1f);
        }
    }
}
