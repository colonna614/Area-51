using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public static float currentDamage = 0;
    public static string playerStatus = "okay";
    public static string bossStatus = "okay";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStatus == "dead")
        {
            Debug.Log("Player Dead");
        }
        if (bossStatus == "dead")
        {
            Debug.Log("Boss Dead");
        }
    }
}
