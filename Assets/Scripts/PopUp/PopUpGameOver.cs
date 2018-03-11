using UnityEngine;
using System.Collections;


public class PopUpGameOver : MonoBehaviour {

    public tk2dUIItem btnContinute;
    public tk2dUIItem btnStop;
    public tk2dUIItem btnRate;
    public tk2dTextMesh txtLevel;
    public tk2dTextMesh txtMaxLevel;



    



    void callResetDapAn()
    {
         DapAnController.instance.resetDapAN();
       AdController.instance.HideAdsBanner();
    }

    public void setlevel(int level, int maxlevel)
    {
        txtLevel.text = "Vượt qua: Câu " + level;
        txtMaxLevel.text = "Lớn nhất: Câu " + maxlevel;
        AdController.instance.LoadAdsInterstitial();
    }

    void btnRate_onClick()
    {
        try
        {
            ShareRate.Rate();
        }
        catch (System.Exception)
        {

            throw;
        }
    }


    void btnContinute_OnClick()
    {
        try
        {
            ShareRate.Share();
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    void btnStop_OnClick()
    {
        try
        {
            if (GameController.instance.level % 3 == 0 || GameController.instance.level % 5 == 0)
            {
                AdController.instance.ShowAdsInterstitial();
            }
        SoundController.Instance.PlayTamBiet();
        callResetDapAn();
        PopupController.instance.HidePopupGameOver();
        PopupController.instance.HidePopupKhanGia();
        PopupController.instance.HidePopupNguoiThan();
        PopupController.instance.HidePopUpWin();
        PopupController.instance.ShowMainGame();
        TroGiupControlller.instance.resetHelp();
        GameController.instance.level = 1;
       
        }
        catch (System.Exception)
        {

            throw;
        }
       
    }

	// Use this for initialization
	void Start () {
        btnContinute.OnClick += btnContinute_OnClick;
        btnStop.OnClick += btnStop_OnClick;
        btnRate.OnClick += btnRate_onClick;
        AdController.instance.LoadAdsInterstitial();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
