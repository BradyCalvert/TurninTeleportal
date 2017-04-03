using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

  public AudioSource soundSFX;
  public AudioSource gameBackGround;
  public AudioSource menuBackGround;
  public AudioSource random;
  public static SoundManager instance = null;

  // Use this for initialization
  void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    else if (instance != this)
      Destroy(gameObject);

    DontDestroyOnLoad(gameObject);

    //play background music

  }
  public void PlayGameBackground(AudioClip soundToPlay)
  {
    gameBackGround.clip = soundToPlay;
    gameBackGround.Play();
  }
  public void PlaySFX(AudioClip soundToPlay)
  {
    //Assign soundFX audio source to the clip
    soundSFX.clip = soundToPlay;

    //play the clip
    soundSFX.Play();
  }
  public void PlayMenuBackground(AudioClip soundToPlay)
  {
    menuBackGround.clip = soundToPlay;
    menuBackGround.Play();
  }
  public void Random(AudioClip soundToPlay)
  {
    random.clip = soundToPlay;
    random.Play();
  }
}