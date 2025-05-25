using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimentação")]
    public float moveSpeed = 5f;

    [Header("Pulo")]
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public Vector2 groundCheckSize = new Vector2(1f, 0.1f);
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimento horizontal
        moveInput = Input.GetAxisRaw("Horizontal");

        // Verifica se está no chão usando OverlapBox
        isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, whatIsGround);

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // Movimento horizontal aplicado na física
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
    }
}
