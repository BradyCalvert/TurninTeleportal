using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectButtonPress : MonoBehaviour {

  public GameObject doorToOpen;
  public Animator anim;
  public bool stayOpen;
  public PickupType type;
  GameObject myObj;
  public AudioClip powerful;
  public bool pressed = false;

	void Update () {
        //is button pressed??
        if (pressed == true)
        {

            //is object null?
            if (myObj == null)
            {


                //ToggleDoor()
                ToggleDoor();
            }
        }
		
	}
  void ToggleDoor()
  {
        //Set off the trigger named "toggle" on the door's animator
        doorToOpen.GetComponent<Animator>().SetTrigger("toggle");


        //set off the trigger named "press" on the doors animator
        anim.SetTrigger("press");

        //toggle the pressed variable
        pressed = !pressed;
  }

  private void OnTriggerEnter(Collider other)
  {
        //did collide with Carryable?
        if (other.gameObject.CompareTag("Carryable") == true)
        {


            //Do we have a picup type?
            if (type != PickupType.NONE)
            {

                //Is the other object the correct type?
                if (other.GetComponent<ObjectCarryable>().type == type)
                {


                    //set myObj to the thing collided with ToggleDoor()
                    myObj = other.gameObject;
                    ToggleDoor();
                }
            }
            else
            {
                //set myObj to the thing collided with ToggleDoor()
                myObj = other.gameObject;
                ToggleDoor();
            }
        }
        //did colllide with player?
        if(other.CompareTag("Player"))
        {
            myObj = other.gameObject;
            ToggleDoor();
        }

  }

  private void OnTriggerExit(Collider other)
  {
        //We shouldn't stay open, correct?
        if (stayOpen == false)
        {
      //do we  have a type??
      if (type!=PickupType.NONE && other.gameObject.CompareTag("Player")==false)
            {
                if(other.GetComponent<ObjectCarryable>().type==type)
                {
                    myObj = null;
                    ToggleDoor();
                }
            }
            else
            {
                myObj = null;
                ToggleDoor();
            }
            if(other.gameObject.CompareTag("Player"))
            {
                myObj = null;
                ToggleDoor();
            }
         


        }
  }
}
