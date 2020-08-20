using System;
using UnityEngine;
using GoogleMobileAds.Api;


public class dieScript : MonoBehaviour
{
	public GameObject player;
	public GameObject respawn;
    //public GameObject RespawnPanel;
    public static bool GameIsPaused = false;


    public void Start()
    {
        this.RequestRewardedAd();
    }

    public void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.tag == "Player")
        {
            //RespawnPanel.SetActive(true);
            //Time.timeScale = 0F;
            //GameIsPaused = true;
            //if (this.rewardedAd.IsLoaded())
            //{
            //    this.rewardedAd.Show();
            //}
            player.transform.position = respawn.transform.position;
        }


        /*if (col.gameObject.name == "Enemy")
			Application.LoadLevel(Application.loadedLevel);
		if (col.gameObject.name == "walkingEnemy")
			Application.LoadLevel(Application.loadedLevel);*/
    }
    private RewardedAd rewardedAd;


    //public void OnClick()
    //{
    //    if (this.rewardedAd.IsLoaded())
    //    {
    //    this.rewardedAd.Show();
    //}
    //}

    public void RequestRewardedAd()
    {
        string adUnitId;
#if UNITY_ANDROID
                adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
                adUnitId = "ca-app-pub-3940256099942544/1712485313";
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
        player.transform.position = respawn.transform.position;
        //RespawnPanel.SetActive(false);
        //Time.timeScale = 1F;
        //GameIsPaused = false;

    }
}
