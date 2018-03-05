using UnityEngine;
using System.Collections;

public class MoveLichThang : MonoBehaviour {


    public float speed;
    Vector3 startPosition;
    public tk2dTextMesh txttest;


	// Use this for initialization
	void Start () {
        startPosition = this.transform.position;
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
                


                txttest.text = "" + xxxx;


                this.transform.position = new Vector3(startPosition.x,0f,startPosition.z);
            }
        }
	}
}
