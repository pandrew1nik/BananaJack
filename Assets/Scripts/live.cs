﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class live : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
