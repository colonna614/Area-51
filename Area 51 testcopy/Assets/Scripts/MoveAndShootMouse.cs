using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndShootMouse : MonoBehaviour
{
  public Transform firePoint;
  public Transform firePoint1;
  public Transform firePoint2;
    public Transform firePointAR1;
    public Transform firePointAR2;
    public Transform firePointAR3;

    public static bool pistolState = true;
  public static bool isShotgunState = false;
    public static bool purchasedShotgun = false;
    public static bool purchasedAR = false;
    public static bool isKnifeState = false;
    public static bool isARState = false;


    public GameObject bulletToRight;

  private Vector2 bulletPos;
  private float lookAngle;
    public static bool canShoot = true;

    
    void Update()
    {
      bulletPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
      lookAngle = Mathf.Atan2(bulletPos.y, bulletPos.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);

        if (AmmoCount.ammo > 0 && canShoot == true)
        {
            bulletPos = transform.position;

            if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) && isARState == false)
            {
                if (pistolState == true)
                {
                    SoundManagerScript.PlaySound("SFX/Pistol");
                    ShootBullet();
                    AmmoCount.ammo -= 1;
                }
                else if (isShotgunState == true && AmmoCount.ammo >= 3)
                {
                    SoundManagerScript.PlaySound("SFX/Shotgun");
                    ShootBulletSpread();
                    AmmoCount.ammo -= 3;
                }

            }
            else if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) && isARState == true)
            {
                InvokeRepeating("ShootBulletAR", 0f, .2f);
            }
            else if ((Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.Space)) && isARState == true)
            {
                CancelInvoke();
            }
        }
        else if (AmmoCount.ammo == 0)
        {
            CancelInvoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pistolState = true;
            isKnifeState = false;
            isShotgunState = false;
            isARState = false;
            CancelInvoke();
            //Debug.Log("Pistol active" + pistolState);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pistolState = false;
            isKnifeState = true;
            isShotgunState = false;
            isARState = false;
            CancelInvoke();
            //Debug.Log("Knife active" + isKnifeState);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && purchasedShotgun)
        {
            pistolState = false;
            isKnifeState = false;
            isShotgunState = true;
            isARState = false;
            CancelInvoke();
            //Debug.Log("shotgun active" + isShotgunState);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && purchasedAR)
        {
            pistolState = false;
            isKnifeState = false;
            isShotgunState = false;
            isARState = true;
        }

    }

    public void ShootBullet(){
      GameObject firedBullet = Instantiate(bulletToRight, firePoint.position, firePoint.rotation);
      firedBullet.GetComponent<Rigidbody2D>().velocity = firePoint.right;
    }

     public void ShootBulletSpread(){
       GameObject firedBullet = Instantiate(bulletToRight, firePoint.position, firePoint.rotation);
       GameObject firedBullet2 = Instantiate(bulletToRight, firePoint1.position, firePoint1.rotation);
       GameObject firedBullet3 = Instantiate(bulletToRight, firePoint2.position, firePoint2.rotation);
       firedBullet.GetComponent<Rigidbody2D>().velocity = firePoint.right;
       firedBullet2.GetComponent<Rigidbody2D>().velocity = firePoint1.right;
       firedBullet3.GetComponent<Rigidbody2D>().velocity = firePoint2.right;
     }
    public void ShootBulletAR()
    {
        float randFirePoint = Random.Range(1f, 4f);
        if (randFirePoint < 2)
        {
            SoundManagerScript.PlaySound("SFX/Pistol");
            AmmoCount.ammo -= 1;
            GameObject firedBulletAR3 = Instantiate(bulletToRight, firePointAR3.position, firePointAR3.rotation);
            firedBulletAR3.GetComponent<Rigidbody2D>().velocity = firePointAR3.right;
        }
        else if (randFirePoint < 3)
        {
            SoundManagerScript.PlaySound("SFX/Pistol");
            AmmoCount.ammo -= 1;
            GameObject firedBulletAR1 = Instantiate(bulletToRight, firePointAR1.position, firePointAR1.rotation);
            firedBulletAR1.GetComponent<Rigidbody2D>().velocity = firePointAR1.right;
        }
        else if (randFirePoint <= 4)
        {
            SoundManagerScript.PlaySound("SFX/Pistol");
            AmmoCount.ammo -= 1;
            GameObject firedBulletAR2 = Instantiate(bulletToRight, firePointAR2.position, firePointAR2.rotation);
            firedBulletAR2.GetComponent<Rigidbody2D>().velocity = firePointAR2.right;
        }
    }


}
