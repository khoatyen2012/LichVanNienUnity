using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class MainGame : MonoBehaviour {

    public tk2dUIItem btnContinute;
    public tk2dUIItem btnDiemCao;
	public tk2dUIItem btnLichVanNien;






	IEnumerator WaitTimeLoadScene(float time)
	{
		//do something...............
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene("LichVanNien");
	}
	


	public void btnLichVanNien_OnClick()
	{
		try
		{
		StartCoroutine (WaitTimeLoadScene (0.1f));
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
        AdController.instance.HideAdsBanner();
        PopupController.instance.ShowSHA();
        SoundController.Instance.Stop();
        SoundController.Instance.PlayChungTa();
        PopupController.instance.HideMainGame();
        StartCoroutine(WaitTimeSHA(4f));
		}
		catch (System.Exception)
		{

			throw;
		}

    
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
		try
		{
		PopupController.instance.HideMainGame ();
		PopupController.instance.ShowMaxGame ();
		}
		catch (System.Exception)
		{

			throw;
		}
    }

	// Use this for initialization
	void Start () {
        btnDiemCao.OnClick += btnDiemCao_OnClick;
        btnContinute.OnClick += btnContinute_OnClick;
		btnLichVanNien.OnClick += btnLichVanNien_OnClick;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
