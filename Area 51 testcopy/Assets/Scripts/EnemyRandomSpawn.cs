using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSpawn : MonoBehaviour
{

  public Transform[] spawnPoints;
  public GameObject[] enemies;
  int randomSpawnPoint, randomEnemy;
  public static bool spawnAllowed;
    public static int enemySpawnInit = 10;
    public int enemySpawnCounter = 10;
    public GameObject theShopOBJ;

    public GameObject theBoss1;
    public Animator bossIndicator;
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating ("SpawnAEnemy", 0f, 1f);
    }
    void Update()
    {
        if (enemySpawnCounter <= 0)
        {
            spawnAllowed = false;
        }
        else
        {
            spawnAllowed = true;
        }
        if (Input.GetKeyDown(KeyCode.C))
         {
            if (theShopOBJ.activeSelf == true)
            {
                theShopOBJ.SetActive(false);
                MoveAndShootMouse.canShoot = true;
                Move2D.OutOfShop = true;
                Time.timeScale = 1;
                inventoryMenu.canOpenInv = true;
                if (WaveSystem.waveNum == 3)
                {
                    theBoss1.SetActive(true);
                    bossIndicator.enabled = true ;
                }
                else
                {
                    enemySpawnCounter = enemySpawnInit;
                }
            }
      
         }
    }
    // Update is called once per frame
    void SpawnAEnemy()
    {
        if(spawnAllowed){
          randomSpawnPoint = Random.Range (0, spawnPoints.Length);
          randomEnemy = Random.Range(0, enemies.Length);
          Instantiate(enemies [randomEnemy], spawnPoints [randomSpawnPoint].position, Quaternion.identity);
            gameObject.SetActive(true);
            EnemyCountDisplay.enemies += 1;
            enemySpawnCounter -= 1;
            //Debug.Log(EnemyCountDisplay.enemies + " Enemy Spawn");
        }
    }
}
