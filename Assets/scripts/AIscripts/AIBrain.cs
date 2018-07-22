using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBrain : MonoBehaviour {

	Transform target;
	Transform x;
	Transform y;
	Transform z;
	Transform selfx;
	Transform selfz;
	float range;
	private NavMeshAgent agent;
	//public AImelee aimelee;

	public float health = 100;
	public GameObject meleeHitbox;
	public Transform spawnPoint;
	float timeToShoot;
	public float fireRate = 3.0f; 
	public bool chase = false;
	//public float rayLength = 100.0f;

	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag("Player").transform;
		agent = gameObject.GetComponent<NavMeshAgent>();
		//AImelee aimelee = gameObject.GetComponent<AImelee>().Attack;
	}
	
	// Update is called once per frame
	void Update () {

		if (gameObject.CompareTag("AI Melee"))
		{
			range = 3.0f;
		}
		/*if (gameObject.CompareTag("AI Projectile"))
		{
			range = 12.0f;
		}
		if (gameObject.CompareTag("AI HitScan"))
		{
			range = 12.0f;
		}*/

		transform.LookAt(target);
		float x = target.position.x;
		float y = 1.0f;
		float z = target.position.z;

		float distance = Vector3.Distance (gameObject.transform.position, target.position);

		if (distance < 20) {
			agent.SetDestination (new Vector3 (x, y, z));
		} 
		else 
		{
			
		}

		/*RaycastHit hit;
		Ray rayHit = new Ray(transform.position, transform.forward);
		Debug.DrawRay (transform.position, transform.forward * rayLength);

		if (Physics.Raycast(rayHit, out hit, rayLength)) 
		{
			if (hit.collider.tag == "Player") 
			{
				chase = true;
				rayLength = 0;
			}
		}*/

		/*if (distance < 10) 
		{
			agent.enabled = !agent.enabled;
		}*/

		if (distance < range) {
			agent.speed = 0.0f;

			if (Time.time > timeToShoot) 
			{
				Instantiate (meleeHitbox, spawnPoint.position, spawnPoint.rotation);
				timeToShoot = Time.time + fireRate;
			}
		} 
		else 
		{
			agent.speed = 3.5f;
		}
	}

	void OnTriggerStay (Collider col)
	{
		if (col.gameObject.tag == "Vial") {
			health -= 20;
			if (health <= 0) {
				Debug.Log ("Dead");
				Destroy (gameObject);
			}
		}
	}
}
