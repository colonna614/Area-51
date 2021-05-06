using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimTomHealthDisplay : MonoBehaviour
{
    public Image TimhealthBar;
    float maxHealth = 300;
    public Image TimSprite;
    public Image TimBarDeplete;
    public Image TimBarRemain;
    public Image enemySprite;
    public Text enemyRemaining;
    public GameObject Tim;
    public GameObject Obstacles;

    public Text OGwaves;
    public Text NEWwaves;

    public Image TomhealthBar;
    public Image TomSprite;
    public Image TomBarDeplete;
    public Image TomBarRemain;
    public GameObject Tom;

    public GameObject boss2Contain;

    public bool reset = false;
    void Update()
    {
        TimhealthBar.fillAmount = TimsBehavior.timsHealth / maxHealth;
        TomhealthBar.fillAmount = TomsBehavior.tomsHealth / maxHealth;

        if (boss2Contain.activeSelf == true)
        {
            TimBarDeplete.enabled = true;
            TimBarRemain.enabled = true;
            TimSprite.enabled = true;
            enemySprite.enabled = false;
            enemyRemaining.enabled = false;
            Obstacles.SetActive(false);
            NEWwaves.enabled = true;
            OGwaves.enabled = false;
            TomBarDeplete.enabled = true;
            TomBarRemain.enabled = true;
            TomSprite.enabled = true;
            
        }
        if (TimsBehavior.timsHealth <= 0 && TomsBehavior.tomsHealth <= 0 && reset == false )
        {
            TimBarDeplete.enabled = false;
            TimBarRemain.enabled = false;
            TimSprite.enabled = false;
            TomBarDeplete.enabled = false;
            TomBarRemain.enabled = false;
            TomSprite.enabled = false;
            enemySprite.enabled = true;
            enemyRemaining.enabled = true;
            Obstacles.SetActive(true);
            NEWwaves.enabled = false;
            OGwaves.enabled = true;
            reset = true;

        }
    }
}
