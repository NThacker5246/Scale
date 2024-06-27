using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScene : MonoBehaviour
{
	public Transform[] spots;
	public float speed;
	public float sens;
	public int i;

	private float rX;
	private float rY;

	void Update(){
		if(transform.position == spots[i].position){
			i += 1;
		} else {
			transform.position = Vector3.MoveTowards(transform.position, spots[i].position, Time.deltaTime*speed);
		}

		float MouseX = Input.GetAxis("Mouse X")*Time.deltaTime*sens;
		float MouseY = Input.GetAxis("Mouse Y")*Time.deltaTime*sens;

		rY += MouseX;
		rX += MouseY;

		transform.eulerAngles = new Vector3(rX, rY, 0f);
	}
}
