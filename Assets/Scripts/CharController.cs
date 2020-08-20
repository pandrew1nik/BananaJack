using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour
{
    public float playerSpeed;
    public float jumpPower;
    public int directionInput;
    public bool facingRight = true;
    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private float movement = 0f;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        if ((directionInput < 0) && (facingRight))
        {
            Flip();
        }

        if ((directionInput > 0) && (!facingRight))
        {
            Flip();
        }
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            rigidbody.velocity = new Vector2(movement * playerSpeed, rigidbody.velocity.y);
        }
        else if (movement < 0f)
        {
            rigidbody.velocity = new Vector2(movement * playerSpeed, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpPower);
        }
    }

    void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(playerSpeed * directionInput, rigidbody.velocity.y);
    }

    public void Move(int InputAxis)
    {

        directionInput = InputAxis;

    }

    public void Jump()
    {
        rigidbody.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}