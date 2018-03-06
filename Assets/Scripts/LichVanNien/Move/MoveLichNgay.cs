using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class MoveLichNgay : MonoBehaviour {

    public float speed;
	 Vector3 startPosition;

	DateTime today;
	Transform oHomQua;
	Transform oHomNay;
	Transform oNgayMai;

	string sText = "danhngon";
	//List<string> lst = new List<string>();
	string[] mang;

    ThanThai tbL = new ThanThai();
    ThanThai tbR = new ThanThai();
    ThanThai tbC = new ThanThai();



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
	public void Today()
	{
		today = DateTime.Now;

		doSetDate (oHomNay, today,ref tbC,0);
		doSetDate (oHomQua, today.AddDays (-1),ref tbL,0);
		doSetDate (oNgayMai, today.AddDays (1),ref tbR,0);
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

	public void setDayToLich(Transform pTra,int pDt)
	{
		if (pDt < 10) {

			pTra.GetChild (0).gameObject.SetActive (true);
			pTra.GetChild (1).gameObject.SetActive (false);
			switch (pDt) {
			case 1:
				pTra.GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("ngayle_1");
				break;
			case 2:
				pTra.GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("ngayle_2");
				break;
			case 3:
				pTra.GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("ngayle_3");
				break;
			case 4:
				pTra.GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("ngayle_4");
				break;
			case 5:
				pTra.GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("ngayle_5");
				break;
			case 6:
				pTra.GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("ngayle_6");
				break;
			case 7:
				pTra.GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("ngayle_7");
				break;
			case 8:
				pTra.GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("ngayle_8");
				break;
			case 9:
				pTra.GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("ngayle_9");
				break;
			}

		
		} else {

			pTra.GetChild (0).gameObject.SetActive (false);
			pTra.GetChild (1).gameObject.SetActive (true);

			if (pDt < 20) {
				pTra.GetChild (1).GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("ngayle_1");
			} else if (pDt < 30) {
				pTra.GetChild (1).GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("ngayle_2");
			} else {
				pTra.GetChild (1).GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("ngayle_3");
			}

		
			pTra.GetChild (1).GetChild (1).GetComponent<tk2dSprite> ().SetSprite ("ngayle_"+(""+pDt).Substring(1,1));

		}
	}

	void GetDaTa(string tmg)
	{
		 mang = tmg.Trim().Split('#');


	}

	void doSetDate(Transform pTra,DateTime pDt, ref ThanThai thanthai,int pCheckok)
	{
		int chon = UnityEngine.Random.Range (0, 10);
		switch (chon) {
		case 0:
			pTra.GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("nenmua");
            thanthai.Bg = "nenmua";
			break;
		case 1:
			pTra.GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("nentuyet");
            thanthai.Bg = "nentuyet";
			break;
		case 2:
			pTra.GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("nenvang");
            thanthai.Bg = "nenvang";
			break;

		default:
			pTra.GetChild (0).GetComponent<tk2dSprite> ().SetSprite ("nennang");
            thanthai.Bg = "nennang";
			break;
		}


		chon = UnityEngine.Random.Range (0, 13);
		int chonNu = UnityEngine.Random.Range (0, 13);
		switch (chon) {
		case 0:
			pTra.GetChild (0).GetChild (4).GetComponent<tk2dSprite> ().SetSprite ("namdodam");
            thanthai.Nam = "namdodam";
			break;
		case 1:
			pTra.GetChild (0).GetChild (4).GetComponent<tk2dSprite> ().SetSprite ("namtim");
            thanthai.Nam = "namtim";
			break;
		case 2:
			pTra.GetChild (0).GetChild (4).GetComponent<tk2dSprite> ().SetSprite ("namxanhduong");
            thanthai.Nam = "namxanhduong";
			break;
		case 3:
			pTra.GetChild (0).GetChild (4).GetComponent<tk2dSprite> ().SetSprite ("namve");
            thanthai.Nam = "namve";
			break;
		case 4:
			pTra.GetChild (0).GetChild (4).GetComponent<tk2dSprite> ().SetSprite ("namkysu");
            thanthai.Nam = "namkysu";
			break;
		case 5:
			pTra.GetChild (0).GetChild (4).GetComponent<tk2dSprite> ().SetSprite ("namlichviet");
            thanthai.Nam = "namlichviet";
			break;
		case 6:
			pTra.GetChild (0).GetChild (4).GetComponent<tk2dSprite> ().SetSprite ("namtana");
            thanthai.Nam = "namtana";
			break;
		case 7:
			pTra.GetChild (0).GetChild (4).GetComponent<tk2dSprite> ().SetSprite ("namdothuphap");
            thanthai.Nam = "namdothuphap";
			break;
		case 8:
			pTra.GetChild (0).GetChild (4).GetComponent<tk2dSprite> ().SetSprite ("namdoanhnhan");
            thanthai.Nam = "namdoanhnhan";
			break;
		default:
			pTra.GetChild (0).GetChild (4).GetComponent<tk2dSprite> ().SetSprite ("nambetrap");
            thanthai.Nam = "nambetrap";
			break;
		}

		switch (chonNu) {
		case 0:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("nudodam");
            thanthai.Nu = "nudodam";
			break;
		case 1:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("nutim");
            thanthai.Nu = "nutim";
			break;
		case 2:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("nuaodai");
            thanthai.Nu = "nuaodai";
			break;
		case 3:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("nudoimu");
            thanthai.Nu = "nudoimu";
			break;
		case 4:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("nuaobetrap");
            thanthai.Nu = "nuaobetrap";
			break;
		case 5:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("nuvanphong");
            thanthai.Nu = "nuvanphong";
			break;
		case 6:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("nudoinon");
            thanthai.Nu = "nudoinon";
			break;
		case 7:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("ongcongongtao");
            thanthai.Nu = "ongcongongtao";
			break;
		case 8:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("namxanhthuphap");
            thanthai.Nu = "namxanhthuphap";
			break;
		default:
			pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("nudoixe");
            thanthai.Nu = "nudoixe";
			break;
		}

	

	
		setDayToLich (pTra.GetChild (0).GetChild (6), pDt.Day);

		//Thang
		pTra.GetChild (0).GetChild (1).GetComponent<tk2dTextMesh> ().text = "THÁNG "+pDt.Month+" NĂM "+pDt.Year;
		int[] am = LunarYearTools.convertSolar2Lunar (pDt.Day, pDt.Month, pDt.Year, 7);
		//pTra.GetChild (2).GetChild (2).GetComponent<tk2dTextMesh> ().text = ""+am[0];
		setDayToLich(pTra.GetChild(2).GetChild(3),am[0]);
		pTra.GetChild(2).GetChild(2).GetComponent<tk2dTextMesh>().text = am[1]+"/"+am[2];

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
			pTra.GetChild (0).GetChild (0).GetComponent<tk2dTextMesh> ().text = "Thứ 2";
            pTra.GetChild(0).GetChild(0).localPosition = new Vector3(-52, pTra.GetChild(0).GetChild(0).localPosition.y, pTra.GetChild(0).GetChild(0).localPosition.z);
            doUpdateColor(pTra, new Color(0, (float)170 / 255, 0, 1));
			break;
		case "tu":
			pTra.GetChild (0).GetChild (0).GetComponent<tk2dTextMesh> ().text = "Thứ 3";
            pTra.GetChild(0).GetChild(0).localPosition = new Vector3(-52, pTra.GetChild(0).GetChild(0).localPosition.y, pTra.GetChild(0).GetChild(0).localPosition.z);
            doUpdateColor(pTra, new Color(0, (float)153 / 255, 1, 1));
			break;
		case "we":
			pTra.GetChild (0).GetChild (0).GetComponent<tk2dTextMesh> ().text = "Thứ 4";
            pTra.GetChild(0).GetChild(0).localPosition = new Vector3(-52, pTra.GetChild(0).GetChild(0).localPosition.y, pTra.GetChild(0).GetChild(0).localPosition.z);
            doUpdateColor(pTra, new Color(0, (float)153 / 255, (float)102 / 255, 1));
			break;
		case "th":
			pTra.GetChild (0).GetChild (0).GetComponent<tk2dTextMesh> ().text = "Thứ 5";
            pTra.GetChild(0).GetChild(0).localPosition = new Vector3(-52, pTra.GetChild(0).GetChild(0).localPosition.y, pTra.GetChild(0).GetChild(0).localPosition.z);
            doUpdateColor(pTra, new Color((float)204 / 255, 0, (float)153 / 255, 1));
			break;
		case "fr":
			pTra.GetChild (0).GetChild (0).GetComponent<tk2dTextMesh> ().text = "Thứ 6";
            pTra.GetChild(0).GetChild(0).localPosition = new Vector3(-52, pTra.GetChild(0).GetChild(0).localPosition.y, pTra.GetChild(0).GetChild(0).localPosition.z);
            doUpdateColor(pTra, new Color((float)205 / 255, (float)133 / 255, (float)63 / 255, 1));
			break;
		case "sa":
			pTra.GetChild (0).GetChild (0).GetComponent<tk2dTextMesh> ().text = "Thứ 7";
            pTra.GetChild(0).GetChild(0).localPosition = new Vector3(-52, pTra.GetChild(0).GetChild(0).localPosition.y, pTra.GetChild(0).GetChild(0).localPosition.z);
            doUpdateColor(pTra, new Color(0, (float)153 / 255, 1, 1));
			break;
			default:
			pTra.GetChild (0).GetChild (0).GetComponent<tk2dTextMesh> ().text = "Chủ Nhật";
            pTra.GetChild(0).GetChild(0).localPosition = new Vector3(-85, pTra.GetChild(0).GetChild(0).localPosition.y, pTra.GetChild(0).GetChild(0).localPosition.z);
            doUpdateColor(pTra, new Color(1, (float)106 / 255, (float)106 / 255, 1));
			break;
		}
	
		if (pDt.Day==DateTime.Now.Day && pDt.Month==DateTime.Now.Month && pDt.Year==DateTime.Now.Year) {
			pTra.GetChild (4).GetChild (0).gameObject.SetActive (false);
			//Debug.Log(""+pDt);
		} else {
			pTra.GetChild (4).GetChild (0).gameObject.SetActive (true);
		}


        string content = "";
        string author = "";

        if (am[0] == 1 && am[1] == 1)
        {
            content = "Chúc mừng năm mới. Ngày mùng 1 tết cố truyền dân tộc";
            author = "Xuân đã về";
            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namtetdo");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("namtet");

			thanthai.Sl = 2;
			thanthai.Nam = "namtetdo";
			thanthai.Nu = "namtet";


        }
        else if (am[0] == 2 && am[1] == 1)
        {
            content = "Mùng 1 tết cha mùng 2 tết mẹ mùng 3 tết thầy";
            author = "Mùng 2 tết";
            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("nubanhtrung");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("namduahau");

			thanthai.Sl = 2;
			thanthai.Nam = "nubanhtrung";
			thanthai.Nu = "namduahau";
        }
        else if (am[0] == 3 && am[1] == 1)
        {
            content = "Mùng 3 tết thầy";
            author = "Mùng 3 tết";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("nubanhtrung");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("nutetdo");

			thanthai.Sl = 2;
			thanthai.Nam = "nubanhtrung";
			thanthai.Nu = "nutetdo";


        }
        else if (am[0] == 15 && am[1] == 1)
        {
            content = "Ngày dằm tháng giêng";
            author = "Tết nguyên tiêu";
        }
        else if (am[0] == 3 && am[1] == 3)
        {
            content = "Tết bánh trôi bánh tray";
            author = "Tết hàn thực";
        }
        else if (am[0] == 10 && am[1] == 3)
        {
            content = "Ngày dỗ tổ hùng vương. Vua hùng đã có công dựng nước";
            author = "Vua Hùng";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namvuahung");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(false);

			thanthai.Sl = 3;
			thanthai.Nam = "namvuahung";
		

        }
        else if (am[0] == 15 && am[1] == 4)
        {
            content = "Ngày lễ phật đản";
            author = "A di đà phật";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namsuphu");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(false);

			thanthai.Sl = 3;
			thanthai.Nam = "namsuphu";

        }
        else if (am[0] == 5 && am[1] == 5)
        {
            content = "Ngày tết đoan ngọ";
            author = "Tết đoan ngọ";



        }
        else if (am[0] == 15 && am[1] == 7)
        {
            content = "Công cha như núi thái sơn. Nghĩa mẹ như nước trong nguồn chảy ra";
            author = "Ngày lễ vu lan";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namgiadinh");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("nugiadinh");

			thanthai.Sl = 2;
			thanthai.Nam = "namgiadinh";
			thanthai.Nu = "nugiadinh";

        }
        else if (am[0] == 15 && am[1] == 8)
        {
            content = "Ngày tết trung thu";
            author = "Chị hằng";
            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namduahau");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(false);

			thanthai.Sl = 3;
			thanthai.Nam = "namduahau";


        }
        else if (am[0] == 9 && am[1] == 9)
        {
            content = "Ngày tết cửu trùng";
            author = "Diệt sâu bọ";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("dietsaubo");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(false);

			thanthai.Sl = 2;
			thanthai.Nam = "dietsaubo";
		


        }
        else if (am[0] == 10 && am[1] == 10)
        {
            content = "Ngày tết thường tân";
            author = "tết";
        }
        else if (am[0] == 15 && am[1] == 10)
        {
            content = "Ngày tết hạ nguyên";
            author = "Nguyên";
        }
        else if (am[0] == 23 && am[1] == 12)
        {
            content = "Tiễn Ông Công Ông Táo Về Trời";
            author = "Táo quân";

   
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(false);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("ongcongongtao");

			thanthai.Sl = 4;
	
			thanthai.Nu = "ongcongongtao";

        }
        else if (pDt.Day == 1 && pDt.Month == 1)
        {
            content = "Ngày tết dương lịch";
            author = "Happy new year";
        }
        else if (pDt.Day == 14 && pDt.Month == 2)
        {
            content = "Ngày lễ tình nhân";
            author = "Valentine";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namtinhyeu");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(false);

			thanthai.Sl = 3;
			thanthai.Nam = "namtinhyeu";
	

        }
        else if (pDt.Day == 27 && pDt.Month == 2)
        {
            content = "Ngày thầy thuốc Việt Nam";
            author = "Lương y như từ mẫu";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("nambacsi");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(false);

			thanthai.Sl = 3;
			thanthai.Nam = "nambacsi";
     

        }
        else if (pDt.Day == 8 && pDt.Month == 3)
        {
            content = "Ngày quốc tế phụ nữ";
            author = "Yêu thương";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("nuaobetrap");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("nudoinon");

			thanthai.Sl = 2;
			thanthai.Nam = "nuaobetrap";
			thanthai.Nu = "nudoinon";

        }
        else if (pDt.Day == 26 && pDt.Month == 3)
        {
            content = "Ngày thành lập Đoàn TNCS Hồ Chí Minh";
            author = "Hồ Chí Minh";
        }
        else if (pDt.Day == 1 && pDt.Month == 4)
        {
            content = "Ngày cá tháng 4";
            author = "Nói dối";
        }
        else if (pDt.Day == 30 && pDt.Month == 4)
        {
            content = "GIẢI PHÓNG MIỀN NAM";
            author = "Giải Phóng";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("nuhaiquan");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("nubodoi");

			thanthai.Sl = 2;
			thanthai.Nam = "nuhaiquan";
			thanthai.Nu = "nubodoi";


        }
        else if (pDt.Day == 1 && pDt.Month == 5)
        {
            content = "Ngày quốc tế lao động";
            author = "Lao động";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namkysu");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("nudoixe");

			thanthai.Sl = 2;
			thanthai.Nam = "namkysu";
			thanthai.Nu = "nudoixe";

        }
        else if (pDt.Day == 7 && pDt.Month == 5)
        {
            content = "Ngày chiến thắng điện biên phủ";
            author = "Đừng ngủ quên trên chiến thắng";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namcongan");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("nuhaiquan");

			thanthai.Sl = 2;
			thanthai.Nam = "namcongan";
			thanthai.Nu = "nuhaiquan";

        }
        else if (pDt.Day == 13 && pDt.Month == 5)
        {
            content = "Ngày của mẹ !";
            author = "Mẹ yêu";

   
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(false);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("nugiadinh");

			thanthai.Sl = 4;
			thanthai.Nu = "nugiadinh";

   
        }
        else if (pDt.Day == 19 && pDt.Month == 5)
        {
            content = "Ngày sinh chủ tịch Hồ Chí Minh";
            author = "Sinh nhật bác";
        }
        else if (pDt.Day == 1 && pDt.Month == 6)
        {
            content = "Ngày quốc tế thiếu nhi";
            author = "Trẻ em hôm nay";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namgiadinh");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("nugiadinh");

			thanthai.Sl = 2;
			thanthai.Nam = "namgiadinh";
			thanthai.Nu = "nugiadinh";

         
        }
        else if (pDt.Day == 17 && pDt.Month == 6)
        {
            content = "Ngày của cha";
            author = "Nợ cha 1 sự nghiệp";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namgiadinh");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(false);

			thanthai.Sl = 3;
			thanthai.Nam = "namgiadinh";
		
      

    
        }
        else if (pDt.Day == 21 && pDt.Month == 6)
        {
            content = "Ngày báo chí Việt Nam";
            author = "Balo";
        }
        else if (pDt.Day == 28 && pDt.Month == 6)
        {
            content = "Ngày gia đình Việt Nam";
            author = "Gia Đình";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namgiadinh");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("nugiadinh");

			thanthai.Sl = 2;
			thanthai.Nam = "namgiadinh";
			thanthai.Nu = "nugiadinh";

        }
        else if (pDt.Day == 11 && pDt.Month == 7)
        {
            content = "Ngày dân số thế giới";
            author = "Kế Hoạch Hóa Gia Đình";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namgiadinh");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("nugiadinh");

			thanthai.Sl = 2;
			thanthai.Nam = "namgiadinh";
			thanthai.Nu = "nugiadinh";

        }
        else if (pDt.Day == 27 && pDt.Month == 7)
        {
            content = "Ngày thương binh liệt sĩ";
            author = "Tổ quốc ghi công";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namcongan");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("nuhaiquan");

			thanthai.Sl = 2;
			thanthai.Nam = "namcongan";
			thanthai.Nu = "nuhaiquan";

        }
        else if (pDt.Day == 28 && pDt.Month == 7)
        {
            content = "Ngày công đoàn Việt nam";
            author = "Đoàn kết";

            pTra.GetChild(0).GetChild(4).gameObject.SetActive(false);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("codosaovang");

			thanthai.Sl = 4;

			thanthai.Nu = "codosaovang";
   
        }
        else if (pDt.Day == 19 && pDt.Month == 8)
        {
            content = "Ngày tổng khởi nghĩa";
            author = "Cách mạng tháng 8";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namcongan");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("nuhaiquan");

			thanthai.Sl = 2;
			thanthai.Nam = "namcongan";
			thanthai.Nu = "nuhaiquan";

        }
        else if (pDt.Day == 2 && pDt.Month == 9)
        {
            content = "Ngày quốc khánh";
            author = "Cờ đỏ";

            pTra.GetChild(0).GetChild(4).gameObject.SetActive(false);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("codosaovang");

			thanthai.Sl = 4;

			thanthai.Nu = "codosaovang";

        }
        else if (pDt.Day == 10 && pDt.Month == 9)
        {
            content = "Ngày thành lập mặt trận tổ quốc Việt nam";
            author = "Việt Nam";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namcongan");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("nuhaiquan");

			thanthai.Sl = 2;
			thanthai.Nam = "namcongan";
			thanthai.Nu = "nuhaiquan";

        }
        else if (pDt.Day == 1 && pDt.Month == 10)
        {
            content = "Ngày quốc tế người cao tuổi";
            author = "Kĩnh lão đắc thọ";

        }
        else if (pDt.Day == 10 && pDt.Month == 10)
        {
            content = "Ngày giải phóng Thủ Đô";
            author = "Hà Nội";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namcongan");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("nuhaiquan");

			thanthai.Sl = 2;
			thanthai.Nam = "namcongan";
			thanthai.Nu = "nuhaiquan";

        }
        else if (pDt.Day == 13 && pDt.Month == 10)
        {
            content = "Ngày doanh nhân Việt Nam";
            author = "Startup";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namdoanhnhan");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(false);

			thanthai.Sl = 2;
			thanthai.Nam = "namdoanhnhan";
	
   
        }
        else if (pDt.Day == 20 && pDt.Month == 10)
        {
            content = "Ngày phụ nữ Việt Nam";
            author = "Hoa Hồng Có Gai";
            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("nuaobetrap");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("nudoinon");

			thanthai.Sl = 2;
			thanthai.Nam = "nuaobetrap";
			thanthai.Nu = "nudoinon";


        }
        else if (pDt.Day == 31 && pDt.Month == 10)
        {
            content = "Ngày Hallowen";
            author = "Bí Ngô";

        
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(false);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("nuhalowen");

			thanthai.Sl = 4;

			thanthai.Nu = "nuhalowen";

        }
        else if (pDt.Day == 9 && pDt.Month == 11)
        {
            content = "Ngày pháp luật Việt Nam";
            author = "pháp luật";
        }
        else if (pDt.Day == 20 && pDt.Month == 11)
        {
            content = "Ngày Nhà Giáo Việt Nam";
            author = "Bụi phấn";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namthaygiao");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(false);

			thanthai.Sl = 3;
			thanthai.Nam = "namthaygiao";
	

        }
        else if (pDt.Day == 23 && pDt.Month == 11)
        {
            content = "Ngày thành lập hội chữ thập đỏ Việt Nam";
            author = "Cộng đồng";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("nambacsi");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(false);

			thanthai.Sl = 3;
			thanthai.Nam = "nambacsi";

        }
        else if (pDt.Day == 1 && pDt.Month == 12)
        {
            content = "Ngày toàn thế giới chống xi-đa";
            author = "HIV AIDS";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("nambacsi");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(false);

			thanthai.Sl = 3;
			thanthai.Nam = "nambacsi";



        }
        else if (pDt.Day == 19 && pDt.Month == 12)
        {
            content = "Ngày toàn quốc kháng chiến";
            author = "Cách mạng tháng 12";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namcongan");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
            pTra.GetChild(0).GetChild(5).GetComponent<tk2dSprite>().SetSprite("nuhaiquan");

			thanthai.Sl = 2;
			thanthai.Nam = "nambacsi";
			thanthai.Nu = "nuhaiquan";

        }
        else if (pDt.Day == 22 && pDt.Month == 12)
        {
            content = "Ngày thành lập quân đội nhân dân Việt Nam";
            author = "CF";

            pTra.GetChild(0).GetChild(4).GetComponent<tk2dSprite>().SetSprite("namcongan");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);

            pTra.GetChild(0).GetChild(5).gameObject.SetActive(false);
    
			thanthai.Sl = 3;
			thanthai.Nam = "namcongan";
       
        }
        else if (pDt.Day == 24 && pDt.Month == 12)
        {
            content = "Ngày lễ giáng sinh";
            author = "Noel";
            pTra.GetChild(0).GetComponent<tk2dSprite>().SetSprite("giangsinh");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(false);
            pTra.GetChild(0).GetChild(5).gameObject.SetActive(false);
          
        }
        else if (pDt.Day == 25 && pDt.Month == 12)
        {
            content = "Giáng sinh an lành";
            author = "Noel";

            pTra.GetChild(0).GetComponent<tk2dSprite>().SetSprite("giangsinh");
            pTra.GetChild(0).GetChild(4).gameObject.SetActive(false);
            pTra.GetChild(0).GetChild(5).gameObject.SetActive(false);
        }
        else
        {
            chon = pDt.Day + (pDt.Month * 31);
            if (mang[chon].Contains("@"))
            {
                int chiso = mang[chon].IndexOf("@");
                if (chiso != -1)
                {
                
                    content = "" + mang[chon].Substring(0, chiso);
                    author = "" + mang[chon].Substring(chiso + 1);
                }
            }

            chon = UnityEngine.Random.Range(0, 6);
            if (chon <= 2)
            {
                pTra.GetChild(0).GetChild(4).gameObject.SetActive(false);
                pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
				thanthai.Sl = 4;
            }
            else if (chon <= 4)
            {
                pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);
                pTra.GetChild(0).GetChild(5).gameObject.SetActive(false);
				thanthai.Sl = 3;
            }
            else
            {
                pTra.GetChild(0).GetChild(4).gameObject.SetActive(true);
                pTra.GetChild(0).GetChild(5).gameObject.SetActive(true);
				thanthai.Sl = 2;
            }

        }

		pTra.GetChild(0).GetChild(2).GetComponent<tk2dTextMesh>().text = content;
        if (author.Length > 14)
            author = author.Substring(0, 13)+"...";
        pTra.GetChild(0).GetChild(3).GetComponent<tk2dTextMesh>().text = author;

 

		if (pCheckok == 1) {

			pTra.GetChild(0).GetComponent<tk2dSprite>().SetSprite(""+tbL.Bg);

			if (tbL.Sl == 2) {

				pTra.GetChild (0).GetChild (4).GetComponent<tk2dSprite> ().SetSprite ("" + tbL.Nam);
				pTra.GetChild (0).GetChild (4).gameObject.SetActive (true);

				pTra.GetChild (0).GetChild (5).gameObject.SetActive (true);
				pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("" + tbL.Nu);

			} else if (tbL.Sl == 3) {
				pTra.GetChild (0).GetChild (4).GetComponent<tk2dSprite> ().SetSprite ("" + tbL.Nam);
				pTra.GetChild (0).GetChild (4).gameObject.SetActive (true);
				pTra.GetChild (0).GetChild (5).gameObject.SetActive (false);
			} else {

			
				pTra.GetChild (0).GetChild (4).gameObject.SetActive (false);

				pTra.GetChild (0).GetChild (5).gameObject.SetActive (true);
				pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("" + tbL.Nu);
			}

		} else if (pCheckok == -1) {

			pTra.GetChild(0).GetComponent<tk2dSprite>().SetSprite(""+tbR.Bg);

			if (tbR.Sl == 2) {

				pTra.GetChild (0).GetChild (4).GetComponent<tk2dSprite> ().SetSprite ("" + tbR.Nam);
				pTra.GetChild (0).GetChild (4).gameObject.SetActive (true);

				pTra.GetChild (0).GetChild (5).gameObject.SetActive (true);
				pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("" + tbR.Nu);

			} else if (tbR.Sl == 3) {
				pTra.GetChild (0).GetChild (4).GetComponent<tk2dSprite> ().SetSprite ("" + tbR.Nam);
				pTra.GetChild (0).GetChild (4).gameObject.SetActive (true);
				pTra.GetChild (0).GetChild (5).gameObject.SetActive (false);
			} else {


				pTra.GetChild (0).GetChild (4).gameObject.SetActive (false);

				pTra.GetChild (0).GetChild (5).gameObject.SetActive (true);
				pTra.GetChild (0).GetChild (5).GetComponent<tk2dSprite> ().SetSprite ("" + tbR.Nu);
			}
		}
	
	
	
	}

    public void doUpdateColor(Transform pTra ,Color pColor)
    {
        pTra.GetChild(4).GetComponent<tk2dSprite>().color = pColor;
        pTra.GetChild(0).GetChild(0).GetComponent<tk2dTextMesh>().color = pColor;
        pTra.GetChild(0).GetChild(1).GetComponent<tk2dTextMesh>().color = pColor;
     
    }
	
	// Update is called once per frame
	void Update () {

        if (LichController.instance.currentState == LichController.State.NGAY)
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
                if (xxxx > 120)
                {
                    today = today.AddDays(-1);
                    doSetDate(oHomNay, today, ref tbC, 1);
                    doSetDate(oHomQua, today.AddDays(-1), ref tbL, 0);
                    doSetDate(oNgayMai, today.AddDays(1), ref tbR, 0);
                }
                else if (xxxx < -120)
                {
                    today = today.AddDays(1);
                    doSetDate(oHomNay, today, ref tbC, -1);
                    doSetDate(oHomQua, today.AddDays(-1), ref tbL, 0);
                    doSetDate(oNgayMai, today.AddDays(1), ref tbR, 0);
                }


        


                this.transform.position = startPosition;
            }
        }


	}
}
