using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKeyDoor : MonoBehaviour {
	GameObject player;
	bool playerKeyCheck;
	public bool blueKey = false;
	//public JillianCharacterController;
	//public JohnnyCharacterController;
	public string name;


	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		/*if (player.name == "Jillian") {
			playerKeyCheck = player.GetComponent<JillianCharacterController> ().redKeyStat;
		} 
		else 
		{
			playerKeyCheck = player.GetComponent<JohnnyCharacterController> ().redKeyStat;
		}*/

		/*if (GameObject.Find("Jillian"))
		{
			playerScript = player.GetComponent<JillianCharacterController>();
		}

		if (GameObject.Find("Johnny"))
		{
			playerScript = player.GetComponent<JohnnyCharacterController>();
		}*/
		//StartCoroutine(DoorDelayTime());
	}

	void Update()
	{
		player = GameObject.FindWithTag("Player");
		if (player.name == "Jillian") {
			playerKeyCheck = player.GetComponent<JillianCharacterController> ().blueKeyStat;
		} 
		else 
		{
			playerKeyCheck = player.GetComponent<JohnnyCharacterController> ().blueKeyStat;
		}

		if (playerKeyCheck == true) 
		{
			blueKey = true;
		}

		/*if(johnnyPlayerScript.redKeyStat)
        {
            redKey = true;
        }*/

		/*if(Input.GetKeyUp(KeyCode.E))
		{
			useButton = false;
		}

		if(Input.GetKeyDown(KeyCode.E))
		{
			useButton = true;
		}*/

		float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

		if (distance < 5 && blueKey)
		{
			transform.Translate(0, Time.deltaTime * 5, 0, Space.World);
			if (transform.position.y > 5.0f)
			{
				transform.position = new Vector3(transform.position.x, 5.0f, transform.position.z);
			}
			//anim.enabled = true;
			//DoorDelayTime();
			//anim.enabled = false;
		}

		if (distance > 5)
		{
			transform.Translate(0, -Time.deltaTime * 5, 0, Space.World);
			if (transform.position.y < 1.5f)
			{
				transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
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