using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeepScore : MonoBehaviour
{
    public GameObject textGameObject;
    static public int score = 0;        // these variables are static so they get sent to the next scene

    void Start()
    {
        UpdateScore();
    }

    void Update()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        Text scoreTextB = textGameObject.GetComponent<Text>();
        scoreTextB.text = "Deliveries: " + score + " / 5";
        if (score == 5)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

}