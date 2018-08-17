using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

    public string level1Name;
    public string instructions;
    public string mainMenu;

    // Use this for initialization
    void Start () {
		
	}

    public void BeginButton()
    {
        SceneManager.LoadScene(level1Name);
    }

    public void InstructionsButton()
    {
        SceneManager.LoadScene(instructions);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
