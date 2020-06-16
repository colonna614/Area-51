using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4Behavior : MonoBehaviour
{
    public Transform player;
    public GameObject deathEffect;
    public GameObject Enemy;
    public GameObject Player;
    private Rigidbody2D rb;
    public static float moveSpeed = 5f;
    //public Sprite KifleyWithGuns;
    public GameObject Boss4Container;

    public static int killcount = 0;

    private Vector2 movement;
    public static bool boss4IsDead = false;

    public static int bossHealth = 400;

    public bool idle = true;
    public bool isMoving = false;
    public bool returning = false;
    public bool Digging = false;
    private Animator anim;

    public Camera MainCamera;

    public GameObject Marcus;

    public Transform lookAt;


    public Rigidbody2D MarcusRB;

    //public float marcusSpeed = 500f;
    //float marcusYPos = -736;

    int animTestTimer = 0;
    public bool marcusIsUp = false;

    public bool state1 = true;
    public bool state2 = false;
    

    //Test 1 at random movement for Marcus, using targetX targetY, currentX, currentY
    float targetY, targetX;
    float currentY, currentX;
    bool needsTarget = true;
    bool stopMoving = false;
    bool searchingX = true;
    bool searchingY = true;
    public static bool isPaused = false;

    public Transform firePoint1;
    public Transform firePoint2;
    public GameObject marcusBullet;
    public float shootSpeed = 2f;

    public float marcusBufferTime = 0f;
    public bool marcusBufferCheck = false;

    bool startShooting = true;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //Marcus.transform.localPosition = new Vector3(0f, 0f, 0f);
        currentX = -0;
        currentY = -0f;
        
    }

    public void Update()
    {
        //if (marcusBufferCheck == false)
        //{
        //   marcusBufferTime += 1;
        //}
        //if (marcusBufferTime >= 100)
        //{
        //   marcusBufferCheck = true;
        //}
        //if (marcusBufferCheck == true)
        //{
        //Quaternion rotation = Quaternion.LookRotation
        //     (lookAt.transform.position - transform.position, transform.TransformDirection(Vector3.right));
        //transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        //}
        //Debug.Log(animTestTimer);
        //transform.rotation = lookAt.rotation;
        //Vector3 direction = player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        //direction.Normalize();
        //movement = direction;
        Vector3 direction = player.position - this.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x);
        this.transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);

        if (isPaused == false && bossHealth >0)
        {
            State1();
            UpdateAnimations();
            animTestTimer++;
        }
        if (bossHealth <= 0)
        {
            CancelInvoke();
            MainCamera.orthographicSize = 3.2f;
            Boss4Container.SetActive(false);
            gameObject.SetActive(false);
            Scoring.score += 7500;
            TheShop.currency += 750;
            boss4IsDead = true;
        }

        //Debug.Log(animTestTimer);
    }

    private void UpdateAnimations()
    {
        anim.SetBool("Idle", idle);
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("Returning", returning);
        anim.SetBool("Digging", Digging);
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManagerScript.PlaySound("SFX/GetHit");
            HealthScript.health -= 10f;
        }
        if (collision.gameObject.tag == "Bullet" && marcusIsUp == true)
        {
            bossHealth -= 10;
            
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Knife")
        {
            bossHealth -= 20;
        }
    }

    public void State1()
    {
        if (needsTarget == true)
        {
            targetX = Random.Range(-12f, 12f);
            targetY = Random.Range(-6.2f, 6.2f);
            needsTarget = false;
            searchingX = true;
            searchingY = true;
            startShooting = true;
            //InvokeRepeating("ShootBullet", 0f, .8f);
        }
        else if (animTestTimer >= 30&& animTestTimer < 600 && startShooting == true)
        {
            
            startShooting = false;
            idle = true;
            returning = false;
            InvokeRepeating("ShootBullet", 0f, .8f);
        }
        else if (animTestTimer < 600)
        {
            idle = true;
            returning = false;
        }
        else if (animTestTimer < 650)
        {
            CancelInvoke();
            idle = false;
            Digging = true;
            marcusIsUp = false;
            stopMoving = false;
        }
        else if (marcusIsUp == false && stopMoving ==false)
        {
            Digging = false;
            isMoving = true;
            Marcus.transform.localPosition = new Vector3(currentX, currentY, 0f);
            FindXandY();
        }
        else if (stopMoving == true && marcusIsUp == false)
        {
            isMoving = false;
            returning = true;
            marcusIsUp = true;
        }
        else if (marcusIsUp == true)
        {
            idle = true;
            returning = false;
            animTestTimer = 0;
            needsTarget = true;
        }
    }

    public void FindXandY()
    {
        if (currentX <= targetX && searchingX == true)
        {
            currentX += .02f;
            if (currentX >= targetX)
            {
                searchingX = false;
            }

        }
        else if (currentX >= targetX && searchingX == true)
        {
            currentX -= .02f;
            if (currentX <= targetX)
            {
                searchingX = false;
            }
        }
        if (currentY <= targetY && searchingY == true)
        {
            currentY += .02f;
            if (currentY >= targetY)
            {
                searchingY = false;
            }

        }
        else if (currentY >= targetY && searchingY == true)
        {
            currentY -= .02f;
            if (currentY <= targetY)
            {
                searchingY = false;
            }
        }
        if (searchingX == false && searchingY == false)
        {
            stopMoving = true;
        }
    }

    public void ShootBullet()
    {
        /*
        float bulDirX = transform.position.x;
        float bulDirY = transform.position.y;

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

        //GameObject bul = marcusBullet;
        marcusBullet.transform.position = transform.position;
        marcusBullet.transform.rotation = transform.rotation;
        
        //Rigidbody2D bPrefab = Instantiate(marcusBullet, new 
         //Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
        //bPrefab.GetComponent<Rigidbody2D>().AddForce(transform.up * shootSpeed);

        */
        GameObject firedBullet1 = Instantiate(marcusBullet, firePoint1.position, firePoint1.rotation);
        firedBullet1.GetComponent<Rigidbody2D>().velocity = firePoint1.right *shootSpeed;
        GameObject firedBullet2 = Instantiate(marcusBullet, firePoint2.position, firePoint2.rotation);
        firedBullet2.GetComponent<Rigidbody2D>().velocity = firePoint2.right * shootSpeed;
    }
}
