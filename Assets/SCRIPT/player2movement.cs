using UnityEngine;
using UnityEngine.InputSystem;

public class player2movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private float move;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        move = 0f;
        if (Keyboard.current.upArrowKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
