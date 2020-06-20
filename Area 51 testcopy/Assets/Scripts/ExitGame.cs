using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public GameObject youSure;
    public GameObject TheShopOBJ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            youSure.SetActive(true);
            MoveAndShootMouse.canShoot = false;
            Time.timeScale = 0;
            Boss4Behavior.isPaused = true;
        }
        if (youSure && Input.GetKeyDown(KeyCode.Y))
        {
            Application.Quit();
        }
        else if (youSure && Input.GetKeyDown(KeyCode.N) && TheShopOBJ.activeSelf == true)
        {
            youSure.SetActive(false);
        }
        else if (youSure && Input.GetKeyDown(KeyCode.N) && TheShopOBJ.activeSelf == false)
        {
            youSure.SetActive(false);
            MoveAndShootMouse.canShoot = true;
            Time.timeScale = 1;
            Boss4Behavior.isPaused = false;
        }
    }
}
