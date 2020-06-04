using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryMenu : MonoBehaviour
{ 
    public GameObject InventoryMenu;
    private bool invOpen = true;
    public static bool canOpenInv = true;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpenInv)
        {

            if (Input.GetKeyDown(KeyCode.I) && invOpen == false)
            {
                Time.timeScale = 0;
                InventoryMenu.SetActive(true);
                invOpen = true;
            }
            else if (Input.GetKeyDown(KeyCode.I) && invOpen == true)
            {
                Time.timeScale = 1;
                InventoryMenu.SetActive(false);
                invOpen = false;
            }
        }
    }
}
