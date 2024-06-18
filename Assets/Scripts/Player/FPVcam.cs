using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPVcam : MonoBehaviour
{
	public Contr player;
	private Transform pos;
	private Vector3 velocity = Vector3.zero;

	void Start(){
		pos = player.transform;
	}

	void Update(){
		transform.position = pos.position;
	}

	void LateUpdate(){
		Vector3 targetRotation = new Vector3(player.X, pos.eulerAngles.y, pos.eulerAngles.z);
		transform.eulerAngles = Vector3.SmoothDamp(transform.eulerAngles, targetRotation, ref velocity, 0);
	}
}
