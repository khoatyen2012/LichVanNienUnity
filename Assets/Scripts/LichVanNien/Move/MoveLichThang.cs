using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MoveLichThang : MonoBehaviour {


    public float speed;
    Vector3 startPosition;

	public ItemThang itemPrefab;
	public float startX;
	public float distanceX;
	public float startY;
	public float distanceY;

    private Transform TraTrai;
    private Transform TraGiua;
    private Transform TraPhai;

	DateTime today;

	private tk2dUIItem btnHomNay;


    public void setEmptyChild()
    {
        var children = new List<GameObject>();
        foreach (Transform child in TraTrai)
        {
            if (child.gameObject.CompareTag("nguoi"))
            {
                continue;
            }
            children.Add(child.gameObject);
        }

        foreach (Transform child in TraGiua)
        {
            if (child.gameObject.CompareTag("nguoi"))
            {
                continue;
            }
            children.Add(child.gameObject);
        }

        foreach (Transform child in TraPhai)
        {
            if (child.gameObject.CompareTag("nguoi"))
            {
                continue;
            }
            children.Add(child.gameObject);
        }


        foreach (GameObject item in children)
        {
            item.transform.parent = null;
            item.transform.Recycle();
        }

        

    }

	void CreateItem(float positionX, float positionY,Transform pParent,string pDuong,string pAm,int pType)
	{

		ItemThang levelCreate = itemPrefab.Spawn<ItemThang>
			(
				new Vector3(positionX, positionY, 35f),
				itemPrefab.transform.rotation
			);

		levelCreate.setDate (pDuong, pAm,pType);

        levelCreate.transform.parent = pParent;


	}

	public void Createlevl(int sl, float pStartX, float pStartY,Transform pParent,DateTime pDate)
	{
		if (pDate.Day == DateTime.Now.Day && pDate.Month == DateTime.Now.Month && pDate.Year == DateTime.Now.Year) {
			pParent.GetChild (0).GetChild (3).GetComponent<tk2dSprite> ().SetSprite ("logo");
		} else {
			pParent.GetChild (0).GetChild (3).GetComponent<tk2dSprite> ().SetSprite ("homnay");
		}
		
		int days = DateTime.DaysInMonth(pDate.Year, pDate.Month);
		if (pDate.Month < 10) {
			pParent.GetChild (0).GetChild (0).GetComponent<tk2dTextMesh> ().text = "0" + pDate.Month + " - " + pDate.Year;
		} else {
			pParent.GetChild (0).GetChild (0).GetComponent<tk2dTextMesh> ().text = pDate.Month + " - " + pDate.Year;
		}

		List<string> lstTam = new List<string> ();

		int khoang = 0;

		switch (("" + new DateTime (pDate.Year, pDate.Month, 1).DayOfWeek).ToString().ToLower().Substring(0,2)) {
		case "mo":
			khoang = 1;
			break;
		case "tu":
			khoang = 2;
			break;
		case "we":
			khoang = 3;
			break;
		case "th":
			khoang = 4;
			break;
		case "fr":
			khoang = 5;
			break;
		case "sa":
			khoang = 6;
			break;
		default:
			khoang = 0;
			break;
		}

		for (int i = 1; i <= khoang; i++) {

			lstTam.Add ("@");
		}

		for (int i = 1; i <= days; i++) {
			int[] am = LunarYearTools.convertSolar2Lunar (i, pDate.Month, pDate.Year, 7);
			if (am [0] == 1 || i == days) {
				lstTam.Add (i + "@" + am [0]+"/"+am[1]);
			} else {
				lstTam.Add (i + "@" + am [0]);
			}
		}
		
        float positionCreateX = pStartX;
        float positionCreateY = pStartY;
		for (int i = 1; i <= lstTam.Count; i++)
		{
			string[] tam = lstTam [i - 1].Split ('@');
			if (!tam [0].Trim ().Equals ("")) {
				if (int.Parse (tam [0]) == DateTime.Now.Day && pDate.Month == DateTime.Now.Month && pDate.Year == DateTime.Now.Year) {
					
                    if (i == 1 || i == 8 || i == 15 || i == 22 || i == 29 || i == 36)
                    {
                        CreateItem(positionCreateX, positionCreateY, pParent, tam[0], tam[1], 4);
                    }
                    else
                    {
                        CreateItem(positionCreateX, positionCreateY, pParent, tam[0], tam[1], 3);
                    }
				} else if (i == 1 || i == 8 || i == 15 || i == 22 || i == 29 || i == 36) {
					CreateItem (positionCreateX, positionCreateY, pParent, tam [0], tam [1], 2);
				} else {
					CreateItem (positionCreateX, positionCreateY, pParent, tam [0], tam [1], 1);
				}
			} else {
				CreateItem(positionCreateX, positionCreateY, pParent,tam[0],tam[1],1);
			}


			positionCreateX += distanceX;
			if (i % 7 == 0)
			{
                positionCreateX = pStartX;
				positionCreateY -= distanceY;
			}
		}
	}

	public void setData()
	{
		try
		{
        setEmptyChild();
		today = DateTime.Now;
		Createlevl (40,startX,startY,TraGiua,today);
		Createlevl(40, startX-580, startY, TraTrai,today.AddMonths(-1));
		Createlevl(40, startX+580, startY, TraPhai,today.AddMonths(1));
		}
		catch (System.Exception)
		{

			throw;
		}
	}

	//public void btnHomNay_OnClick()
	//{
		//setData ();
	//}


	// Use this for initialization
	void Start () {
		try
		{
        startPosition = this.transform.position;
        TraTrai = this.gameObject.transform.GetChild(0).transform;
        TraGiua = this.gameObject.transform.GetChild(1).transform;
        TraPhai = this.gameObject.transform.GetChild(2).transform;
		btnHomNay = TraGiua.GetChild (0).GetChild (3).GetComponent<tk2dUIItem> ();
		btnHomNay.OnClick += setData;
		today = DateTime.Now;
		}
		catch (System.Exception)
		{

			throw;
		}
	}

	IEnumerator WaitTimeTrai(float time)
	{
		//do something...............
		yield return new WaitForSeconds(time);

		setEmptyChild();
		today = today.AddMonths (-1);
		Createlevl (40,startX,startY,TraGiua,today);
		Createlevl(40, startX-580, startY, TraTrai,today.AddMonths(-1));
		Createlevl(40, startX+580, startY, TraPhai,today.AddMonths(1));

	}

	IEnumerator WaitTimePhai(float time)
	{
		//do something...............
		yield return new WaitForSeconds(time);

		setEmptyChild();
		today = today.AddMonths (1);
		Createlevl (40,startX,startY,TraGiua,today);
		Createlevl(40, startX-580, startY, TraTrai,today.AddMonths(-1));
		Createlevl(40, startX+580, startY, TraPhai,today.AddMonths(1));

	}
	
	// Update is called once per frame
	void Update () {
        if (LichController.instance.currentState == LichController.State.THANG)
        {

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
			
					StartCoroutine(WaitTimeTrai(0.001f));
				} else if (xxxx < -120) {
					StartCoroutine(WaitTimePhai(0.001f));
				}

           


                this.transform.position = new Vector3(startPosition.x,0f,startPosition.z);
            }
        }
	}
}
