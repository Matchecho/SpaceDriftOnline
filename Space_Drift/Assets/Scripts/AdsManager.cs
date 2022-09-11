using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public static AdsManager Instance;

    public string adID = "4641711";

    Action RewardCompleted;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            Advertisement.Initialize(adID);
            Advertisement.AddListener(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    public void PlayInterstitial()
    {
        //Play fullscreen skipable ad
        if(Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
        else
        {
            Debug.Log("interstitial not ready!");
        }
    }

    public void PlayRewarded(Action action)
    {
        //Play reward ad
        RewardCompleted = action;
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else
        {
            Debug.Log("Rewarded not ready!");
        }
    }

    public void PlayBanner()
    {
        //Play banner ad
        if (Advertisement.IsReady("Banner_Android"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("Banner_Android");
        }
        else
        {
            Debug.Log("Banner not ready!");
            StartCoroutine(ReloadBanner());
        }
    }

    IEnumerator ReloadBanner()
    {
        yield return new WaitForSeconds(2.0f);
        PlayBanner();
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }
    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Unity ads had an error!" + message);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        Debug.Log(placementId + "Ad finished!");
        if(placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            Debug.Log("Player Watched, Get Reward!");
            RewardCompleted.Invoke();
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log(placementId + "Ad started!");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log(placementId + "Ad ready!");
    }
}
