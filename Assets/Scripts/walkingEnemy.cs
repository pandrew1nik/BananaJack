using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingEnemy : MonoBehaviour
{
    public float speed;
    public float direction;

    void Update ()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(direction, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(direction, 0) * speed;
        if (hit.distance < 3.0F)
        {
            Flip();
        }
    }

    void Flip ()
    {
        if (direction > 0)
        {
            direction = -1F;
        }
        else
        {
            direction = 1F;
        }
    }
}