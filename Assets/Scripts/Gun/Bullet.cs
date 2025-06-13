using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float As;
	public float Damage;
	public Rigidbody rb;
	public Collider col;
	
	/*
	void OnEnable(){
		Vector3 startMove = transform.forward * As;
		rb.velocity = startMove;
	}

	void Start(){
		//rb = GetComponent<Rigidbody>();
		Vector3 startMove = transform.forward * As;
		rb.velocity = startMove;
	}


	void Awake(){
		//rb = GetComponent<Rigidbody>();
		Vector3 startMove = transform.forward * As;
		rb.velocity = startMove;
	}
	*/
	public void OnEnable(){
		Vector3 startMove = transform.forward * As;
		rb.velocity = startMove;
	}

	IEnumerator resetGun(){
		yield return new WaitForSeconds(0.005f);
		col.isTrigger = false;
	}
}
