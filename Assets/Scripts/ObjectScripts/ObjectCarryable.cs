using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
	NONE,
	GREEN,
	BLUE,
	RED,
	YELLOW
}


public class ObjectCarryable : MonoBehaviour {

  //Enumeration type;
  public PickupType type;
  public float despawnTime;

  public void StartTimer()
  {
    //Is there a despawn time?
		if(despawnTime>=0f)
		{
    //destroy the object after despawn time
			Destroy(this.gameObject,despawnTime);
		}
  }
}
