using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5 : MonoBehaviour
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
#pragma warning disable CS0618 // 'Application.LoadLevel(string)" является устаревшим: 'Use SceneManager.LoadScene'
            Application.LoadLevel("Game5");
#pragma warning restore CS0618 // 'Application.LoadLevel(string)" является устаревшим: 'Use SceneManager.LoadScene'
            InterstitialAds.GameOver();
        }
    }
}
