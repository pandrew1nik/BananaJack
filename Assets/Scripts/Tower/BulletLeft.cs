﻿using UnityEngine;
using System.Collections;

public class BulletLeft : MonoBehaviour
{
    public float force = 1.5F;

    Rigidbody2D rb;


    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        rb.velocity = new Vector3(-force, rb.velocity.y);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ground") || col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
