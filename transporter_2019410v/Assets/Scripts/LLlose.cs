﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LLlose : MonoBehaviour
{
  public Animator transition;
  
  public float transitionTime = 1f;

  public void PlayGame()
  {
    StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
  }
  
  IEnumerator LoadLevel(int levelIndex)
  {
    //play animation
    transition.SetTrigger("Start");
    //Wait 
    yield return new WaitForSeconds(transitionTime);
    //Load scene 
    SceneManager.LoadScene(levelIndex);
  }
}
