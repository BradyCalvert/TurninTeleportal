using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour {

  public UnityEngine.UI.Button button1;
  public UnityEngine.UI.Button button2;
  public UnityEngine.UI.Button button3;
  // Use this for initialization
  void Start () {
    
    button2.enabled=false;
    button3.enabled = false;

  }
	
	// Update is called once per frame
	void Update () {
    if (PlayerPrefs.GetInt("completed_level") == 2)
    {
      button2.enabled=true;
    }
    if (PlayerPrefs.GetInt("completed_level") == 3)
    {
      button3.enabled = true;
      button2.enabled = true;
    }
  }

}

