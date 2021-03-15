using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public GameObject textGameObject;
    public float timeRemaining = 100;

    // Update is called once per frame
    void Update()
    {
        Text scoreTextB = textGameObject.GetComponent<Text>();
        scoreTextB.text = "Timer: " + (int)timeRemaining;
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            //make timer red when running out of time
            if(timeRemaining < 31)
            {
                GetComponent<Text>().color = Color.red;
            }
        } else {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
