using UnityEngine;
using System.Collections;

public class SoundCTL : MonoBehaviour {

    #region Singleton
    private static SoundCTL _instance;

    public static SoundCTL Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<SoundCTL>();
            return _instance;
        }
    }
    #endregion

    public AudioClip[] arrAudioClip;

    public void PlayChamNuoc()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[0]);
     
        // ok = false;
    }


   

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
