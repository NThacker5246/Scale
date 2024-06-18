using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
	public GameObject bullet;
	public Transform fcam;
	public int ammo;
	public int ammo1;
	public Text am;

	public float dt;
	public float cdt;

	void Start(){
		cdt = dt;
		ammo1 = ammo;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.R)){
			ammo = ammo1;
		}

		bool flag = false;

		if(Input.GetMouseButtonDown(0) && ammo > 0){
			flag = true;
			GameObject gm = Instantiate(bullet, fcam.position, Quaternion.Euler(fcam.eulerAngles));
			ammo -= 1;
			print(flag);
		}
		string str = $"Ammo: {ammo}";
		if(am.text != str){
			am.text = str;
		}
		if(flag == false) {
			if(cdt <= 0){
				if(Input.GetMouseButton(0) && ammo > 0){
					GameObject gm = Instantiate(bullet, fcam.position, Quaternion.Euler(fcam.eulerAngles));
					ammo -= 1;
					cdt = dt;
				}
			} else {
				cdt -= Time.deltaTime;
			}
		}
	}
}
