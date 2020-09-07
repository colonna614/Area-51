using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheShop : MonoBehaviour
{
    public static int currency = 0;
    public GameObject theShopOBJ;
    public Image ShotgunSprite;
    public Text Number3;
    public Image ShotSoldOut;
    public Image ARSprite;
    public Text Number4;
    public Image ARSoldOut;
    public Image healthSoldOut;
    public Image KnifeUpSprite;
    public Image knifeSoldOut;
    public Image ammoUpSoldOut;
    public Image doubleAmmo;
    public int initHealthPrice = 60;
    public static int currentHealthPrice = 0;
    public int ammoIncrease = 15;
    public bool ammoUpgrade = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealthPrice = initHealthPrice;
    }

    // Update is called once per frame
    void Update()
    {
        if (ammoUpgrade)
        {
            ammoIncrease = 30;
        }
        if (theShopOBJ.activeSelf == true)
        {
            MoveAndShootMouse.canShoot = false;
            Move2D.OutOfShop = false;
            if (Input.GetKeyDown(KeyCode.H) && currency >= currentHealthPrice && HealthScript.health < 100)
            {
                SoundManagerScript.PlaySound("SFX/ChaChing");
                HealthScript.health += 10;
                currency -= currentHealthPrice;
                currentHealthPrice += 10;
            }
            if (Input.GetKeyDown(KeyCode.B) && currency >= 80)
            {
                SoundManagerScript.PlaySound("SFX/ChaChing");
                AmmoCount.ammo += ammoIncrease;
                currency -= 80;
                UnlockAmmoUp.numOfAmmoBought += 1;
            }
            if (Input.GetKeyDown(KeyCode.K) && currency >= 300 && unlockKnifeUp.knifeUnlocked == true)
            {
                SoundManagerScript.PlaySound("SFX/ChaChing");
                MoveAndShootMouse.purchasedKnife = true;
                KnifeUpSprite.enabled = true;
                knifeSoldOut.enabled = true;
                currency -= 300;
            }
            if (Input.GetKeyDown(KeyCode.O) && currency >= 300 && UnlockAmmoUp.ammoUnlocked == true)
            {
                SoundManagerScript.PlaySound("SFX/ChaChing");
                ammoUpgrade = true;
                ammoUpSoldOut.enabled = true;
                doubleAmmo.enabled = true;
                currency -= 300;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && currency >= 600 && MoveAndShootMouse.purchasedShotgun == false)
            {
                SoundManagerScript.PlaySound("SFX/ChaChing");
                MoveAndShootMouse.purchasedShotgun = true;
                ShotgunSprite.enabled = true;
                Number3.enabled = true;
                ShotSoldOut.enabled = true;
                AmmoCount.ammo += 30;
                currency -= 600;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && currency >= 1000 && MoveAndShootMouse.purchasedAR == false)
            {
                SoundManagerScript.PlaySound("SFX/ChaChing");
                MoveAndShootMouse.purchasedAR = true;
                ARSprite.enabled = true;
                Number4.enabled = true;
                ARSoldOut.enabled = true;
                AmmoCount.ammo += 45;
                currency -= 1000;
            }
            if (HealthScript.health >= 100)
            {
                healthSoldOut.enabled = true;
            }
            else
            {
                healthSoldOut.enabled = false;
            }
        }
        
    }
}
