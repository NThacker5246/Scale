using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			other.GetComponent<GunChanger>().swap = true;
			Destroy(gameObject);
		}
	}
}
