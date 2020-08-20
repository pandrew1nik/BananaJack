using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game9 : MonoBehaviour
{
    public Character character;
    public GameObject finish;
    private InterstitialAds InterstitialAds;


    public void Start()
    {
        InterstitialAds = FindObjectOfType<InterstitialAds>();
        InterstitialAds.IninInerstitialAd();
    }

    public void Update()
    {
        finish.SetActive(character.Portal == 1);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Application.LoadLevel("Game9");
            InterstitialAds.GameOver();
        }
    }
}
