using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private int lives = 3;

    void Update()
    {
        if (lives == 0)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("cBullet"))
        {
            lives--;
        }

    }
}
