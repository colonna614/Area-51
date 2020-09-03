using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarcusDisplay : MonoBehaviour
{
    Image healthBar;
    float maxHealth = 350f;
    public Image MarcusSprite;
    public Image MarcusBarDeplete;
    public Image MarcusBarRemain;
    public Image enemySprite;
    public Text enemyRemaining;
    public GameObject Marcus;
    public GameObject Obstacles;
    public GameObject Boss4Contain;

    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    void Update()
    {
        healthBar.fillAmount = Boss4Behavior.bossHealth / maxHealth;

        if (Boss4Contain.activeSelf == true)
        {
            MarcusBarDeplete.enabled = true;
            MarcusBarRemain.enabled = true;
            MarcusSprite.enabled = true;
            enemySprite.enabled = false;
            enemyRemaining.enabled = false;
            Obstacles.SetActive(false);
        }

        if (Boss4Behavior.bossHealth <= 0)
        {
            MarcusBarDeplete.enabled = false;
            MarcusBarRemain.enabled = false;
            MarcusSprite.enabled = false;
            enemySprite.enabled = true;
            enemyRemaining.enabled = true;
            Obstacles.SetActive(true);
        }
    }
}