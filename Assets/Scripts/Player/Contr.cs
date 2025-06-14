using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contr : MonoBehaviour
{
	public float a;
	public float v;
	public float sens;
	public float jf;
	public Rigidbody rb;
	public float Y;
	public float X;
	private Vector3 temp;
	public float v2;
	public Text pos;
	public Text vel;
	public float v3;
	public bool isStatic;

	void Start(){
		rb = GetComponent<Rigidbody>();
	}

	void Update(){
		if(!isStatic) {
			float mouseX = Input.GetAxis("Mouse X")*sens*Time.deltaTime;
			float mouseY = Input.GetAxis("Mouse Y")*sens*Time.deltaTime*-1;

			X += mouseY;
			Y += mouseX;

			float Horizontal = Input.GetAxis("Horizontal")*a*Time.deltaTime*100;
			float Vertical = Input.GetAxis("Vertical")*a*Time.deltaTime*100;

			Vector3 movement = new Vector3(Horizontal, 0f, Vertical);
			movement = Quaternion.Euler(0f, Y, 0f) * movement;

			float vx = Mathf.Abs(transform.position.x) - Mathf.Abs(temp.x);
			float vz = Mathf.Abs(transform.position.z) - Mathf.Abs(temp.z);

			v2 = Mathf.Pow(vx, 2) + Mathf.Pow(vz, 2);
			float m2 = v*v;
			v3 = v2 + Mathf.Pow(Mathf.Abs(transform.position.y - temp.y), 2); 

			if(vel.text != $"Vel: {v3}"){
				vel.text = $"Vel: {v3}";
			}
			if(v2 <= m2){
				rb.AddForce(movement);			
			}

			if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
				rb.AddForce(new Vector3(0, 100*jf, 0));
			}

			temp = transform.position;
		}

		if(Input.GetKeyDown(KeyCode.I)){
			UpdateCursor();
		}

		string str = $"Pos: {Mathf.Floor(transform.position.x)}/{Mathf.Floor(transform.position.y)}/{Mathf.Floor(transform.position.z)}";
		if(pos.text != str){
			pos.text = str;
		}

		X = X % 360;
		Y = Y % 360;
		transform.eulerAngles = new Vector3(0f, Y, 0f);
	}


	public void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}


	public void UnlockCursor()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void UpdateCursor(){
		if(Cursor.visible){
			LockCursor();
		} else {
			UnlockCursor();
		}
	}

	public bool IsGrounded() {
    RaycastHit hit;
	    float rayLength = 1.1f; // Adjust based on your character's size
	    if (Physics.Raycast(transform.position, Vector3.down, out hit, rayLength)) {
	        return true;
	    }
	    return false;
	}
}
