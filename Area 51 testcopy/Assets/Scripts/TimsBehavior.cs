﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimsBehavior : MonoBehaviour
{
    public Transform player;
    public GameObject deathEffect;
    public GameObject Enemy;
    public GameObject Player;
    private Rigidbody2D rb;
    public static float moveSpeed =9f;

    public static int killcount = 0;

    private Vector2 movement;
    public static bool TimIsDead = false;

    public static int timsHealth = 200;

    public GameObject boss2Container;
    public GameObject Tim;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        //Debug.Log("Boss Health = " + bossHealth);
        //Debug.Log("Tims Health: = " + timsHealth);
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        if (timsHealth <= 0)
        {
                Scoring.score += 2000;
                TheShop.currency += 250;
                TimIsDead = true;
            gameObject.SetActive(false);

        }

    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }


    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManagerScript.PlaySound("SFX/GetHit");
            HealthScript.health -= 10f;

        }
        if (collision.gameObject.tag == "Bullet")
        {
            
                timsHealth -= 10;
          
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Knife")
        {
            timsHealth -= 10;
        }
    }
}
