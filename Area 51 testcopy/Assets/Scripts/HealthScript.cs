using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    Image healthBar;
    float maxHealth = 100f;
    public static float health;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(health);
        healthBar.fillAmount = health / maxHealth;
    }
}
