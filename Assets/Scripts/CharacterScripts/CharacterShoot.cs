using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterShoot : MonoBehaviour {

	public GameObject teleBall;
	public float shootForce=10f;
  public AudioClip shootSound;
	
	// Update is called once per frame
	void Update () {
    if(Input.GetKeyDown(KeyCode.M))
    {
      SoundManager.instance.gameBackGround.mute=true;

    }
    else if( Input.GetKeyDown(KeyCode.N))
    {
        SoundManager.instance.gameBackGround.mute = false;
    }
    if(Input.GetKeyDown(KeyCode.R))
    {
      Time.timeScale = 1;
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
		//ifplayer pressed LMB
		if(Input.GetMouseButtonDown(0))
		{
      SoundManager.instance.PlaySFX(shootSound);
      //	create a  ray from camera position in irection camera nwas facing
      Ray rayOrigin=new Ray(Camera.main.transform.position, Camera.main.transform.forward);

		// 	create anew tele ball
			GameObject tempBall=Instantiate(teleBall, rayOrigin.origin,Quaternion.identity);
		// 	tell it tpo ignore collision with the plaer
			Physics.IgnoreCollision(tempBall.GetComponent<Collider>(),GetComponent<Collider>() );

			//Debug.Log (rayOrigin.direction + " direction " + (rayOrigin.direction * shootForce) + " other stuff");
			 
		//	add impluse force in the dir the camera is facing w/ added force
			tempBall.GetComponent<Rigidbody>().AddRelativeForce( rayOrigin.direction * shootForce,ForceMode.Impulse);

		// 	pass player reference to the balls teleport player script
			tempBall.GetComponent<TeleportBallTeleportPlayer>().player=this.gameObject;

		}

	}
}
