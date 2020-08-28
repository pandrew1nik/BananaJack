using System;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;


public class GoogleMobileAdsDemoScript : MonoBehaviour
{
    //    private BannerView bannerView;

    //    public void Start()
    //    {
    //        this.RequestBanner();
    //    }

    //    private void RequestBanner()
    //    {

    //#if UNITY_ANDROID
    //            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
    //#elif UNITY_IPHONE
    //            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
    //#else
    //        string adUnitId = "unexpected_platform";
    //#endif

    //        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

    //        // Called when an ad request has successfully loaded.
    //        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
    //        // Called when an ad request failed to load.
    //        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
    //        // Called when an ad is clicked.
    //        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
    //        // Called when the user returned from the app after an ad click.
    //        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
    //        // Called when the ad click caused the user to leave the application.
    //        this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;

    //        // Create an empty ad request.
    //        AdRequest request = new AdRequest.Builder().Build();

    //        // Load the banner with the request.
    //        this.bannerView.LoadAd(request);
    //    }

    //    public void HandleOnAdLoaded(object sender, EventArgs args)
    //    {
    //        MonoBehaviour.print("HandleAdLoaded event received");
    //    }

    //    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    //    {
    //        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
    //                            + args.Message);
    //    }

    //    public void HandleOnAdOpened(object sender, EventArgs args)
    //    {
    //        MonoBehaviour.print("HandleAdOpened event received");
    //    }

    //    public void HandleOnAdClosed(object sender, EventArgs args)
    //    {
    //        MonoBehaviour.print("HandleAdClosed event received");
    //    }

    //    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    //    {
    //        MonoBehaviour.print("HandleAdLeavingApplication event received");
    //    }

    //    private InterstitialAd interstitial;

    //    public void Start()
    //    {
    //        MobileAds.Initialize(initStatus => { });
    //        this.RequestInterstitial();
    //    }

    //    public void OnClick()
    //    {
    //        if (interstitial.IsLoaded()) interstitial.Show();
    //    }

    //    private void RequestInterstitial()
    //    {
    //#if UNITY_ANDROID
    //                string adUnitId = "ca-app-pub-3940256099942544/1033173712";
    //#elif UNITY_IPHONE
    //                string adUnitId = "ca-app-pub-3940256099942544/4411468910";
    //#else
    //        string adUnitId = "unexpected_platform";
    //#endif

    //        // Initialize an InterstitialAd.
    //        this.interstitial = new InterstitialAd(adUnitId);

    //        // Called when an ad request has successfully loaded.
    //        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
    //        // Called when an ad request failed to load.
    //        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
    //        // Called when an ad is shown.
    //        this.interstitial.OnAdOpening += HandleOnAdOpened;
    //        // Called when the ad is closed.
    //        this.interstitial.OnAdClosed += HandleOnAdClosed;
    //        // Called when the ad click caused the user to leave the application.
    //        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

    //        // Create an empty ad request.
    //        AdRequest request = new AdRequest.Builder().Build();
    //        // Load the interstitial with the request.
    //        this.interstitial.LoadAd(request);
    //    }

    //    public void HandleOnAdLoaded(object sender, EventArgs args)
    //    {
    //        MonoBehaviour.print("HandleAdLoaded event received");
    //    }

    //    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    //    {
    //        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
    //                            + args.Message);
    //    }

    //    public void HandleOnAdOpened(object sender, EventArgs args)
    //    {
    //        MonoBehaviour.print("HandleAdOpened event received");
    //    }

    //    public void HandleOnAdClosed(object sender, EventArgs args)
    //    {
    //        MonoBehaviour.print("HandleAdClosed event received");
    //    }

    //    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    //    {
    //        MonoBehaviour.print("HandleAdLeavingApplication event received");
    //    }

    private RewardedAd rewardedAd;
    public GameObject controls;
    public GameObject lives;
    public GameObject player;

    public void Start()
    {
        this.RequestRewardedAd();
    }

    public void OnClick()
    {
        if (this.rewardedAd.IsLoaded())
        {
            controls.SetActive(false);
            lives.SetActive(false);
            player.SetActive(false);
            this.rewardedAd.Show();
            Time.timeScale = 1f;
        }
        else
        {
            controls.SetActive(true);
            lives.SetActive(true);
            player.SetActive(true);
            this.rewardedAd.Show();
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
        transform.position = GetComponent<Character>().currentRespawn;
    }



}