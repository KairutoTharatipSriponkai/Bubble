using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UIElements;

public class BannerAds : MonoBehaviour
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


        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);   

    }
    private void Start()
    {
        
    }

    public void LoadBannerAd() {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = BannerLoaded,
            errorCallback = BannerLoadError
        };
        Advertisement.Banner.Load(adUnitId, options);
    }

    public void ShowBannerAd() {
        BannerOptions options = new BannerOptions { 
            showCallback = BannerShow,
            clickCallback = BannerClicked,
            hideCallback = BannerHidden
        };
        Advertisement.Banner.Show(adUnitId, options);
    }

    public void HideBannerAd() {
        Advertisement.Banner.Hide();      
    }



    #region ShowCallBacks---
    private void BannerHidden()
    {
        //Debug.Log("---Hide Banner--");
    }

    private void BannerClicked()
    {
       
    }

    private void BannerShow()
    {
        //Debug.Log("---Show Banner--");
    }
    #endregion

    #region LoadCallBacks---
    private void BannerLoadError(string message)
    {
       // Debug.Log("Error Load Banner--");
    }

    private void BannerLoaded()
    {
       // Debug.Log("Load Banner--");
    }
    #endregion
}
