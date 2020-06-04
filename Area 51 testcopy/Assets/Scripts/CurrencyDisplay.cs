using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyDisplay : MonoBehaviour
{
    Text money;


    void Start()
    {
        money = GetComponent<Text>();
    }



    void Update()
    {
        money.text = ""+ TheShop.currency;
    }
}
