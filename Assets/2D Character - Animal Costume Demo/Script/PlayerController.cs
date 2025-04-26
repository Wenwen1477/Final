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
        moveInput = Input.GetAxisRaw("Horizontal"); // ����/��� �ҡ���� A-D ���� ? ?
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, 0f); // ��Ѻ��᡹ X ��ҹ��
    }
}
