using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaryLarryHealthDisplay : MonoBehaviour
{
    Image healthBar;
    float maxHealth = 200f;
    public Image larrySprite;
    public Image larryBarDeplete;
    public Image larryBarRemain;
    public GameObject Larry;

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
        }
        if (Boss1Behavior.bossHealth <= 0)
        {
            larryBarDeplete.enabled = false;
            larryBarRemain.enabled = false;
            larrySprite.enabled = false;
        }
    }
}
