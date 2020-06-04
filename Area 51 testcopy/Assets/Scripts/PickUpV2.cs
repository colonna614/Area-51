using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpV2 : MonoBehaviour
{
    public Text healthFull;
    public bool pickUpAllowed = false;
    public GameObject crate;
    public GameObject drive;

    void Start()
    {
        crate.gameObject.SetActive(true);
        //drive.gameObject.SetActive(false);
       //pickUpText.GetComponent<Text>().enabled = false;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManagerScript.PlaySound("SFX/CrateOpening");
            PickUpCrate();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //SoundManagerScript.PlaySound("SFX/CrateOpening");
            PickUpCrate();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            healthFull.enabled = false;
        }
    }


    public void PickUpCrate()
    {
        if (gameObject.tag == "Health" && HealthScript.health <100)
        {
            HealthScript.health += 10f;
            Destroy(gameObject);
        }
        else if (gameObject.tag == "Health" && HealthScript.health == 100)
        {
            healthFull.enabled = true;
        }
        else if (gameObject.tag == "Ammo")
        {
            AmmoCount.ammo += 15;
            Destroy(gameObject);
        }      
    }

   /* public void WinCondition()
    {
        if (Scoring.score >= 500)
        {
            drive.gameObject.SetActive(true);

        }
    }
    */
}