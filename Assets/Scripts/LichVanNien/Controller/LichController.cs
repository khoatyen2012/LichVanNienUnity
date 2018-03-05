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

    public void btnNgay_OnClick()
    {
        currentState = State.NGAY;
        LichNgay.Today();
        LichNgay.transform.position = new Vector3(00, 0f, LichNgay.transform.position.z);

        LichThang.transform.position = new Vector3(0f, 1000f, LichThang.transform.position.z);
    }

    public void btnThang_OnClick()
    {
        currentState = State.THANG;

        LichThang.transform.position = new Vector3(0f, 0f, LichThang.transform.position.z);

        LichNgay.transform.position = new Vector3(0, 1000f, LichNgay.transform.position.z);
    }


    public void btnTienich_OnClick()
    {
        currentState = State.TIENICH;
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
