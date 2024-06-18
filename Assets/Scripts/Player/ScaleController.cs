using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleController : MonoBehaviour
{
	public float currentScale = 1f;
	public Contr c;
	public Text scl;

	void Start(){
		StartCoroutine("stop");
	}

	void Update(){
		if(Input.GetKey(KeyCode.F)){
			currentScale += 0.01f;
		}
		if(Input.GetKey(KeyCode.G)){
			currentScale -= 0.01f;
		}
		if(transform.localScale.x != currentScale){
			transform.localScale = new Vector3(currentScale, currentScale, currentScale);
		}

		currentScale = Mathf.Clamp(currentScale, 0.01f, 20f);
		string s = $"Scale: {currentScale}";
		if(scl.text != s){
			scl.text = s;
		}
	}

	IEnumerator stop(){
		while(true){
			yield return new WaitForSeconds(Random.Range(1, 120));
			print("Stop:");
			c.isStatic = true;
			yield return new WaitForSeconds(1f);
			c.isStatic = false;
		}
	}
}
