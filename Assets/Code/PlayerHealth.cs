using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public TextMeshProUGUI hpText;

    public Sprite normalSprite;  // รูปปกติ
    public Sprite hurtSprite;    // รูปตอนโดนตี
    public float hurtEffectTime = 0.3f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHPText();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalSprite; // เริ่มต้นใช้หน้าปกติ
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            currentHealth--;
            Destroy(collision.gameObject);
            UpdateHPText();

            StartCoroutine(FlashHurtEffect());

            if (currentHealth <= 0)
            {
                GameManager.instance.GameOver(); // ไปหน้า GameOver
            }
        }
    }

    void UpdateHPText()
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + currentHealth.ToString();
        }
    }

    IEnumerator FlashHurtEffect()
    {
        spriteRenderer.sprite = hurtSprite;

        for (int i = 0; i < 3; i++)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.3f); // จางลง
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = new Color(1, 1, 1, 1f);   // กลับมา
            yield return new WaitForSeconds(0.1f);
        }

        spriteRenderer.sprite = normalSprite; // กลับหน้าเดิม
    }
}
