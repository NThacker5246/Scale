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
	public Contr Player;
	public Animator Achivement1;

	void OnTriggerEnter(Collider other){
		if(other.tag == "Bullet" && isEnemy){
			HP -= 2;
			if(Player.v3 > 0.01f){
				Achivement1.SetBool("Ach", true);
				StartCoroutine("end");
				return;
			}
		}
		if(other.tag == "BulletE" && !isEnemy){
			HP -= 2;
			if(Player.v3 > 0.01f){
				Achivement1.SetBool("Ach", true);
				StartCoroutine("end");
				return;
			}
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

	IEnumerator end(){
		yield return new WaitForSeconds(0.1f); 
		Achivement1.SetBool("Ach", false);
	}
}
