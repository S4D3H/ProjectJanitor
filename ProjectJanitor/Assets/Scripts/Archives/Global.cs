using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Global : MonoBehaviour {

    public static Transform cursor;
    private Image cursorImage;
    public static Transform selectedCursor;
    private Image selectedCursorImage;
    //public static TextMesh textName;
    //public static string currentPlayer;

	// Use this for initialization
	void Awake () {
        cursor = GameObject.Find("Cursor").transform;
        cursorImage = cursor.GetComponent<Image>();
        selectedCursor = GameObject.Find("SelectedCursor").transform;
        selectedCursorImage = selectedCursor.GetComponent<Image>();
        //textName = GameObject.Find("TextName").GetComponent<TextMesh>();

        cursorImage.enabled = false;
        selectedCursorImage.enabled = false;
        //cursor.GetComponent<Renderer>().enabled = false;
        //selectedCursor.GetComponent<Renderer>().enabled = false;
    }

	// Update is called once per frame
	void Update () {
        	
	}
}
