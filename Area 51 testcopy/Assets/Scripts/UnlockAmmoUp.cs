using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockAmmoUp : MonoBehaviour
{
    public Text ammoBoughtNum;
    public Text ammoBoughtText;
    public static int numOfAmmoBought = 0;
    public Image unlock;
    public static bool ammoUnlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        ammoUnlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfAmmoBought < 30)
        {
            ammoBoughtNum.text = numOfAmmoBought + "/30";
        }
        else
        {
            ammoBoughtText.enabled = false;
            ammoBoughtNum.enabled = false;
            unlock.enabled = false;
            ammoUnlocked = true;
        }
    }
}
