using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game8 : MonoBehaviour
{
    public Character character;
    public GameObject finish;
    private InterstitialAds InterstitialAds;

    [SerializeField] private string _sceneName;
    public void Start()
    {
        InterstitialAds = FindObjectOfType<InterstitialAds>();
        InterstitialAds.IninInerstitialAd();
    }

    public void Update()
    {
        finish.SetActive(character.Portal == 1);
    }

    private void LoadNewScene()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            InterstitialAds.GameOver();
            LoadNewScene();
        }
    }
}
