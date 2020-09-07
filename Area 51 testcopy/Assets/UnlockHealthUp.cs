using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockHealthUp : MonoBehaviour
{
    public Text HealthBoughtNum;
    public Text HealthBoughtText;
    public static int numOfHealthBought = 0;
    public Image unlock;
    public static bool healthUnlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        healthUnlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfHealthBought < 10)
        {
            HealthBoughtNum.text = numOfHealthBought + "/10";
        }
        else
        {
            HealthBoughtText.enabled = false;
            HealthBoughtNum.enabled = false;
            unlock.enabled = false;
            healthUnlocked = true;
        }
    }
}
