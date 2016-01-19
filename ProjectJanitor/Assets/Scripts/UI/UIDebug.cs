using UnityEngine;
using System.Collections;

public class UIDebug : MonoBehaviour {

    public Texture2D icon;
    private bool toggleBool = true;
    private int toolbarInt = 0;
    private string[] toolbarStrings = { "Toolbar1", "Toolbar2", "Toolbar3" };
    private int selectionGridInt = 0;
    private string[] selectionStrings = { "Grid 1", "Grid 2", "Grid 3", "Grid 4" };
    private float hSliderValue = 5.0f;

    void OnGUI()
    {
        //GUI.Label(new Rect(20, 20, 150, 30), "test");
        //GUI.Button(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 10, 150, 20), "Test Button");

        GUI.Box(new Rect(10, 10, 100, 90), "Loader Menu");
        if(GUI.Button(new Rect(20,40,80,20), "Lab 1"))
        {
            //Application.LoadLevel("Lab1");
            //GUI.Button(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 10, 150, 20), "Lab 1");
            print("Lab 1");
        }

        if(GUI.Button(new Rect(20,70,80,20), "Lab 2"))
        {
            //Application.LoadLevel("Lab2");
            //GUI.Button(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 10, 150, 20), "Lab 2");
            print("Lab 2");
        }
        /*
                if(GUI.Button(new Rect(200,40,100,50), icon))
                {
                    print("Unity Icon");
                }
        */

        toggleBool = GUI.Toggle(new Rect(120, 40, 80, 30), toggleBool, "Toggle");

        toolbarInt = GUI.Toolbar(new Rect(20, 110, 200, 20), toolbarInt, toolbarStrings);

        selectionGridInt = GUI.SelectionGrid(new Rect(20, 140, 200, 40), selectionGridInt, selectionStrings, 2);

        hSliderValue = GUI.HorizontalSlider(new Rect(200, 45, 120, 30), hSliderValue, 0.0f, 10.0f);

        GUI.Label(new Rect(260, 60, 50, 30), hSliderValue.ToString(".#"));



    }

}
