using UnityEngine;
using System.Collections;

public class MoveLichNgay : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	
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
            
        }


	}
}
