using UnityEngine;
using System.Collections;
using System;


public class MoveLichNgay : MonoBehaviour {

    public float speed;
	public Vector3 startPosition;
	public tk2dTextMesh txttest;
	DateTime today;
	Transform oHomQua;
	Transform oHomNay;
	Transform oNgayMai;


	void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus) {

		} else {
			
		}
	}

	// Use this for initialization
	void Start () {
		oHomQua = this.transform.GetChild (0);
		oHomNay = this.transform.GetChild (1);
		oNgayMai = this.transform.GetChild (2);

		startPosition = this.transform.position;

		today = DateTime.Now;
		doSetDate (oHomNay, today);


	}

	void doSetDate(Transform pTra,DateTime pDt)
	{
		pTra.GetChild (0).GetChild (0).GetComponent<tk2dTextMesh> ().text = "" + pDt.Day;


		switch (pDt.DayOfWeek.ToString ().ToLower ().Substring(0,2)) {
		case "mo":
			pTra.GetChild (0).GetChild (1).GetComponent<tk2dTextMesh> ().text = "Thứ 2";
			break;
		case "tu":
			pTra.GetChild (0).GetChild (1).GetComponent<tk2dTextMesh> ().text = "Thứ 3";
			break;
		case "we":
			pTra.GetChild (0).GetChild (1).GetComponent<tk2dTextMesh> ().text = "Thứ 4";
			break;
		case "th":
			pTra.GetChild (0).GetChild (1).GetComponent<tk2dTextMesh> ().text = "Thứ 5";
			break;
		case "fr":
			pTra.GetChild (0).GetChild (1).GetComponent<tk2dTextMesh> ().text = "Thứ 6";
			break;
		case "sa":
			pTra.GetChild (0).GetChild (1).GetComponent<tk2dTextMesh> ().text = "Thứ 7";
			break;
			default:
			pTra.GetChild (0).GetChild (1).GetComponent<tk2dTextMesh> ().text = "Chủ Nhật";
			break;
		}
		pTra.GetChild (0).GetChild (2).GetComponent<tk2dTextMesh> ().text = "THÁNG "+pDt.Month+" NĂM "+pDt.Year;
		int[] tam = LunarYearTools.convertSolar2Lunar (pDt.Day, pDt.Month, pDt.Year, 7);
		pTra.GetChild (2).GetChild (2).GetComponent<tk2dTextMesh> ().text = ""+tam[0];
        pTra.GetChild(2).GetChild(3).GetComponent<tk2dTextMesh>().text = tam[1]+"/"+tam[2];
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
			//if (xxxx > 0) {
			//	startPosition = new Vector3 (startPosition.x + 580, startPosition.y, startPosition.z);
			//} else if (xxxx < 0) {
			//	startPosition = new Vector3 (startPosition.x - 580, startPosition.y, startPosition.z);
			//}


			txttest.text=""+xxxx;


			this.transform.position = startPosition;
        }


	}
}
