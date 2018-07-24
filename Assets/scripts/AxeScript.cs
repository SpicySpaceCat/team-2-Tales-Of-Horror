using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour {

	public float speed = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * speed);
		Destroy(gameObject, 4);
	}

	void OnTriggerEnter(Collider col)
	{
		Destroy (gameObject);
	}
}
