using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class MainGame : MonoBehaviour {

    public tk2dUIItem btnContinute;
    public tk2dUIItem btnDiemCao;
	public tk2dUIItem btnLichVanNien;

	BannerView bannerView;
	AdRequest request;

	public void setData()
	{
		LoadAdsBanner ();
		ShowAdsBanner ();
	}



	private void LoadAdsBanner()
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


	public void btnLichVanNien_OnClick()
	{
		HideAdsBanner ();
		SceneManager.LoadScene("LichVanNien");
	}

    void btnContinute_OnClick()
    {
		HideAdsBanner ();
        PopupController.instance.ShowSHA();
        SoundController.Instance.Stop();
        SoundController.Instance.PlayChungTa();
        PopupController.instance.HideMainGame();
        StartCoroutine(WaitTimeSHA(4f));

    
    }

    IEnumerator WaitTimeSHA(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        PopupController.instance.HideSHA();
        GameController.instance.suget();
        GameController.instance.currentState = GameController.State.Question;


    }

    void btnDiemCao_OnClick()
    {
		PopupController.instance.HideMainGame ();
		PopupController.instance.ShowMaxGame ();
    }

	// Use this for initialization
	void Start () {
        btnDiemCao.OnClick += btnDiemCao_OnClick;
        btnContinute.OnClick += btnContinute_OnClick;
		btnLichVanNien.OnClick += btnLichVanNien_OnClick;
		setData ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
