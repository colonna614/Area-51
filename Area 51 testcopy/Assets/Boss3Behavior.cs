using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Behavior : MonoBehaviour
{
    public Transform player;
    public GameObject deathEffect;
    public GameObject Enemy;
    public GameObject Player;
    private Rigidbody2D rb;
    public static float moveSpeed = 5f;
    public Sprite KifleyWithGuns;
    public GameObject Boss3Container;

    public static int killcount = 0;

    private Vector2 movement;
    public static bool boss3IsDead = false;

    public static int bossHealth = 300;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        //Debug.Log("Boss Health = " + bossHealth);
        Vector3 direction = player.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        if (bossHealth <= 150)
        {
            this.GetComponent<SpriteRenderer>().sprite = KifleyWithGuns;
        }
        

    }

    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManagerScript.PlaySound("SFX/GetHit");
            HealthScript.health -= 10f;
            //isDead = true;

        }
        if (collision.gameObject.tag == "Bullet")
        {
            bossHealth -= 10;
            // if (bossHealth <= 0)
            //{
            //   boss1IsDead = true;
            //}
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Knife")
        {
            bossHealth -= 30;
            // if (bossHealth <= 0)
            //{
            //   boss1IsDead = true;
            //}
        }
    }
}
