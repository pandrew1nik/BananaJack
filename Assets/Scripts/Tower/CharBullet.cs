using UnityEngine;
using System.Collections;

public class CharBullet : MonoBehaviour
{
    public float force = 25F;

    Rigidbody2D rb;
    public bool isRight = true;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isRight = GameObject.Find("Character").gameObject.GetComponent<CharController>().FacingRight;
    }

    public void Update()
    {


        if (isRight == true)
        {
            rb.velocity = new Vector2(force, rb.velocity.y);
        }
        else if (isRight == false)
        {
            rb.velocity = new Vector2(-force, rb.velocity.y);
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ground") || col.gameObject.CompareTag("boss") || col.gameObject.CompareTag("enemy") || col.gameObject.CompareTag("finish") || col.gameObject.CompareTag("Untagged"))
        {
            Destroy(this.gameObject);
        }
    }
}