using UnityEngine;
using System.Collections;

public class MaxGame : MonoBehaviour {

	public tk2dUIItem btnDiemCao;
	public tk2dTextMesh txtDiemCao;
	int maxlevel = 0;

	public void setData()
	{
		maxlevel = DataController.GetHightScore();
		txtDiemCao.text = "Điểm Lớn Nhất:" + maxlevel;
	}

	public void btnDiemCao_OnClick()
	{
		PopupController.instance.HideMaxGame ();
		PopupController.instance.ShowMainGame ();
	}

	// Use this for initialization
	void Start () {
		btnDiemCao.OnClick += btnDiemCao_OnClick;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
