using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausedGame : MonoBehaviour {

	public GameObject pauseMenu;
	public JillianCharacterController jillian;
	public JohnnyCharacterController johnny;
	// Use this for initialization
	void Awake()
	{
		pauseMenu.SetActive (false);
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				pauseMenu.SetActive (true);
				jillian.enabled = false;
				johnny.enabled = false;
				Cursor.visible = true;
				Screen.lockCursor = false;
			}
			else
			{
				Time.timeScale = 1;
				pauseMenu.SetActive (false);
				jillian.enabled = true;
				johnny.enabled = true;
				Cursor.visible = false;
				Screen.lockCursor = true;
			}
		}
	}
}
