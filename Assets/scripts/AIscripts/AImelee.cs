using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AImelee : MonoBehaviour {

	public GameObject meleeHitbox;
	public Transform spawnPoint;
	public float fireRate = 3.0f; 
	float timeToShoot;

	void Update()
	{
		
	}

	// Update is called once per frame
	public void Attack()
	{
		Instantiate (meleeHitbox, spawnPoint.position, spawnPoint.rotation);
		/*if (Time.time > timeToShoot) 
		{
			Instantiate (meleeHitbox, spawnPoint.position, spawnPoint.rotation);
			timeToShoot = Time.time + fireRate;
		}*/
	}
}
