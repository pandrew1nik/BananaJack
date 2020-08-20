using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{
    [SerializeField]
    private static int lives = 5;
    [SerializeField]
    private float speed = 3.0F;
    [SerializeField]
    private float jumpForce = 15.0F;
    [SerializeField]
    private static int Score = 0;
    [SerializeField]
    private static int Parts = 0;
    [SerializeField]
    public int Portal = 0;

    private float movement = 0f;

    int collectlives;

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;


    public static void Save()
    {
        PlayerPrefs.SetInt("exampleIntSave", lives);
    }

    void CollectSavedValues()
    {
        collectlives = PlayerPrefs.GetInt("exampleIntSave");
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        Save();
        CollectSavedValues();


    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            rigidbody.velocity = new Vector2(movement * speed, rigidbody.velocity.y);
        }
        else if (movement < 0f)
        {
            rigidbody.velocity = new Vector2(movement * speed, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }
        if (lives == 0)
        {
            lives = 5;
            Score = 0;
            Parts = 0;
            Portal = 0;
        }
}

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("enemy"))
        {
            rigidbody.AddForce(transform.up * 1/2* jumpForce, ForceMode2D.Impulse);
            lives--;
        }
        if (col.gameObject.CompareTag("lava"))
        {
            lives--;
        }
        if (col.gameObject.CompareTag("live"))
        {
            lives++;
            Portal++;
        }
        if (col.gameObject.CompareTag("bullet"))
        {
            lives--;
        }
        if (lives <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (col.gameObject.CompareTag("score"))
        {
            Score++;
        }

        if (col.gameObject.CompareTag("parts"))
        {
            Parts++;
        }

        if (col.gameObject.CompareTag("lastfinish"))
        {
            lives = 5;
            Score = 0;
            Parts = 0;
            Portal = 0;
        }
       
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 30), "lives" + lives);
        GUI.Box(new Rect(0, 30, 100, 30), "Score" + Score);
        GUI.Box(new Rect(0, 60, 100, 30), "Parts of Riick" + Parts);
        GUI.Box(new Rect(0, 90, 100, 30), "Portal gun" + Portal);
    }

    public void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.2F;
    }

    public void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

}

