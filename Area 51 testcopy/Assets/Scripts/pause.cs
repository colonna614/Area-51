﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    bool isPaused = false;
    public GameObject pauseOBJ;
    public GameObject theShopOBJ;
    public GameObject youSureOBJ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (theShopOBJ.activeSelf == false && youSureOBJ.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.P) && isPaused == false)
            {
                MoveAndShootMouse.canShoot = false;
                Time.timeScale = 0;
                isPaused = true;
                pauseOBJ.SetActive(true);
                Boss4Behavior.isPaused = true;
            }
            else if (Input.GetKeyDown(KeyCode.P) && isPaused == true)
            {
                MoveAndShootMouse.canShoot = true;
                Time.timeScale = 1;
                isPaused = false;
                pauseOBJ.SetActive(false);
                Boss4Behavior.isPaused = false;
            }
        }

    }
}
