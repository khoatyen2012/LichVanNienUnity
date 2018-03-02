using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class MoveLichNgay : MonoBehaviour {

    public float speed;
	public Vector3 startPosition;
	public tk2dTextMesh txttest;
	DateTime today;
	Transform oHomQua;
	Transform oHomNay;
	Transform oNgayMai;

	string sText = "danhngon";
	//List<string> lst = new List<string>();
	string[] mang;



	void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus) {

		} else {
			
		}
	}

	void onClick_ToDay()
	{
		Today ();
	}
	void Today()
	{
		today = DateTime.Now;

		doSetDate (oHomNay, today);
		doSetDate (oHomQua, today.AddDays (-1));
		doSetDate (oNgayMai, today.AddDays (1));
	}

	// Use this for initialization
	void Start () {

		string ss = ReadText.readTextFile(sText);
		GetDaTa (ss);
		oHomQua = this.transform.GetChild (0);
		oHomNay = this.transform.GetChild (1);
		oNgayMai = this.transform.GetChild (2);
		oHomNay.GetChild (4).GetChild (0).GetComponent<tk2dUIItem> ().OnClick += onClick_ToDay;

		startPosition = this.transform.position;

	
		Today ();

	}

	void GetDaTa(string tmg)
	{
		 mang = tmg.Trim().Split('#');


	}

	void doSetDate(Transform pTra,DateTime pDt)
	{
		int chon = UnityEngine.Random.Range (0, 10);
		switch (chon) {
		case 0:
			pTra.GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("nenmua");
			break;
		case 1:
			pTra.GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("nentuyet");
			break;
		case 2:
			pTra.GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("nenvang");
			break;

		default:
			pTra.GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("nennang");
			break;
		}


		chon = UnityEngine.Random.Range (0, 13);
		int chonNu = UnityEngine.Random.Range (0, 13);
		switch (chon) {
		case 0:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("namdodam");
			break;
		case 1:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("namtim");
			break;
		case 2:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("namxanhduong");
			break;
		case 3:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("namve");
			break;
		case 4:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("namkysu");
			break;
		case 5:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("namlichviet");
			break;
		case 6:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("namtana");
			break;
		case 7:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("namdothuphap");
			break;
		case 8:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("namdoanhnhan");
			break;
		default:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("nambetrap");
			break;
		}

		switch (chonNu) {
		case 0:
			pTra.GetChild (0).GetChild (6).GetComponent<tk2dSprite> ().SetSprite ("nudodam");
			break;
		case 1:
			pTra.GetChild (0).GetChild (6).GetComponent<tk2dSprite> ().SetSprite ("nutim");
			break;
		case 2:
			pTra.GetChild (0).GetChild (6).GetComponent<tk2dSprite> ().SetSprite ("nuaodai");
			break;
		case 3:
			pTra.GetChild (0).GetChild (6).GetComponent<tk2dSprite> ().SetSprite ("nudoimu");
			break;
		case 4:
			pTra.GetChild (0).GetChild (6).GetComponent<tk2dSprite> ().SetSprite ("nuaobetrap");
			break;
		case 5:
			pTra.GetChild (0).GetChild (6).GetComponent<tk2dSprite> ().SetSprite ("nuvanphong");
			break;
		case 6:
			pTra.GetChild (0).GetChild (6).GetComponent<tk2dSprite> ().SetSprite ("nudoinon");
			break;
		case 7:
			pTra.GetChild (0).GetChild (6).GetComponent<tk2dSprite> ().SetSprite ("ongcongongtao");
			break;
		case 8:
			pTra.GetChild (0).GetChild (6).GetComponent<tk2dSprite> ().SetSprite ("namxanhthuphap");
			break;
		default:
			pTra.GetChild (0).GetChild (6).GetComponent<tk2dSprite> ().SetSprite ("nudoixe");
			break;
		}

		string content = "";
		string author = "";

		chon=pDt.Day+(pDt.Month*31);
		if (mang [chon].Contains ("@")) {
			int chiso = mang [chon].IndexOf ("@");
			if (chiso != -1) {
				pTra.GetChild (0).GetChild (3).GetComponent<tk2dTextMesh> ().text = mang [chon].Substring (0, chiso);
				pTra.GetChild (0).GetChild (4).GetComponent<tk2dTextMesh> ().text = mang [chon].Substring (chiso+1);
				//content=""+mang [chon].Substring (0, chiso);
				//author=""+ mang [chon].Substring (chiso+1);
			}
		}

	
		
		pTra.GetChild (0).GetChild (0).GetComponent<tk2dTextMesh> ().text = "" + pDt.Day;
		//Thang
		pTra.GetChild (0).GetChild (2).GetComponent<tk2dTextMesh> ().text = "THÁNG "+pDt.Month+" NĂM "+pDt.Year;
		int[] am = LunarYearTools.convertSolar2Lunar (pDt.Day, pDt.Month, pDt.Year, 7);
		pTra.GetChild (2).GetChild (2).GetComponent<tk2dTextMesh> ().text = ""+am[0];
		pTra.GetChild(2).GetChild(3).GetComponent<tk2dTextMesh>().text = am[1]+"/"+am[2];

		int dGio = DateTime.Now.Hour;
		string dPhut = ""+DateTime.Now.Minute;

		string dQuyTime = "";
		if (dPhut.Length == 1) {
			dPhut = "0" + dPhut;
		}

		if(dGio<=10)
		{
			dQuyTime="Giờ Sáng";
		}else  if(dGio<=13)
		{
			dQuyTime="Giờ Chưa";
		}else  if(dGio<=17)
		{
			dQuyTime="Giờ Chiều";
		}else {
			dQuyTime="Giờ Tối";
		}

		if(dGio>12)
		{
			dGio=dGio-12;
		}

		pTra.GetChild (2).GetChild (0).GetComponent<tk2dTextMesh> ().text = dGio + ":" + dPhut;
		pTra.GetChild (2).GetChild (1).GetComponent<tk2dTextMesh> ().text = dQuyTime;

		switch (pDt.DayOfWeek.ToString ().ToLower ().Substring(0,2)) {
		case "mo":
			pTra.GetChild (0).GetChild (1).GetComponent<tk2dTextMesh> ().text = "Thứ 2";
			
            doUpdateColor(pTra, new Color((float)4 / 255, (float)167 / 255, (float)12 / 255, 1));
			break;
		case "tu":
			pTra.GetChild (0).GetChild (1).GetComponent<tk2dTextMesh> ().text = "Thứ 3";
			
            doUpdateColor(pTra, new Color((float)38 / 255, (float)104 / 255, (float)234 / 255, 1));
			break;
		case "we":
			pTra.GetChild (0).GetChild (1).GetComponent<tk2dTextMesh> ().text = "Thứ 4";
			
            doUpdateColor(pTra, new Color((float)13 / 255, (float)126 / 255, (float)84 / 255, 1));
			break;
		case "th":
			pTra.GetChild (0).GetChild (1).GetComponent<tk2dTextMesh> ().text = "Thứ 5";
			
            doUpdateColor(pTra, new Color((float)205 / 255, 0, (float)153 / 255, 1));
			break;
		case "fr":
			pTra.GetChild (0).GetChild (1).GetComponent<tk2dTextMesh> ().text = "Thứ 6";
			
            doUpdateColor(pTra, new Color((float)195 / 255, (float)96 / 255, (float)52 / 255, 1));
			break;
		case "sa":
			pTra.GetChild (0).GetChild (1).GetComponent<tk2dTextMesh> ().text = "Thứ 7";
			
            doUpdateColor(pTra, new Color((float)38 / 255, (float)104 / 255, (float)234 / 255, 1));
			break;
			default:
			pTra.GetChild (0).GetChild (1).GetComponent<tk2dTextMesh> ().text = "Chủ Nhật";
			;
            doUpdateColor(pTra, new Color(1, (float)84 / 255, (float)84 / 255, 1));
			break;
		}
	
		if (pDt.Day==DateTime.Now.Day && pDt.Month==DateTime.Now.Month && pDt.Year==DateTime.Now.Year) {
			pTra.GetChild (4).GetChild (0).gameObject.SetActive (false);
			//Debug.Log(""+pDt);
		} else {
			pTra.GetChild (4).GetChild (0).gameObject.SetActive (true);
		}

		chon = UnityEngine.Random.Range (0, 6);
		if (chon <= 2) {
			pTra.GetChild (0).GetChild (5).gameObject.SetActive (false);
			pTra.GetChild (0).GetChild (6).gameObject.SetActive (true);
		} else if (chon <= 4) {
			pTra.GetChild (0).GetChild (5).gameObject.SetActive (true);
			pTra.GetChild (0).GetChild (6).gameObject.SetActive (false);
		} else {
			pTra.GetChild (0).GetChild (5).gameObject.SetActive (true);
			pTra.GetChild (0).GetChild (6).gameObject.SetActive (true);
		}
	
	
	}

    public void doUpdateColor(Transform pTra ,Color pColor)
    {
        pTra.GetChild(4).GetComponent<tk2dSprite>().color = pColor;
        pTra.GetChild(0).GetChild(0).GetComponent<tk2dTextMesh>().color = pColor;
        pTra.GetChild(0).GetChild(1).GetComponent<tk2dTextMesh>().color = pColor;
        pTra.GetChild(0).GetChild(2).GetComponent<tk2dTextMesh>().color = pColor;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Move object across XY plane
            transform.Translate(touchDeltaPosition.x * speed, this.transform.position.y, 0);
        }
        else if (Input.touchCount != 0 && Input.GetTouch(0).phase
       == TouchPhase.Ended)
        {
			float xxxx = this.transform.position.x - startPosition.x;
			if (xxxx > 120) {
				today = today.AddDays (-1);
				doSetDate (oHomNay, today);
				doSetDate (oHomQua, today.AddDays (-1));
				doSetDate (oNgayMai, today.AddDays (1));
			} else if (xxxx < -120) {
				today = today.AddDays (1);
				doSetDate (oHomNay, today);
				doSetDate (oHomQua, today.AddDays (-1));
				doSetDate (oNgayMai, today.AddDays (1));
			}


			txttest.text=""+xxxx;


			this.transform.position = startPosition;
        }


	}
}
