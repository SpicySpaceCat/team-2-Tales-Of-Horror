﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBrain : MonoBehaviour
{

    Transform target;
    Transform x;
    Transform y;
    Transform z;
    Transform selfx;
    Transform selfz;
    float range;
    public float meleeRange = 3.0f;
    public float projectileRange = 8.0f;
    public float triggerDistance = 12.0f;
    private NavMeshAgent agent;
    //public AImelee aimelee;
    public float playerDis;
    public float health = 100;
    //public GameObject meleeHitbox;
    public Transform spawnPoint;
    float timeToShoot;
    public float fireRate = 3.0f;
    public bool chase = false;
    //public float rayLength = 100.0f;
    public GameObject attackMove;
    public GameObject deadBody;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);

        if (gameObject.CompareTag("AI Melee"))
        {
            range = meleeRange;
            attackMove = gameObject.GetComponent<AImelee>().meleeHitbox;
            fireRate = 4.0f;
        }
        else if (gameObject.CompareTag("AI Projectile"))
        {
            range = projectileRange;
            attackMove = gameObject.GetComponent<AIprojectile>().projectile;
            fireRate = 5.0f;
        }
        /*if (gameObject.CompareTag("AI HitScan"))
        {
            range = 12.0f;
        }*/

        float x = target.position.x;
        float y = 1.0f;
        float z = target.position.z;

        float distance = Vector3.Distance(gameObject.transform.position, target.position);
        playerDis = distance;
        agent.SetDestination(new Vector3(x, y, z));

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

        if (distance < triggerDistance)
        {
            chase = true;
        }

        if (chase)
        {
            agent.speed = 3.5f;
        }

        if (distance < range)
        {
            agent.speed = 0.0f;



            if (Time.time > timeToShoot)
            {
                Instantiate(attackMove, spawnPoint.position, spawnPoint.rotation);
                timeToShoot = Time.time + fireRate;
            }
        }

    }

    void DeadMeat()
    {
        float x = transform.position.x;
        float y = 0.25f;
        float z = transform.position.z;
        Vector3 bodyPosition = new Vector3(x, y, z);

        Instantiate(deadBody, bodyPosition, transform.rotation);
    }

    void OnTriggerStay(Collider col)
    {
        //Jillian Attacks
        if (col.gameObject.tag == "Vial")
        {
            health -= 20;
            if (health <= 0)
            {
                Debug.Log("Dead");
                DeadMeat();
                Destroy(gameObject);
            }
        }

        if (col.gameObject.tag == "Fireball")
        {
            health -= 60;
            if (health <= 0)
            {
                Debug.Log("Dead");
                DeadMeat();
                Destroy(gameObject);
            }
        }

        //Johnny Attacks
        if (col.gameObject.tag == "Fists")
        {
            health -= 10;
            if (health <= 0)
            {
                Debug.Log("Dead");
                DeadMeat();
                Destroy(gameObject);
            }
        }

        if (col.gameObject.tag == "Sword")
        {
            health -= 40;
            if (health <= 0)
            {
                Debug.Log("Dead");
                DeadMeat();
                Destroy(gameObject);
            }
        }

        if (col.gameObject.tag == "Sword Slash")
        {
            health -= 30;
            if (health <= 0)
            {
                Debug.Log("Dead");
                DeadMeat();
                Destroy(gameObject);
            }
        }

        if (col.gameObject.tag == "Axe")
        {
            health -= 60;
            if (health <= 0)
            {
                Debug.Log("Dead");
                DeadMeat();
                Destroy(gameObject);
            }
        }

		if (col.gameObject.tag == "Imp Attack")
		{
			health -= 10;
			if (health <= 0)
			{
				Debug.Log("Dead");
				DeadMeat();
				Destroy(gameObject);
			}
		}
    }
}