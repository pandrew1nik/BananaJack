using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.IO;

public class addScore : MonoBehaviour
{
    AudioSource audio;
    public AudioClip coinsound;

    public void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Score.scoreValue++;
            Score.Print();
            Destroy(this.gameObject);
        }
    }
}