using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour {
	public GameObject startSound;
	public GameObject jillian;
	public GameObject johnny;
	public GameObject jillianUI;
	public GameObject johnnyUI;
	public GameObject enemies; //Add all enemies present within the stage into an Empty Game Object
	public GameObject gamePauser;
	public GameObject buttons;

	void Awake()
	{
		Cursor.visible = true;
		Screen.lockCursor = false;
		gamePauser.SetActive (false);
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
		Instantiate (startSound, transform.position, transform.rotation);
		johnny.SetActive (true);
		johnnyUI.SetActive (true);
		enemies.SetActive (true);
		gamePauser.SetActive (true);
		buttons.SetActive (false);
	}

	public void Jillian()
	{
		Instantiate (startSound, transform.position, transform.rotation);
		jillian.SetActive (true);
		jillianUI.SetActive (true);
		enemies.SetActive (true);
		gamePauser.SetActive (true);
		buttons.SetActive (false);
	}
}
