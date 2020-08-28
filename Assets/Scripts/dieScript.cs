using System;
using UnityEngine;
using GoogleMobileAds.Api;


public class dieScript : MonoBehaviour
{
	public GameObject player;
    public GameObject AD;
    //public GameObject RespawnPanel;
    public static bool GameIsPaused = false;


    public void Start()
    {
        this.RequestRewardedAd();
    }

  


    private RewardedAd rewardedAd;
    public GameObject controls;
    public GameObject lives;

    public void Death()
    {
        AD.SetActive(true);
        controls.SetActive(false);
        lives.SetActive(false);
        player.SetActive(false);
        Time.timeScale = 0f;

    }

    public void OnClick()
    {
        if (this.rewardedAd.IsLoaded())
        {

            Debug.Log("IF");
            Time.timeScale = 1f;
            AD.SetActive(false);
            controls.SetActive(true);
            lives.SetActive(true);
            player.SetActive(true);
            this.rewardedAd.Show();
            player.GetComponent<Character>().SetToCheckpointPosition();
        }
        else
        {
            Debug.Log("ELSE");
            controls.SetActive(true);
            lives.SetActive(true);
            player.SetActive(true);
            AD.SetActive(true);
            this.rewardedAd.Show();
            AD.SetActive(false);
            player.GetComponent<Character>().SetToCheckpointPosition();
            Time.timeScale = 1f;
        }
    }

    public void RequestRewardedAd()
    {
        string adUnitId;
#if UNITY_ANDROID
                adUnitId = "ca-app-pub-2618512662549592/7439573025";
//#elif UNITY_IPHONE
//                adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
        adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print(
           "HandleRewardedAdClosed event received");
    }
}
