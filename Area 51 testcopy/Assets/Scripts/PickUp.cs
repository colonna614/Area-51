using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public Text pickUpText;
    public bool pickUpAllowed;
    public GameObject crate;
    public GameObject drive;

    void Start()
    {
        crate.gameObject.SetActive(true);
        drive.gameObject.SetActive(false);
        pickUpText.GetComponent<Text>().enabled = false;
        drive.gameObject.SetActive(false);
    }

    void Update()
    {

        if (pickUpAllowed && Input.GetKeyDown(KeyCode.P))
        {
            PickUpCrate();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            //pickUpText.GetComponent<Text>().enabled = true;
            pickUpAllowed = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            //pickUpText.GetComponent<Text>().enabled = false;
            pickUpAllowed = false;
        }
    }

      public void PickUpCrate()
    {

        HealthScript.health += 10f;
        Destroy(gameObject);
    }

    public void WinCondition()
    {
        if (Scoring.score >= 500)
        {
            drive.gameObject.SetActive(true);

        }
    }
}
