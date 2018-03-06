using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	void CreateItem(float positionX, float positionY,Transform pParent)
	{

		ItemThang levelCreate = itemPrefab.Spawn<ItemThang>
			(
				new Vector3(positionX, positionY, 35f),
				itemPrefab.transform.rotation
			);



        levelCreate.transform.parent = pParent;


	}

    public void Createlevl(int sl, float pStartX, float pStartY,Transform pParent)
	{
        float positionCreateX = pStartX;
        float positionCreateY = pStartY;
		for (int i = 1; i <= sl; i++)
		{
            CreateItem(positionCreateX, positionCreateY, pParent);
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
        setEmptyChild();
		Createlevl (40,startX,startY,TraGiua);
        Createlevl(40, startX-580, startY, TraTrai);
        Createlevl(40, startX+580, startY, TraPhai);
	}


	// Use this for initialization
	void Start () {
        startPosition = this.transform.position;
        TraTrai = this.gameObject.transform.GetChild(0).transform;
        TraGiua = this.gameObject.transform.GetChild(1).transform;
        TraPhai = this.gameObject.transform.GetChild(2).transform;
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
