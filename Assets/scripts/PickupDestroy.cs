using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDestroy : MonoBehaviour {

	void OnTriggerEnter(Collider Col)
	{
		if(Col.gameObject.tag == "Player")
		{
			Destroy (gameObject);
		}
	}
}
