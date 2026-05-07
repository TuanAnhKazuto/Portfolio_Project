using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    private Vector2 moveInput;

    public float moveSpeed = 5f;
    public float jumpHeight = 5f;
    public LayerMask groundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        // Raycast xuống dưới để kiểm tra va chạm với mặt đất
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2, groundLayer);
        return hit.collider != null;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        rb.linearVelocity = new(moveInput.x * moveSpeed, rb.linearVelocity.y);
    }
}
