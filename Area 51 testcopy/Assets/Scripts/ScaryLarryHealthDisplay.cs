using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaryLarryHealthDisplay : MonoBehaviour
{
    Image healthBar;
    float maxHealth = 300f;
    public Image larrySprite;
    public Image larryBarDeplete;
    public Image larryBarRemain;
    public Image enemySprite;
    public Text enemyRemaining;
    public GameObject Larry;
    public GameObject Obstacles;

    public bool reset = false;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Boss1Behavior.bossHealth / maxHealth;

        if (Larry.activeSelf == true)
        {
            larryBarDeplete.enabled = true;
            larryBarRemain.enabled = true;
            larrySprite.enabled = true;
            enemySprite.enabled = false;
            enemyRemaining.enabled = false;
            Obstacles.SetActive(false);
        }
        if (Boss1Behavior.bossHealth <= 0 && reset == false)
        {
            larryBarDeplete.enabled = false;
            larryBarRemain.enabled = false;
            larrySprite.enabled = false;
            enemySprite.enabled = true;
            enemyRemaining.enabled = true;
            Obstacles.SetActive(true);
            reset = true;

        }
    }
}
