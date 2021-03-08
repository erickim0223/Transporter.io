using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLEVEL1 : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("LEVEL1"); //uses level name
    }
}
