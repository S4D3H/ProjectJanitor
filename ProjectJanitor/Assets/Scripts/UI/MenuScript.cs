using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startGame;
    public Button exitGame;

    // Use this for initialization
    void Start() {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startGame = startGame.GetComponent<Button>();
        exitGame = exitGame.GetComponent<Button>();
        quitMenu.enabled = false;
    }

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startGame.enabled = false;
        exitGame.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startGame.enabled = true;
        exitGame.enabled = true;
    }

    public void StartLevel()
    {
        //Application.LoadLevel("scn_CharSelection");
        SceneManager.LoadScene("scn_CharSelection");
    }

    public void LoadMenu()
    {
        //Application.LoadLevel("scn_LoadMenu");
        SceneManager.LoadScene("scn_LoadMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
