using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour {
	public GameObject jillian;
	public GameObject johnny;
	public GameObject jillianUI;
	public GameObject johnnyUI;
	public GameObject buttons;

	void Awake()
	{
		//Time.timeScale = 0;
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
		buttons.SetActive (false);
	}

	public void Jillian()
	{
		jillian.SetActive (true);
		jillianUI.SetActive (true);
		buttons.SetActive (false);
	}
}
