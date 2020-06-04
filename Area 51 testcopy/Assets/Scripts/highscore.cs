using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscore : MonoBehaviour
{
    Text highScore;
    public GameObject drive;


    void Start()
    {
        highScore = GetComponent<Text>();
        //drive.gameObject.SetActive(false);
    }



    void Update()
    {
        highScore.text = "High Score: " + GameOverReset.HighScore.ToString();
    }

}
