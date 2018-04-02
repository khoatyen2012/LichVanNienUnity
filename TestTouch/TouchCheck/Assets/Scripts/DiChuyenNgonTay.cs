using UnityEngine;
using System.Collections;

public class DiChuyenNgonTay : MonoBehaviour {

	public tk2dTextMesh txtNumber;
	int number = 1;

	void Awake()
	{
		Application.targetFrameRate = 30;
		QualitySettings.vSyncCount = -1;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	public float speed;
	void Update()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

			// Move object across XY plane
			transform.Translate(touchDeltaPosition.x * speed, this.transform.position.y, 0);
		}else if (Input.touchCount != 0 && Input.GetTouch(0).phase 
			== TouchPhase.Ended)
		{
			number++;
			txtNumber.text = "" + number;
		}
	}
}
