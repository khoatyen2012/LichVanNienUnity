using UnityEngine;
using System.Collections;

public class LichController : MonoBehaviour {


    public enum State
    {
        NGAY,
        THANG,
        TIENICH

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

    public MoveLichNgay LichNgay;
    public MoveLichThang LichThang;
    public TienIch DoiNgay;

	void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus) {

		} else {
			currentState = State.NGAY;
			LichNgay.Today();
			LichNgay.transform.position = new Vector3(00, 0f, LichNgay.transform.position.z);

			LichThang.transform.position = new Vector3(0f, 1000f, LichThang.transform.position.z);
            DoiNgay.transform.position = new Vector3(0f, 1000f, DoiNgay.transform.position.z);

            btnNgay.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(1, 0, (float)227 / 255, 1);
            btnThang.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(0, 0, 0, 1);
            btnTienich.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(0, 0, 0, 1);
		}
	}

    public void btnNgay_OnClick()
    {
        currentState = State.NGAY;
        LichNgay.Today();
        LichNgay.transform.position = new Vector3(00, 0f, LichNgay.transform.position.z);

        LichThang.transform.position = new Vector3(0f, 1000f, LichThang.transform.position.z);
        DoiNgay.transform.position = new Vector3(0f, 1000f, DoiNgay.transform.position.z);

        btnNgay.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(1, 0, (float)227 / 255, 1);
        btnThang.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(0, 0, 0, 1);
        btnTienich.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(0, 0, 0, 1);
    }

    public void btnThang_OnClick()
    {
        currentState = State.THANG;

        LichThang.transform.position = new Vector3(0f, 0f, LichThang.transform.position.z);
		LichThang.setData ();
        LichNgay.transform.position = new Vector3(0, 1000f, LichNgay.transform.position.z);
        DoiNgay.transform.position = new Vector3(0f, 1000f, DoiNgay.transform.position.z);

        btnThang.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(1, 0, (float)227 / 255, 1);
        btnNgay.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(0, 0, 0, 1);
        btnTienich.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(0, 0, 0, 1);
    }


    public void btnTienich_OnClick()
    {
        currentState = State.TIENICH;
        DoiNgay.transform.position = new Vector3(0f, 0f, DoiNgay.transform.position.z);

        LichThang.transform.position = new Vector3(0f, 1000f, LichThang.transform.position.z);
        LichNgay.transform.position = new Vector3(00, 1000f, LichNgay.transform.position.z);


        btnTienich.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(1, 0, (float)227 / 255, 1);
        btnThang.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(0, 0, 0, 1);
        btnNgay.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(0, 0, 0, 1);
    }




	// Use this for initialization
	void Start () {
        btnNgay.OnClick += btnNgay_OnClick;
        btnThang.OnClick += btnThang_OnClick;
        btnTienich.OnClick += btnTienich_OnClick;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
