using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentHealthPrice : MonoBehaviour
{
    Text CurrentHealth;


    void Start()
    {
        CurrentHealth = GetComponent<Text>();
    }



    void Update()
    {
        CurrentHealth.text = TheShop.currentHealthPrice.ToString();
    }
}
