using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game1 : MonoBehaviour
{
    public Character character;
    public GameObject finish;
    //public InterstitialAds InterstitialAds;

    //public void Start()
    //{
    //    InterstitialAds = FindObjectOfType<InterstitialAds>();
    //    InterstitialAds.IninInerstitialAd();
    //}

    public void Update()
    {
        finish.SetActive(character.Portal == 1);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Time.timeScale = 1;
            Application.LoadLevel("Game1");
            //InterstitialAds.GameOver();
        }
    }
}
