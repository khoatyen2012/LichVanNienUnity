using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public tk2dUIItem btnPlay;
	public tk2dTextMesh txtNumber;
	int number = 1;


	public void onClick_Play()
	{
		number++;
		txtNumber.text = "" + number;
	}

	void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus) {
			
		} else {
			number=1;
			txtNumber.text = "" + number;
		}
	}

	// Use this for initialization
	void Start () {
	
		btnPlay.OnClick += onClick_Play;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
