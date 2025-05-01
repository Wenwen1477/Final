using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public TextMeshProUGUI hpText;

    public Sprite normalSprite;
    public Sprite hurtSprite;
    public float hurtDuration = 0.3f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHPText();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalSprite;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            currentHealth--;
            Destroy(collision.gameObject);
            UpdateHPText();

            StartCoroutine(FlashHurtSprite());

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

    IEnumerator FlashHurtSprite()
    {
        spriteRenderer.sprite = hurtSprite;
        yield return new WaitForSeconds(hurtDuration);
        spriteRenderer.sprite = normalSprite;
    }
}
