using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public Canvas pauseMenu;
    public Button resumeButton;
    public Button saveButton;
    public Button loadButton;
    //public Button cancelButton;
    public Button quitButton;
    //public FirstPersonController fps;
    public Animator pauseButtonsAnimator;
    //public RectTransform pauseButtons;
    //public short step;

    private Vector3 currentPosition;

	// Use this for initialization
	void Start () {
        pauseMenu.enabled = false;
        currentPosition = new Vector3();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            TogglePauseMenu();
            //fps.enabled = !pauseMenu.enabled;
        }

        //Debug.Log(currentPosition);
        //Debug.Log(pauseButtons.position + " " + pauseButtons.localPosition);

/*
        if (pauseMenu.enabled)
        {
            if (!pauseButtons.localPosition.Equals(currentPosition))
            {
                //pauseButtons.position = Vector3.MoveTowards(pauseButtons.position, currentPosition, 5f * Time.deltaTime);
                float x = pauseButtons.localPosition.x;

                if (currentPosition.x < 0)
                {
                    x -= step;
                }
                else if(currentPosition.x > 0)
                {
                    x += step;
                }

                pauseButtons.localPosition = new Vector3(x, 0f, 0f);
            }

        }
*/
    }

    void TogglePauseMenu()
    {
        pauseMenu.enabled = !pauseMenu.enabled;
        ToggleTimeScale();
    }

    void ToggleTimeScale()
    {
        if (pauseMenu.enabled)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void TestLeft()
    {
        //Debug.Log("D�d� est une L�gende !");
        //currentPosition = new Vector3(-200f, 0f, 0f);
        int pos = -1;
        pauseButtonsAnimator.SetInteger("Position", pos);
    }

    public void TestRight()
    {
        //Debug.Log("D�d� est une L�gende !");
        //currentPosition = new Vector3(200f, 0f, 0f);
        int pos = 1;
        pauseButtonsAnimator.SetInteger("Position", pos);
    }

    public void ResumePress()
    {
        //Debug.Log("D�d� est une L�gende !");
        //currentPosition = new Vector3(0f, 0f, 0f);
        int pos = 0;
        pauseButtonsAnimator.SetInteger("Position", pos);
    }

    public void QuitPress()
    {
        //Application.LoadLevel("scn_MainMenu");
        SceneManager.LoadScene("scn_MainMenu");
    }

}
