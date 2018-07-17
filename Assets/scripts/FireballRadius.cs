using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballRadius : MonoBehaviour {

	public GameObject firesphere;
	public float speed = 10;
	public Transform objectPos;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * speed);
		Destroy(gameObject, 3);
	}

	void OnTriggerEnter(Collider col)
	{
		Instantiate (firesphere, objectPos.position, objectPos.rotation);
		Destroy (gameObject);
	}
}
