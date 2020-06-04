using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    Text playerScore; 
    public static int score;
    public GameObject drive;


    void Start()
    {
        playerScore = GetComponent<Text>();
        //drive.gameObject.SetActive(false);
    }



    void Update()
    {
        playerScore.text = "Score: " + score.ToString();
    }




}
