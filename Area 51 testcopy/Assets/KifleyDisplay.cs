using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KifleyDisplay : MonoBehaviour
{
    Image healthBar;
    float maxHealth = 300f;
    public Image KifleyAngrySprite;
    public Image KifleySprite;
    public Image KifleyBarDeplete;
    public Image KifleyBarRemain;
    public Image enemySprite;
    public Text enemyRemaining;
    public GameObject Kifley;
    public GameObject Obstacles;
    public GameObject Boss3Contain;
    public bool reset = false;

// Start is called before the first frame update
void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Boss3Behavior.bossHealth / maxHealth;

        if (Boss3Contain.activeSelf == true)
        {
            KifleyBarDeplete.enabled = true;
            KifleyBarRemain.enabled = true;
            KifleySprite.enabled = true;
            enemySprite.enabled = false;
            enemyRemaining.enabled = false;
            Obstacles.SetActive(false);
        }
        if (Boss3Behavior.bossHealth < 150 && Boss3Behavior.bossHealth >0)
        {
            KifleyAngrySprite.enabled = true;
            KifleySprite.enabled = false;
        }
        if (Boss3Behavior.bossHealth <= 0 && reset == false)
        {
            KifleyAngrySprite.enabled = false;
            KifleyBarDeplete.enabled = false;
            KifleyBarRemain.enabled = false;
            KifleySprite.enabled = false;
            enemySprite.enabled = true;
            enemyRemaining.enabled = true;
            Obstacles.SetActive(true);
            reset = true;
        }
    }
}
