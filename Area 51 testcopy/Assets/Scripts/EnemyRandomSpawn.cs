using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Animator bossIndicator2;
    public GameObject theBoss2;
    public Animator bossIndicator3;
    public GameObject theBoss3;
    public Animator bossIndicator4;
    public GameObject theBoss4;

    public Camera mainCamera;

    public Text thanks;
    //public static float spawnRate = 1f;

    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating ("SpawnAEnemy", 0f, 1f);
    }
    void Update()
    {
        //Debug.Log("spawnRate : " + spawnRate);
        
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

                if (WaveSystem.waveNum == 6 || WaveSystem.waveNum == 11 ||
                   WaveSystem.waveNum == 16 || WaveSystem.waveNum == 21)
                {
                    MainSongSwitch.mainSongCheck = true;
                }

                if (WaveSystem.waveNum == 5)
                {
                    MainSongSwitch.boss1SongCheck = true;
                    theBoss1.SetActive(true);
                    bossIndicator.enabled = true;
                    CancelInvoke();
                    InvokeRepeating("SpawnAEnemy", 0f, .8f);
                }
                else if (WaveSystem.waveNum == 10)
                {
                    MainSongSwitch.boss2SongCheck = true;
                    theBoss2.SetActive(true);
                    bossIndicator2.enabled = true;
                    CancelInvoke();
                    InvokeRepeating("SpawnAEnemy", 0f, .65f);
                }
                else if (WaveSystem.waveNum == 15)
                {
                    MainSongSwitch.boss3SongCheck = true;
                    mainCamera.orthographicSize = 4.2f;
                    theBoss3.SetActive(true);
                    bossIndicator3.enabled = true;
                    CancelInvoke();
                    InvokeRepeating("SpawnAEnemy", 0f, .5f);
                }
                else if (WaveSystem.waveNum == 20)
                {
                    MainSongSwitch.boss4SongCheck = true;
                    mainCamera.orthographicSize = 4.2f;
                    theBoss4.SetActive(true);
                    bossIndicator4.enabled = true;
                    CancelInvoke();
                    InvokeRepeating("SpawnAEnemy", 0f, .45f);
                }
                else
                {
                    enemySpawnCounter = enemySpawnInit;
                }
                if (WaveSystem.waveNum == 21)
                {
                    thanks.enabled = true;
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
