using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPitResetPlayer : MonoBehaviour {

  public Transform respawnPos;
  public AudioClip weird;

  private void OnTriggerEnter(Collider other)
  {
        //collide w/ player?
        if (other.CompareTag("Player"))
        {

      SoundManager.instance.Random(weird);
            //set players position to respawn position
            other.transform.position = respawnPos.position;
        }
    Time.timeScale = Time.timeScale+1;
  }
}
