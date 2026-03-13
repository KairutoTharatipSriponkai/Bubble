using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour ,IUnityAdsLoadListener ,IUnityAdsShowListener
{
    [SerializeField] private string androinAdUnitId;
    [SerializeField] private string iosAdUnitId;

    private string adUnitId;

    private void Awake()
    {
#if UNITY_IOS
    adUnitId = iosAdUnitId;
#elif UNITY_ANDROID
        adUnitId = androinAdUnitId;
#endif

    }

    public void LoadInterstitalAd() {
        Advertisement.Load(adUnitId, this);
    }

    public void ShowInterstitialAd() {
        Advertisement.Show(adUnitId, this);
        LoadInterstitalAd();
    }

    #region CallBack---
    public void OnUnityAdsAdLoaded(string placementId)
    {
          //  Debug.Log("Interstitial Ad Loaded...");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
      
    }
    //=---------------------------------------
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    { 
    }

    public void OnUnityAdsShowStart(string placementId)
    {
       
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        //Debug.Log("Interstitial Ad Completed");
    }
    #endregion
}
