using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD_ShowPopup : MonoBehaviour {

    public float timeToStay;
    //public GameObject img;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.activeInHierarchy)
        {
            if (Time.time > timeToStay)
            {
                gameObject.SetActive(false);
            }
        }
	}

    public void Popup(float time)
    {
        timeToStay = Time.time + time;
        gameObject.SetActive(true);
    }
}
