using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalLadder : MonoBehaviour
{
    [SerializeField]
    float speed = 5;
    void OnTriggerStay2D(Collider2D other)
    {
       other.GetComponent<Rigidbody2D>().gravityScale = 0;

        if (other.gameObject.CompareTag("Player"))
        {

            if (other.GetComponent<CharController>()._jumpButton == true)
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
            }
            //else if (Input.GetKey(KeyCode.DownArrow))
            //{
            //    other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            //}
            else
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
            }
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
