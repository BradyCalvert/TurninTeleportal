using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

	public float walkSpeed=6f;
	public float jumpSpeed = 4f;
	public float runSpeed = 12f;
	public float gravity=9.8f;
	public bool useGravity=true;

	Vector3 moveDirection=Vector3.zero;
	CharacterController charController;


	// Use this for initialization
	void Start () {

		//Get CharacterController component from this object
		charController = GetComponent<CharacterController>();

		LockCurser ();
		
	}
	
	// Update is called once per frame
	void Update () {

		//Is character controller grounded?
		if (charController.isGrounded == true) {
			//Debug.Log ("Debug.Log");
			//Set up mover direction with the input from the Horizontal X and vertical z axis
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

			//Change the axis to local coordinates

			moveDirection = transform.TransformDirection (moveDirection);

			//Apply Speed
			moveDirection *= GetSpeed ();
		


			//Pressing jump key
			///if(Input.GetKeyDown(KeyCode.Space)

			if (Input.GetButtonDown ("Jump")) {
				//Add jumpSpeed to moveDirection.Y
				moveDirection.y = jumpSpeed;



			}
		}

				
			//is character using gravity?
			if(useGravity==true)
			{

		//subtract gravity from moveDirection.Y accounting for frame-rate independence
				moveDirection.y-=(gravity)*Time.deltaTime;

			}

		//call Move emthod from the character controller
			charController.Move(moveDirection*Time.deltaTime);

			//press escape?
			if(Input.GetKeyDown(KeyCode.Escape))
				{
				LockCurser ();

				}

		
	}

	float GetSpeed()
	{

		//Is player pressing left shift?
		if (Input.GetKey (KeyCode.LeftShift)) {
			//return runSpeed
			return runSpeed;

		} 
		else 
		{
			//return walkSpeed
			return walkSpeed;
		}
	}

	void LockCurser()
	{
		//is curser current locked?
		if (Cursor.lockState == CursorLockMode.Locked)
		{
			//Set it to not be locked
			Cursor.lockState=CursorLockMode.None;
		} 
		else 
		{

		//set it to not be locked
			Cursor.lockState=CursorLockMode.Locked;
		}
		//toggle curser visibiltiy
		Cursor.visible=!Cursor.visible;
	}

}
