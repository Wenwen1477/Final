using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public TextMeshProUGUI hpText;

    public Sprite normalSprite;  // �ٻ����
    public Sprite hurtSprite;    // �ٻ�͹ⴹ��
    public float hurtEffectTime = 0.3f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHPText();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalSprite; // ���������˹�һ���
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
                GameManager.instance.GameOver(); // �˹�� GameOver
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
            spriteRenderer.color = new Color(1, 1, 1, 0.3f); // �ҧŧ
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = new Color(1, 1, 1, 1f);   // ��Ѻ��
            yield return new WaitForSeconds(0.1f);
        }

        spriteRenderer.sprite = normalSprite; // ��Ѻ˹�����
    }
}
