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
        moveInput = Input.GetAxisRaw("Horizontal"); //ให้ขยับซ้ายขาว
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, 0f); // ขยับแค่แกนX
    }
}
