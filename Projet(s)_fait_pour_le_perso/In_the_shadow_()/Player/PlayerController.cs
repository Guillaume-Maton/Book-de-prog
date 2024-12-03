using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public Transform feetPosition;
    public float checkRadius;
    public bool isGrounded;
    public LayerMask whatIsLayer;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (moveInput * moveSpeed, rb.velocity.y);

        Sauter();

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        float characterJump = Mathf.Abs(rb.velocity.y);
        animator.SetFloat("Speed", characterVelocity);
        animator.SetFloat("Jump", characterJump);
    }

    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    void Sauter()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsLayer);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(feetPosition.position, checkRadius);
    }
}