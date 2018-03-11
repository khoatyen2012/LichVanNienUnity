using UnityEngine;
using System.Collections;

public class ItemThang : MonoBehaviour {



	public void setDate(string pDuong,string pAm,int pType)
	{
		this.transform.GetChild (0).GetComponent<tk2dTextMesh> ().text = ""+pDuong;
		this.transform.GetChild (1).GetComponent<tk2dTextMesh> ().text = ""+pAm;
		if (pType == 2) {
			this.transform.GetChild (0).GetComponent<tk2dTextMesh> ().color = new Color (1, (float)69 / 255, 0, 1);
			this.GetComponent<tk2dSprite> ().SetSprite ("light_card");
		} else if (pType == 3) {
			this.transform.GetChild (0).GetComponent<tk2dTextMesh> ().color =  new Color(0, (float)153 / 255, 1, 1);
			this.GetComponent<tk2dSprite> ().SetSprite ("oringer_card");
        }
        else if (pType == 4)
        {
            this.transform.GetChild(0).GetComponent<tk2dTextMesh>().color = new Color(1, (float)69 / 255, 0, 1);
            this.GetComponent<tk2dSprite>().SetSprite("oringer_card");
        }
        else
		{
			this.transform.GetChild (0).GetComponent<tk2dTextMesh> ().color = new Color(0, (float)153 / 255, 1, 1);
			this.GetComponent<tk2dSprite> ().SetSprite ("light_card");
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
