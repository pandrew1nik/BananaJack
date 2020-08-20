using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour
{
    public float playerSpeed;
    public float jumpPower;
    public int directionInput;
    public bool FacingRight = true;
    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;
    public AudioClip jumpsound;
    AudioSource audio;

    public AudioClip coinsound;
    public AudioClip damagesound;

    private float movement = 0f;
    public bool _jumpButton = false;

    public void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();

    }


    public void Update()
    {
        if ((directionInput < 0) && (FacingRight))
        {
            Flip();
        }

        if ((directionInput > 0) && (!FacingRight))
        {
            Flip();
        }
        movement = Input.GetAxis("Horizontal");
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

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
        if (Input.GetButton("Jump") && isTouchingGround)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpPower);
            //audio.PlayOneShot(jumpsound);
        }
    }

    public void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(playerSpeed * directionInput, rigidbody.velocity.y);
    }

    public void Move(int InputAxis)
    {
        directionInput = InputAxis;
    }

    public void Jump()
    {
        if (/*Input.GetButtonDown("Jump") && */isTouchingGround)
        {
            rigidbody.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            audio.PlayOneShot(jumpsound);
        }
        _jumpButton = true;
    }

    public void JumpOff()
    {
        _jumpButton = false;
    }

    public void Flip()
    {

        FacingRight = !FacingRight;
        //Vector3 Rotation = transform.rotation;
        //Vector3 Scale = transform.localScale;
        transform.Rotate(0f, 180f, 0f);
        //transform.localScale = Scale;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("score"))
            audio.PlayOneShot(coinsound);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
            audio.PlayOneShot(damagesound);
    }
}