using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public GameObject deathEffect;
    public GameObject Enemy;
    public GameObject Player;
    private Rigidbody2D rb;
    public static float moveSpeed = 2f;

    public static int killcount = 0;

    private Vector2 movement;
    bool isDead =false;
    bool isDeadByKnife = false;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        //Debug.Log("move speed = " + moveSpeed);
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        if (isDead)
        {
            Die();
        }
        else if (isDeadByKnife)
        {
            DieByKnife();
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
    public void Die()
    {
      //  Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Scoring.score += 100;
        EnemyCountDisplay.enemies -= 1;
        killcount += 1;
        TheShop.currency += 10;
    }
    public void DieByKnife()
    {
        Destroy(gameObject);
        Scoring.score += 100;
        EnemyCountDisplay.enemies -= 1;
        killcount += 1;
        TheShop.currency += 10;
        unlockKnifeUp.numOfKnifeKills += 1;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManagerScript.PlaySound("SFX/GetHit");
            HealthScript.health -= 10f;
            isDead = true;
           
        }
        if (collision.gameObject.tag == "Bullet")
        {
            isDead = true;
        }
        

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Knife")
        {
            //Debug.Log("Knife hit something");
            isDeadByKnife = true;
        }
    }
}