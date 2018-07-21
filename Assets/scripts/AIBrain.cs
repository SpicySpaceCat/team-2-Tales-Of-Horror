using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBrain : MonoBehaviour {

	Transform target;
	Transform x;
	Transform y;
	Transform z;
	private NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag("Player").transform;
		agent = gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target);
		float x = target.position.x;
		float y = 1.0f;
		float z = target.position.z;

		agent.SetDestination (new Vector3 (x, y, z));

		float distance = Vector3.Distance (gameObject.transform.position, target.position);

		if (distance < 4) {
			agent.speed = 0.0f;
		} 
		else 
		{
			agent.speed = 3.5f;
		}
	}
}
