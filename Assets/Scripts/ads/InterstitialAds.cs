using System;
using UnityEngine;
using GoogleMobileAds.Api;
using System.Collections;

public class InterstitialAds : MonoBehaviour
{
    public InterstitialAd interstitial;

    public void InitInerstitialAd()
    {
        Debug.Log("[IntAd] Initing ad engine...");
        MobileAds.Initialize(initStatus => { });
        Debug.Log("[IntAd] Initing ad request...");
        StartCoroutine(RequestInterstitial());
    }

    private IEnumerator RequestInterstitial()
    {
#if UNITY_ANDROID
                    string adUnitId = "ca-app-pub-2618512662549592/2570389720";
//#elif UNITY_IPHONE
//                  string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        yield return new WaitForSeconds(1f);
        Debug.Log("[IntAd] Requesting ad...");
        this.interstitial.LoadAd(request);
        yield return new WaitForSeconds(3f);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    public void ShowAd()
    {
        if (!interstitial.IsLoaded())
        {
            Debug.Log("[IntAd] Waiting for ad...");
            InitInerstitialAd();
        }

        if (interstitial.IsLoaded())
        {
            Debug.Log("[IntAd] Showing ad...");
            interstitial.Show();
        }
    }
}
