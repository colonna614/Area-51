using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unlockKnifeUp : MonoBehaviour
{
    public Text knifeKillNum;
    public Text knifeKills;
    public static int numOfKnifeKills = 0;
    public Image unlock;
    public static bool knifeUnlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        knifeUnlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfKnifeKills < 50)
        {
            knifeKillNum.text = numOfKnifeKills + "/50";
        }
        else
        {
            knifeKills.enabled = false;
            knifeKillNum.enabled = false;
            unlock.enabled = false;
            knifeUnlocked = true;
        }
    }
}
