using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openscript : MonoBehaviour
{
    public Animator anim;
	public bool redKey = false;
	public player playerScript;
	public bool useButton = false;

    void Start()
    {
        anim.enabled = false;
		//playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent;
		StartCoroutine(DoorDelayTime());
    }

	void Update()
	{
		if(playerScript.redKeyStat)
		{
			redKey = true;
		}

		/*if(Input.GetKeyUp(KeyCode.E))
		{
			useButton = false;
		}*/

		if(Input.GetKeyDown(KeyCode.E))
		{
			useButton = true;
		}


	}

    void OnTriggerEnter(Collider col)
    {
		
		if (col.gameObject.tag == ("Player") && useButton == true && redKey == true) {
			anim.enabled = true;
			DoorDelayTime();
			//anim.enabled = false;
		} 
    }

	IEnumerator DoorDelayTime()
	{
		yield return new WaitForSeconds(4);
		useButton = false;
	}
}

