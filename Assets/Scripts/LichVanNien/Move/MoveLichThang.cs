using UnityEngine;
using System.Collections;

public class MoveLichThang : MonoBehaviour {


    public float speed;
    Vector3 startPosition;

	public ItemThang itemPrefab;
	public float startX;
	public float distanceX;
	public float startY;
	public float distanceY;

	void CreateItem(float positionX, float positionY, int vitri)
	{

		ItemThang levelCreate = itemPrefab.Spawn<ItemThang>
			(
				new Vector3(positionX, positionY, 35f),
				itemPrefab.transform.rotation
			);



		levelCreate.transform.parent = this.gameObject.transform.GetChild(1).transform;


	}

	public void Createlevl(int sl)
	{
		float positionCreateX = startX;
		float positionCreateY = startY;
		for (int i = 1; i <= sl; i++)
		{
			CreateItem(positionCreateX, positionCreateY, i);
			positionCreateX += distanceX;
			if (i % 7 == 0)
			{
				positionCreateX = startX;
				positionCreateY -= distanceY;
			}
		}
	}

	public void setData()
	{
		Createlevl (40);
	}


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
                


           


                this.transform.position = new Vector3(startPosition.x,0f,startPosition.z);
            }
        }
	}
}
