using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ImpAI : MonoBehaviour {
	Transform target;
	GameObject[] enemy;
	GameObject player;
	Transform x;
	Transform y;
	Transform z;
	public float enemyDis;
	private NavMeshAgent agent;
	public Transform mainPoint;
	public float health = 30;
	public float triggerDistance = 8.0f;
	public float meleeRange = 3.0f;
	public GameObject attackMove;
	GameObject otherImp;
	public bool chase = false;
	public float fireRate = 1.0f;
	float timeToShoot;
	public Transform spawnPoint;

	// Use this for initialization
	void Start () {
		enemy = GameObject.FindGameObjectsWithTag("ImpAttack");
		player = GameObject.FindWithTag("Player");
		mainPoint = GameObject.Find("Imp Stay Point").transform;
		agent = gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		enemy = GameObject.FindGameObjectsWithTag("ImpAttack");
		float x = mainPoint.position.x;
		float y = 1.0f;
		float z = mainPoint.position.z;

		for (int i = 0; i < enemy.Length; i++) {
			float distance = Vector3.Distance (gameObject.transform.position, enemy [i].transform.position);
			enemyDis = distance;

			if (distance < triggerDistance) {
				transform.LookAt (enemy[i].transform);
				chase = true;
				float xe = enemy [i].transform.position.x;
				float ye = 1.0f;
				float ze = enemy [i].transform.position.z;
				agent.SetDestination (new Vector3 (xe, ye, ze));
			} else {
				transform.LookAt (player.transform);
				agent.SetDestination (new Vector3 (x, y, z));
			}

			if (chase) {
				agent.speed = 20.0f;
			}

			if (distance < meleeRange) {
				agent.speed = 0.0f;



				if (Time.time > timeToShoot) {
					Instantiate (attackMove, spawnPoint.position, spawnPoint.rotation);
					timeToShoot = Time.time + fireRate;
				}
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{

	}
}