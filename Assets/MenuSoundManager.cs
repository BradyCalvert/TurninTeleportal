using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundManager : MonoBehaviour {

  
  public AudioSource menuBackGround;
  public void PlayMenuBackground(AudioClip soundToPlay)
  {
    menuBackGround.clip = soundToPlay;
    menuBackGround.Play();
  }


}
