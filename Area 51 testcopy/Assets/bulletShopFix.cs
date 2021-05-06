using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletShopFix : MonoBehaviour
{
    Text playerammo;


    void Start()
    {
        playerammo = GetComponent<Text>();
    }
    void Update()
    {
        playerammo.text = "- " + AmmoCount.ammo.ToString();
    }
}
