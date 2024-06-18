using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealPoint : MonoBehaviour
{
	public int HP = 20;
	public bool isEnemy;
	public Text t;

	void OnTriggerEnter(Collider other){
		if(other.tag == "Bullet" && isEnemy){
			HP -= 2;
		}
	}

	public void Damage(int n){
		HP -= n;
	}

	void Update(){
		if(HP <= 0){
			if(isEnemy){
				Destroy(gameObject);
			} else {
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}

		if(!isEnemy){
			string hps = $"HP: {HP}";
			if(t.text != hps){
				t.text = hps;
			}
		}
	}
}
