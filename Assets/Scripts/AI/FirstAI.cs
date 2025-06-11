using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FirstAI : MonoBehaviour
{
	[SerializeField] private NavMeshAgent agent;
	[SerializeField] private Transform player;
	[SerializeField] private Transform bullet;

	[SerializeField] private float timeStart;
	private float timeCur;

	void Start(){
		timeCur = timeStart;
	}

	void Update(){
		agent.destination = player.position;
		if(timeCur <= 0){
			bullet.position = transform.position;
			bullet.gameObject.SetActive(true);
			timeCur = timeStart;
		} else {
			timeCur -= Time.deltaTime;
		}
	}
	/*
	public float speed;
	public Transform player;
	public float StopDist;
	public float retDist;

	public float timeStart;
	private float timeCur;

	public GameObject bullet;

	void Start(){
		timeCur = timeStart;
	}

	void Update(){
		if(Vector3.Distance(transform.position, player.position) > StopDist) {
			transform.position = Vector3.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
		} else if(Vector3.Distance(transform.position, player.position) < retDist){
			transform.position = Vector3.MoveTowards(transform.position, player.position, speed*Time.deltaTime*-1);
		} else {
			//Vector3 c = player.position - transform.position;
			//Mathf.Atan2(c.y, c.x) * Mathf.Rad2Deg;
			//Debug.DrawLine(transform.position, transform.forward, Color.yellow);
		}

		if(timeCur <= 0){
			Instantiate(bullet, transform.position, Quaternion.identity);
			timeCur = timeStart;
		} else {
			timeCur -= Time.deltaTime;
		}
	}
	*/
}
