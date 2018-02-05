using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashedbyContact : MonoBehaviour {

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Floor") 
		{
			return;
		}
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
