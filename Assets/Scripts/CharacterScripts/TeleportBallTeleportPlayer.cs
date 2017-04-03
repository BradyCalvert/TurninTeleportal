using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBallTeleportPlayer : MonoBehaviour {

	public GameObject player;
  public AudioClip teleportSound;
  public GameObject soundManager;
  public AudioClip sfx;

  // Use this for initialization
  void Start () {

		//Destroy this object after 3 secondes
		Destroy(this.gameObject,3.0f);
		
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision other)
	{
		//Collided wit other wall?
		if(other.transform.CompareTag("Wall") || other.transform.CompareTag("Platform")) //other.gameObject.tag=="wall" gonna be gone!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
			{
      //SoundManager.instance.PlaySFX(teleportSound);
			//Tele[port player to current position +1 unit in front of collision happoened
			player.transform.position=transform.position + other.contacts[0].normal * 1f;
			//Destroy(this.gameObject);


			}

		//destroy this object
		Destroy(this.gameObject);


	}
}
