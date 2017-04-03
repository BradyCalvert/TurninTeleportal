 using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public float timer;
    public UnityEngine.UI.Text text;
    string stringString = "Time";
    public TimeSpan time;


    // Use this for initialization
    void Start () {
        text = GetComponent<UnityEngine.UI.Text>();
    }
	
	// Update is called once per frame
	void Update () {
        timer=timer-Time.deltaTime;
        time = TimeSpan.FromSeconds(timer);

    if(timer<=0)
    {
      SceneManager.LoadScene("Level1");
    }


	}
    void OnGUI()
    {
        text.text = string.Format("{0:D2}m:{1:D2}s",time.Minutes,time.Seconds);
    }
}


