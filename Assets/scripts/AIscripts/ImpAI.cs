using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ImpAI : MonoBehaviour {
	Transform target;
	private GameObject[] enemy;
	private GameObject closestEnemy;
	GameObject player;
	Transform x;
	Transform y;
	Transform z;
	public float enemyDis;
	private NavMeshAgent agent;
	public Transform mainPoint;
	public float health = 30;
	public float triggerDistance = 12.0f;
	public float meleeRange = 2.0f;
	public GameObject attackMove;
	GameObject otherImp;
	public bool chase = false;
	public float fireRate = 0.5f;
	float timeToShoot;
	public Transform spawnPoint;
	private float minDistance = float.MaxValue;
	private bool readyNow = true;

	// Use this for initialization
	void Start () {
		//enemy = GameObject.FindGameObjectsWithTag("ImpAttack");
		player = GameObject.FindWithTag("Player");
		mainPoint = GameObject.Find("Imp Stay Point").transform;
		agent = gameObject.GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update () {
		agent.speed = 8;

		if (readyNow) 
		{
			//StartCoroutine(DelayedFind());
			FindEnemies ();
			FindClosestEnemy ();

			float distanceI = Vector2.Distance (transform.position, closestEnemy.transform.position);

			if (distanceI < triggerDistance) 
			{
				chase = true;
			}
			else if (distanceI > triggerDistance) 
			{
				chase = false;
			}

			if (chase == true) 
			{
				transform.LookAt (closestEnemy.transform);
				agent.SetDestination (new Vector3 (closestEnemy.transform.position.x, closestEnemy.transform.position.y, closestEnemy.transform.position.z));
				if (distanceI < meleeRange) 
				{
					if (Time.time > timeToShoot) 
					{
						Instantiate (attackMove, spawnPoint.position, spawnPoint.rotation);
						timeToShoot = Time.time + fireRate;
					}
				}
			}
			else if (chase == false)
			{
				transform.LookAt (player.transform);
				agent.SetDestination (new Vector3 (mainPoint.transform.position.x, mainPoint.transform.position.y, mainPoint.transform.position.z));
			}
		}



		/*player = GameObject.FindWithTag("Player");
		enemy = GameObject.FindGameObjectsWithTag("ImpAttack");
		float x = mainPoint.position.x;
		float y = 1.0f;
		float z = mainPoint.position.z;

        transform.LookAt(player.transform);
        agent.SetDestination(new Vector3(x, y, z));

		float distance = Vector3.Distance (gameObject.transform.position, enemy[].transform.position);
		enemyDis = distance;

		for (int i = 0; i < enemy.Length; i++) {
			float distance = Vector3.Distance (gameObject.transform.position, enemy [i].transform.position);
			enemyDis [i] = distance;

			if (distance < triggerDistance) {
				transform.LookAt (enemy [i].transform);
				chase = true;
				float xe = enemy [i].transform.position.x;
				float ye = 1.0f;
				float ze = enemy [i].transform.position.z;
				agent.SetDestination (new Vector3 (xe, ye, ze));
			} else {
				transform.LookAt(player.transform);
				agent.SetDestination(new Vector3(x, y, z));
			}
			if (distance < meleeRange) 
			{
				agent.speed = 0.0f;



				if (Time.time > timeToShoot) {
					Instantiate (attackMove, spawnPoint.position, spawnPoint.rotation);
					timeToShoot = Time.time + fireRate;
				}
			}
		}

		if (chase) 
		{
			transform.LookAt (enemy);
			agent.speed = 10.0f;
		}

		if (enemyDis < meleeRange) 
		{
			agent.speed = 0.0f;



			if (Time.time > timeToShoot) {
				Instantiate (attackMove, spawnPoint.position, spawnPoint.rotation);
				timeToShoot = Time.time + fireRate;
			}
		}*/
	}

	/*private IEnumerator DelayedFind()
	{
		//readyNow = false;
		//yield return new WaitForSeconds (0.01f);
		//readyNow = true;
		//FindEnemies ();
		//FindClosestEnemy ();
	}*/

	private void FindEnemies()
	{
		enemy = GameObject.FindGameObjectsWithTag("ImpAttack");
	}

	private void FindClosestEnemy()
	{
		foreach (GameObject e in enemy)
		{
			float distance = Vector2.Distance (transform.position, e.transform.position);
			if (distance < minDistance) 
			{
				minDistance = distance;
				closestEnemy = e;
			}
		}


	}
}