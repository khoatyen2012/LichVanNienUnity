using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdController : MonoBehaviour {


    #region Singleton
    private static AdController _instance;

    public static AdController instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<AdController>();
            return _instance;
        }
    }
    #endregion

    BannerView bannerView;
    AdRequest request;
    InterstitialAd interstitial;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadAdsInterstitial()
    {
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(Config.adsInID);
        // Create an empty ad request.
        AdRequest requestIN = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("365BCE5DDF729BFD1E6E40D79CE8F42B").Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(requestIN);
    }

    public void ShowAdsInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public void HideAdsInterstitial()
    {
        interstitial.Destroy();
    }

    public void LoadAdsBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(
            Config.adsID, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.



        request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("54829CBF8D1115A66940C3B0C88A9B7E").Build();
        // Load the banner with the request.

        //id0ae30a9eb3539410624b3cd2b086379e

        // Debug.Log("device id" + SystemInfo.deviceUniqueIdentifier);
    }

    public void ShowAdsBanner()
    {
        bannerView.LoadAd(request);
        bannerView.Show();
    }

    public void HideAdsBanner()
    {
        bannerView.Hide();
    }
}
