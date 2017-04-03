using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





public class ObjectPortalChangeScenes : MonoBehaviour {

  public string sceneToLoad;
  public int currentLevel;
  
  private void OnTriggerEnter(Collider other)
  {
    //Tell scene manager to load sceneToLoad
    
        SceneManager.LoadScene(sceneToLoad);
    PlayerPrefs.SetInt("completed_level", currentLevel);
  }
}
