using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openscript : MonoBehaviour
{
    //public Animator anim;
	GameObject player;
	//public bool redKey = false;
	//public player playerScript;
	//public bool useButton = false;

    void Start()
    {
		player = GameObject.FindWithTag("Player");
        //anim.enabled = false;
		//playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent;
		//StartCoroutine(DoorDelayTime());
    }

	void Update()
	{
		/*if(playerScript.redKeyStat)
		{
			redKey = true;
		}

		if(Input.GetKeyUp(KeyCode.E))
		{
			useButton = false;
		}

		if(Input.GetKeyDown(KeyCode.E))
		{
			useButton = true;
		}*/

		float distance = Vector3.Distance (gameObject.transform.position, player.transform.position);

		if (distance < 5 /*&& redKey == true*/) {
			transform.Translate (0, Time.deltaTime * 5, 0, Space.World);
			if(transform.position.y > 5.0f)
			{
				transform.position = new Vector3 (transform.position.x, 5.0f, transform.position.z);
			}
			//anim.enabled = true;
			//DoorDelayTime();
			//anim.enabled = false;
		}

		if (distance > 5) {
			transform.Translate (0, -Time.deltaTime * 5, 0, Space.World);
			if(transform.position.y < 1.5f)
			{
				transform.position = new Vector3 (transform.position.x, 1.5f, transform.position.z);
			}
		}
	}

    /*void OnTriggerStay(Collider col)
    {
		float distance = Vector3.Distance (gameObject.transform.position, player.transform.position);
		if (col.gameObject.tag == ("Player") && useButton == true && distance < 6 && redKey == true) {
			//anim.enabled = true;
			//DoorDelayTime();
			//anim.enabled = false;
		} 
    }*/

	/*IEnumerator DoorDelayTime()
	{
		yield return new WaitForSeconds(4);
		useButton = false;
	}*/
}

