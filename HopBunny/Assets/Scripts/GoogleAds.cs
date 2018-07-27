using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleAds : MonoBehaviour {
    private BannerView bannerView;

	// Use this for initialization
	void Start () {
        string appId = "ca-app-pub-7047037253566381~7562578254";
        MobileAds.Initialize(appId);

        this.RequestBanner();
    }
	
	private void RequestBanner()
    {
        //Test Id
        //string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        
        //Release Id
        string adUnitId = "ca-app-pub-7047037253566381/5955242297";

        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }
}
