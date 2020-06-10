using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletHell : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection;
    // Start is called before the first frame update
    bool canShoot = false;


    int numHandlingPatterns;
    public GameObject Boss3Container;
        void Start()
    {
        InvokeRepeating("Fire", 0f, .3f);

    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;
        if (canShoot)
        {
            for (int i = 0; i < bulletsAmount + 1; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<EnemyBullet>().SetMoveDirection(bulDir);

                angle += angleStep;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {

        if (Boss3Behavior.bossHealth > 0)
        {
            numHandlingPatterns++;
        }
        if (Boss3Behavior.bossHealth <= 0)
        {
            CancelInvoke();
            canShoot = false;
            numHandlingPatterns = -1;
            Boss3Container.SetActive(false);
            Scoring.score += 5000;
            TheShop.currency += 500;
            Boss3Behavior.boss3IsDead = true;
        }

        
        if (Boss3Behavior.bossHealth > 150)
        {
            if (numHandlingPatterns >= 75 && numHandlingPatterns < 150)
            {
                canShoot = true;
                bulletsAmount = 4;
            }
            else if (numHandlingPatterns >= 150 && numHandlingPatterns < 225)
            {
                bulletsAmount = 5;
            }
            else if (numHandlingPatterns >= 225 && numHandlingPatterns < 350)
            {
                bulletsAmount = 4;
            }
            else if (numHandlingPatterns >= 350 && numHandlingPatterns < 500)
            {
                bulletsAmount = 0;
            }
            else if (numHandlingPatterns >= 500 && numHandlingPatterns < 600)
            {
                bulletsAmount = 4;
            }
            else if (numHandlingPatterns >= 600 && numHandlingPatterns < 700)
            {
                bulletsAmount = 0;
            }
            else if (numHandlingPatterns >= 700 && numHandlingPatterns < 750)
            {
                bulletsAmount = 5;
            }
            else if (numHandlingPatterns >= 750 && numHandlingPatterns < 900)
            {
                bulletsAmount = 4;
            }
            else if (numHandlingPatterns >= 900 && numHandlingPatterns < 999)
            {
                bulletsAmount = 5;
            }
            else
            {
                canShoot = false;
            }
        }
        else if (Boss3Behavior.bossHealth > 0)
        {
            if (numHandlingPatterns >= 75 && numHandlingPatterns < 150)
            {
                canShoot = true;
                bulletsAmount = 8;
            }
            else if (numHandlingPatterns >= 150 && numHandlingPatterns < 225)
            {
                bulletsAmount = 7;
            }
            else if (numHandlingPatterns >= 225 && numHandlingPatterns < 350)
            {
                bulletsAmount = 8;
            }
            else if (numHandlingPatterns >= 350 && numHandlingPatterns < 500)
            {
                bulletsAmount = 0;
            }
            else if (numHandlingPatterns >= 500 && numHandlingPatterns < 600)
            {
                bulletsAmount = 8;
            }
            else if (numHandlingPatterns >= 600 && numHandlingPatterns < 700)
            {
                bulletsAmount = 0;
            }
            else if (numHandlingPatterns >= 700 && numHandlingPatterns < 750)
            {
                bulletsAmount = 7;
            }
            else if (numHandlingPatterns >= 750 && numHandlingPatterns < 900)
            {
                bulletsAmount = 8;
            }
            else if (numHandlingPatterns >= 900 && numHandlingPatterns < 950)
            {
                bulletsAmount = 7;
            }
            else if (numHandlingPatterns >= 950 && numHandlingPatterns < 999)
            {
                bulletsAmount = 0;
            }
            else
            {
                canShoot = false;
            }
        }

        if (numHandlingPatterns > 1000)
        {
            numHandlingPatterns = 0;
        }
        

    }
}
