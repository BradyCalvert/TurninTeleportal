using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPushPlayer : MonoBehaviour {
  public Vector3 forceDirection;
  public float pushSpeed;

  private void OnTriggerEnter(Collider other)
  {
        //Collide with player?
        if (other.CompareTag("Player"))
        {

            //Turn off player gravity
            //CharacterMove.useGravity
            other.GetComponent<CharacterMove>().useGravity = false;
        }
  }

  private void OnTriggerStay(Collider other)
  {
        //colide with player?
        if (other.CompareTag("Player"))
        {

            //move player in forceDirection, accounting for piushSpeed and frame-rate independence

            //ChatacterControler.Move()
            other.GetComponent<CharacterController>().Move(forceDirection * pushSpeed * Time.deltaTime);
        }
  }

  private void OnTriggerExit(Collider other)
  {
        //collide wth player?
        if (other.CompareTag("Player"))
        {

            //turn on player gravity

            //CharacterMove.useGravity
            other.GetComponent<CharacterMove>().useGravity = true;
        }
  }

  private void OnDrawGizmos()
  {
        //set colour to cyan
        //draw ray from current position, in direction forceDirection
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, forceDirection);
    }


}
