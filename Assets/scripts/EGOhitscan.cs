using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EGOhitscan : MonoBehaviour {
	public float rayLength = 10.0f;
	public GameObject hitPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray rayHit = new Ray(transform.position, transform.forward);
		Debug.DrawRay (transform.position, transform.forward * rayLength);

		if (Physics.Raycast(rayHit, out hit, rayLength)) 
		{
			if (hit.collider.tag == "Player") 
			{
				Instantiate(hitPrefab, hit.point, Quaternion.identity);
			}
		}
	}
}
