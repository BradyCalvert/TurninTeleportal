using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCarryObject : MonoBehaviour {
  public float distance;
  public float smooth;
  public LayerMask playerLayer;
  public GameObject mainCamera;
  private GameObject carriedObject;
  public bool isCarrying;

	// Use this for initialization
	void Start () {
    //set the mainCamera variable to store the main camera
		mainCamera=Camera.main.gameObject;

		
	}
	
	// Update is called once per frame
	void Update () {
    //Is player carrying an object?
		if (isCarrying == true) {
			//Carry(carried object)CheckDrop
			Carry (carriedObject);
			CheckDrop ();

		} 
		else 
		{

			Pickup ();
		}
		DrawPickup ();
		
	}
  void RotateObject()
  {
    //Rotate carried object 5,10,15

  }

    void Carry(GameObject objCarry)//GameObject)
    {
        //obj null?
        if (objCarry == null)
        {
            //set isCarrying to false
            isCarrying = false;
            return;

            //leave the method
        }

        //set position of object ot infront of the camera, And smooth movement
        objCarry.transform.position = Vector3.Lerp(objCarry.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
        //objCarry.transform.position = mainCamera.transform.position + mainCamera.transform.forward * distance;

        //Set rotation of object to Quaternion.Identity
        objCarry.transform.rotation = Quaternion.identity;
 
  }

  void Pickup()
  {
        //Did we press E?
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);

            //create a raycast hit to store information if we hit an objext
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10f, ~playerLayer))
            {
                //Did we hit an object ignoring the player?
                if (hit.transform.CompareTag("Carryable"))
                {

                    //Set isCarrying to true
                    isCarrying = true;

                    //Assign the object we are now carrying to the carriedObject
                    carriedObject = hit.transform.gameObject;

                    //Turn off gravity on the object
                    hit.transform.GetComponent<Rigidbody>().useGravity = false;

                    //Start the timer on the ObjectCarryable component on the object
                    carriedObject.GetComponent<ObjectCarryable>().StartTimer();
                }
            }
        }

  }

  void CheckDrop()
  {
    //Did user press E?
    if(Input.GetKeyDown(KeyCode.E))
        {
            DropObject();
        }

        //DropObject()
  }

  void DropObject()
  {
        //set isCarrying to false
        isCarrying = false;

        //turn gravity back on for the object
        carriedObject.GetComponent<Rigidbody>().useGravity = true;

        //set carried object to null
        carriedObject = null;
  }

  void DrawPickup()
  {
    //Create a ray starting at the position and going to the direction of the vametas forward
		Ray ray=new Ray(mainCamera.transform.position,mainCamera.transform.forward);

    //create a raycasthit t store iformation we need in an object
		RaycastHit hit;
    //Did we hit the objec tignoring the player??
		if (Physics.Raycast (ray, out hit, 10f, ~playerLayer)) {
			//Did we hit a carruable object??
			if (hit.transform.CompareTag ("Carryable")) {
				//Draw a green ray
				Debug.DrawRay (ray.origin, ray.direction * 10f, Color.green);
			} 
			else 
			{
				//Draw a yellow ray
				Debug.DrawRay (ray.origin, ray.direction * 10f, Color.yellow);
				//Draw a red ray(n
			}

		} 
		else 
		
		{
			Debug.DrawRay (ray.origin, ray.direction * 10f, Color.red);
		}
  
	}
}
