using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
	public float speed;

	public Transform player;
	private Vector3 target;
	private bool isGrounded;
	public Rigidbody rb;

	void OnEnable(){
		//player = GameObject.FindGameObjectWithTag("Player").transform;
		target = player.position;
	}

	void Update(){
		if(!isGrounded){
			transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime*speed);
		}
		if(transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z){
			DestroyTile();
		}
	}

	void OnTriggerEnter(Collider other){
		if(!isGrounded) {
			if(other.tag == "Player"){
				other.GetComponent<HealPoint>().Damage(2);
				gameObject.SetActive(false);
			} else if(other.tag == "Wall"){
				DestroyTile();
			}
		}
	}

	void DestroyTile(){
		//Destroy(gameObject);
		isGrounded = true;
		//rb.isKinematic = false;
		gameObject.SetActive(false);
	}
}
