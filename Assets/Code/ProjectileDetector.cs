using UnityEngine;

public class ProjectileDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeadZone"))
        {
            FindObjectOfType<GameManager>().AddScore(1);
            Destroy(gameObject); // ทำลายวัตถุที่หล่นไปล่าง
        }
    }
}
