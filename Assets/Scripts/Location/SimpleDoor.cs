using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDoor : MonoBehaviour
{
	public bool inColl;
	public bool Door;
	public Animator anim;

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			inColl = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			inColl = false;
		}
	}

	void Update(){
		if(inColl){
			if(Input.GetKeyDown(KeyCode.E)){
				Door = !Door;
				anim.SetBool("door", Door);
			}
		}
	}
}
