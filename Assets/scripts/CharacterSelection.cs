using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour {
	public GameObject jillian;
	public GameObject johnny;
	public GameObject jillianUI;
	public GameObject johnnyUI;
	public GameObject enemies; //Add all enemies present within the stage into an Empty Game Object
	public GameObject buttons;

	void Awake()
	{
		Cursor.visible = true;
		Screen.lockCursor = false;
		enemies.SetActive (false);
	}
	// Use this for initialization
	void Start () {
		jillian.SetActive (false);
		johnny.SetActive (false);
		jillianUI.SetActive (false);
		johnnyUI.SetActive (false);
		buttons.SetActive (true);
	}

	public void Johnny()
	{
		johnny.SetActive (true);
		johnnyUI.SetActive (true);
		enemies.SetActive (true);
		buttons.SetActive (false);
	}

	public void Jillian()
	{
		jillian.SetActive (true);
		jillianUI.SetActive (true);
		enemies.SetActive (true);
		buttons.SetActive (false);
	}
}
