using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoMenu : MonoBehaviour
{
    private InterstitialAds InterstitialAds;

    public void Start()
    {
        InterstitialAds.interstitial.Destroy();
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); // loads Menu scene
    }
}
