using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D body;

    private Animator animation;

    private BoxCollider2D boxCollider;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private LayerMask wallLayer;

    private float wallJumpCooldown;

    private void Awake()
    {
        // Grab reference for body and animation
        body = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity =
            new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        // flip direction when moving
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // set animation params
        animation.SetBool("Run", horizontalInput != 0);
        animation.SetBool("Grounded", isGrounded());

        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Jump();
        }

        if (wallJumpCooldown < 0.2f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }

            body.velocity =
                new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 3;

            if (Input.GetKey(KeyCode.Space) && isGrounded())
            {
                Jump();
            }
        }
        else
            wallJumpCooldown += Time.deltaTime;
    }

    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
            animation.SetTrigger("Jump");
        }
        // else if (onWall() && !isGrounded())
        // {
        // }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private bool isGrounded()
    {
        // check if player is standing on the ground
        RaycastHit2D raycastHit =
            Physics2D
                .BoxCast(boxCollider.bounds.center,
                boxCollider.bounds.size,
                0,
                Vector2.down,
                0.1f,
                groundLayer);

        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        // check if player is standing on the ground
        RaycastHit2D raycastHit =
            Physics2D
                .BoxCast(boxCollider.bounds.center,
                boxCollider.bounds.size,
                0,
                new Vector2(transform.localScale.x, 0),
                0.1f,
                wallLayer);

        return raycastHit.collider != null;
    }
}
