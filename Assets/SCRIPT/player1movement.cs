using UnityEngine;
using UnityEngine.InputSystem;

public class player1movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
        private bool isGrounded = false;
    private float move;
    public BoxCollider2D otherPlayerCollider;
    private BoxCollider2D myCollider;
    private int jumpCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //walk
        if (Keyboard.current.aKey.isPressed)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            move = -1f;
        }

        else if (Keyboard.current.dKey.isPressed)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            move = 1f;
        }
        else
        {
            move = 0f;
        }
        //jump
        if((isGrounded || IsStandingOnOther())
            && rb.linearVelocity.y <=0.05f)
        {
            jumpCount = 0;
        }
        if (Keyboard.current.wKey.wasPressedThisFrame && jumpCount < 2 && !IsOtherOnMyHead())
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x, jumpForce
            );

            jumpCount++;
            isGrounded = false;
        }

    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Am I standing on the other player?
    bool IsStandingOnOther()
    {
        if (otherPlayerCollider == null) return false;
        if (!myCollider.IsTouching(otherPlayerCollider))
            return false;

        Bounds me = myCollider.bounds;
        Bounds other = otherPlayerCollider.bounds;

        float overlap = Mathf.Min(me.max.x, other.max.x)
                      - Mathf.Max(me.min.x, other.min.x);

        return overlap > 0.05f
            && Mathf.Abs(me.min.y - other.max.y) < 0.15f;
    }

    // Is the other player standing on my head?
    bool IsOtherOnMyHead()
    {
        if (otherPlayerCollider == null) return false;
        if (!myCollider.IsTouching(otherPlayerCollider))
            return false;

        Bounds me = myCollider.bounds;
        Bounds other = otherPlayerCollider.bounds;

        float overlap = Mathf.Min(me.max.x, other.max.x)
                      - Mathf.Max(me.min.x, other.min.x);

        return overlap > 0.05f
            && Mathf.Abs(other.min.y - me.max.y) < 0.15f;
    }

}
