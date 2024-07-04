using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunChanger : MonoBehaviour
{	
	public bool swap;
	public int isHOT;

	public GameObject[] guns;

	void Update(){
		if(swap){
			for(int i = 0; i < guns.Length; i++) {
				if(Input.GetKeyDown(KeyCode.Alpha1 + i)){
					guns[isHOT].SetActive(false);
					isHOT = i;
					guns[isHOT].SetActive(true);
					return;
				}
			}
		}
	}
}
