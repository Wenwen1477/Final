using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal"); // ซ้าย/ขวา จากปุ่ม A-D หรือ ? ?
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, 0f); // ขยับแค่แกน X เท่านั้น
    }
}
