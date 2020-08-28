using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxtCheck : MonoBehaviour
{
    Vector3 startPosition;

    public void Start()
    {
        startPosition = this.transform.localPosition;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Death")
        {
            Debug.Log("Revert");
            this.transform.localPosition = startPosition;
            this.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }
    }
}
