using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jukebox : MonoBehaviour {

    public bool fadingOut = false;
    public AudioSource level1;
    public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (fadingOut == true)
        {
            level1.volume = level1.volume - Time.deltaTime * speed;
        }
        else
        {
            level1.volume = level1.volume + Time.deltaTime * speed;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            fadingOut = !fadingOut;
        }
    }
}
