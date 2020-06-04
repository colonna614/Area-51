using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject barbedWire;


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (barbedWire.gameObject.tag == "Player")
        {
            Debug.Log("OUCH");
        }
    }
}
