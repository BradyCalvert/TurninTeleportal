using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsMakingChildren : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
            other.transform.position = transform.parent.position;
    }
}
