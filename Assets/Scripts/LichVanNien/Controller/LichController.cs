﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class LichController : MonoBehaviour {


    public enum State
    {
        NGAY,
        THANG,
        TIENICH,
		ABOUT

    }

    public State currentState;


    #region Singleton
    private static LichController _instance;

    public static LichController instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<LichController>();
            return _instance;
        }
    }
    #endregion

    public tk2dUIItem btnNgay;
    public tk2dUIItem btnThang;
    public tk2dUIItem btnTienich;
	public tk2dUIItem btnAbout;
	public tk2dUIItem btnALTP1;
	public tk2dUIItem btnALTP2;
	public tk2dUIItem btnShare;
	public tk2dUIItem btnRate;
	public tk2dUIItem btnViewAd;





    public MoveLichNgay LichNgay;
    public MoveLichThang LichThang;
    public TienIch DoiNgay;
	public About about;

	bool checkOk=false;

	void Awake()
	{
		Application.targetFrameRate = 30;
		QualitySettings.vSyncCount = -1;
	}

	void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus) {

            if (currentState == State.TIENICH || currentState == State.ABOUT)
            {
                AdController.instance.HideAdsBanner();
            }

		} else {
			if(checkOk)
			{

                //if (currentState == State.TIENICH || currentState == State.ABOUT)
                //{
                //    AdController.instance.HideAdsBanner();
                //}

            currentState = State.NGAY;
            LichNgay.Today();
            LichNgay.transform.position = new Vector3(00, 0f, LichNgay.transform.position.z);

            LichThang.transform.position = new Vector3(0f, 1000f, LichThang.transform.position.z);
            DoiNgay.transform.position = new Vector3(0f, 1000f, DoiNgay.transform.position.z);
			about.transform.position = new Vector3(0f, 1000f, about.transform.position.z);

            btnNgay.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(1, 0, (float)227 / 255, 1);
            btnThang.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(0, 0, 0, 1);
            btnTienich.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(0, 0, 0, 1);

			}
		}
	}

	public void btnALTP_OnClick()
	{
		try
		{
        AdController.instance.HideAdsBanner();
		StartCoroutine (WaitTimeLoadScene (0.1f));
		}
		catch (System.Exception)
		{

			throw;
		}
	}

	IEnumerator WaitTimeLoadScene(float time)
	{
		//do something...............
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene("InGame");
	}

	public void btnRate_OnClick()
	{
		try
		{
		ShareRate.Rate ();
		}
		catch (System.Exception)
		{

			throw;
		}
	}

	public void btnShare_OnClick()
	{
		try
		{
		ShareRate.Share ();
		}
		catch (System.Exception)
		{

			throw;
		}
	}

	public void btnViewAds_OnClick()
	{
		try
		{
        AdController.instance.HideAdsBanner();
        AdController.instance.ShowAdsInterstitial();
		}
		catch (System.Exception)
		{

			throw;
		}
	}

	public void btnAbout_OnClick()
	{
		try
		{
		currentState = State.ABOUT;
			AdController.instance.HideAdsBanner();
		about.transform.position = new Vector3(0f, 0f, about.transform.position.z);

		LichThang.transform.position = new Vector3(0f, 1000f, LichThang.transform.position.z);
		LichNgay.transform.position = new Vector3(00, 1000f, LichNgay.transform.position.z);
		DoiNgay.transform.position = new Vector3(0f, 1000f, DoiNgay.transform.position.z);

        AdController.instance.LoadAdsInterstitial();
		}
		catch (System.Exception)
		{

			throw;
		}

	}

    public void btnNgay_OnClick()
    {
		try
		{
        if (currentState == State.TIENICH || currentState == State.ABOUT)
        {
            AdController.instance.HideAdsBanner();
        }
        SoundCTL.Instance.PlayChamNuoc();

        currentState = State.NGAY;
        LichNgay.Today();
        LichNgay.transform.position = new Vector3(00, 0f, LichNgay.transform.position.z);

        LichThang.transform.position = new Vector3(0f, 1000f, LichThang.transform.position.z);
        DoiNgay.transform.position = new Vector3(0f, 1000f, DoiNgay.transform.position.z);
		about.transform.position = new Vector3(0f, 1000f, about.transform.position.z);

        btnNgay.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(1, 0, (float)227 / 255, 1);
        btnThang.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(0, 0, 0, 1);
        btnTienich.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(0, 0, 0, 1);
		}
		catch (System.Exception)
		{

			throw;
		}
    }

    public void btnThang_OnClick()
    {
		try
		{
        if (currentState == State.TIENICH || currentState == State.ABOUT)
        {
            AdController.instance.HideAdsBanner();
        }
        SoundCTL.Instance.PlayChamNuoc();

        currentState = State.THANG;

        LichThang.transform.position = new Vector3(0f, 0f, LichThang.transform.position.z);
		LichThang.setData ();
        LichNgay.transform.position = new Vector3(0, 1000f, LichNgay.transform.position.z);
        DoiNgay.transform.position = new Vector3(0f, 1000f, DoiNgay.transform.position.z);
		about.transform.position = new Vector3(0f, 1000f, about.transform.position.z);

        btnThang.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(1, 0, (float)227 / 255, 1);
        btnNgay.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(0, 0, 0, 1);
        btnTienich.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(0, 0, 0, 1);
		}
		catch (System.Exception)
		{

			throw;
		}
    }


    public void btnTienich_OnClick()
    {
		try
		{
        if (currentState == State.NGAY || currentState == State.THANG)
        {
            AdController.instance.LoadAdsBanner();
            AdController.instance.ShowAdsBanner();
        }
        SoundCTL.Instance.PlayChamNuoc();

        currentState = State.TIENICH;
        DoiNgay.ToDay();
        DoiNgay.transform.position = new Vector3(0f, 0f, DoiNgay.transform.position.z);

        LichThang.transform.position = new Vector3(0f, 1000f, LichThang.transform.position.z);
        LichNgay.transform.position = new Vector3(00, 1000f, LichNgay.transform.position.z);
		about.transform.position = new Vector3(0f, 1000f, about.transform.position.z);


        btnTienich.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(1, 0, (float)227 / 255, 1);
        btnThang.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(0, 0, 0, 1);
        btnNgay.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(0, 0, 0, 1);
		}
		catch (System.Exception)
		{

			throw;
		}
        
    }




	// Use this for initialization
	void Start () {
		try
		{
        btnNgay.OnClick += btnNgay_OnClick;
        btnThang.OnClick += btnThang_OnClick;
        btnTienich.OnClick += btnTienich_OnClick;
		btnAbout.OnClick += btnAbout_OnClick;

		btnALTP1.OnClick += btnALTP_OnClick;
		btnALTP2.OnClick += btnALTP_OnClick;
		btnShare.OnClick += btnShare_OnClick;
		btnRate.OnClick += btnRate_OnClick;
		btnViewAd.OnClick += btnViewAds_OnClick;

	

		if (DateTime.Now.Month < 11 && (DateTime.Now.Year == 2018)) {
			btnAbout.gameObject.SetActive (false);
			btnALTP2.gameObject.SetActive (false);
		} else {

			btnAbout.gameObject.SetActive (true);
			btnALTP2.gameObject.SetActive (true);
		}



		checkOk = true;
		}
		catch (System.Exception)
		{

			throw;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
