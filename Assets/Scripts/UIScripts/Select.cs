using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour {
  public AudioSource soundSFX;
  public AudioClip buttonClick;
  public MenuSoundManager soundManager;
  public void Start()
  {
    //PlayerPrefs.SetInt("completed_level", 1);
  }
  public void PlaySFX(AudioClip soundToPlay)
  {
    Invoke("ChangeScene", 1f);
    //Assign soundFX audio source to the clip
    soundSFX.clip = soundToPlay;

    //play the clip
    soundSFX.Play();
  }
  public void ChangeScene()
  {
    SceneManager.LoadScene("LevelSelect");
  }

}

