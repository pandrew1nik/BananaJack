using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Character : MonoBehaviour
{
    [SerializeField] public static int lives = 5;
    [SerializeField] private float speed = 3.0F;
    [SerializeField] private float jumpForce = 15.0F;
    /*[SerializeField]*/ public /*static*/ int Score = 0;
    [SerializeField] private static int Parts = 0;
    [SerializeField] public int Portal = 0;

    public bool FacingRight = true;

    public static int numOflives = 5;

    private float movement = 0f;

    int collectlives;

    public Image[] hearts;
    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;

    public GameObject currentRespawn;

    AudioSource audio;
    public AudioClip coinsound;

    public Text text;

    public static void Save()
    {
        PlayerPrefs.SetInt("exampleIntSave", lives);
    }

    public void CollectSavedValues()
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

    public void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        text = GetComponent<Text>();
        audio = GetComponent<AudioSource>();
    }

    public void Update()
    {
        Livesbar();
        Movement();
        if (numOflives <= 0)
        {
            lives = 5;
            numOflives = 5;
            Score = 0;
            Parts = 0;
            Portal = 0;
            //audio.PlayOneShot(deathsound);
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("enemy"))
        {
            rigidbody.AddForce(transform.up * 1/2* jumpForce, ForceMode2D.Impulse);
            lives--;
            numOflives--;
        }
        if (col.gameObject.CompareTag("lava"))
        {
            lives--;
            numOflives--;

        }
        if (col.gameObject.CompareTag("live"))
        {
            lives++;
            numOflives++;
            Portal++;
        }
        if (col.gameObject.CompareTag("bullet"))
        {
            lives--;
            numOflives--;

        }
        if (numOflives <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
            lives = 5;
            numOflives = 5;
        }

        //if (col.gameObject.CompareTag("score"))
        //{
        //    Score++;
        //}

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
            numOflives = 5;
        }
       
    }

    //private void OnGUI()
    //{
    //    //GUI.Box(new Rect(0, 0, 100, 30), "lives" + lives);
    //    //GUI.Box(new Rect(0, 30, 100, 30), "Score" + Score);
    //    GUI.Box(new Rect(0, 60, 100, 30), "Parts of Riick" + Parts);
    //    GUI.Box(new Rect(0, 90, 100, 30), "Portal gun" + Portal);
    //}

    public void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.1F;
    }

    public void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    public void Movement()
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
        if (movement > 0 && !FacingRight)
            Flip();
        else if (movement < 0 && FacingRight)
            Flip();
    }
    public void Livesbar()
    {
        if (lives >= 5)
        {
            lives = 5;
            numOflives = 5;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numOflives)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    //public void Scorecount()
    //{
    //    //Score++;
    //    text.text = " " + Score;
    //}

    public void Flip()
    {
        FacingRight = !FacingRight;
        //Vector3 Rotation = transform.rotation;
        //Vector3 Scale = transform.localScale;
        transform.Rotate(0f, 180f, 0f);
        //transform.localScale = Scale;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            currentRespawn = collision.gameObject;
            PlayerPrefs.SetFloat("xPos", transform.position.x);
            PlayerPrefs.SetFloat("yPos", transform.position.y);
            Debug.Log(collision.gameObject.name);
        }
    }
}

