using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    Text Waves;
    public static int waveNum = 1;
    public GameObject theShop;
    void Start()
    {
        Waves = GetComponent<Text>();
    }
    void Update()
    {
        Waves.text = "Wave: " + waveNum.ToString();
       
            if (EnemyBehavior.killcount == EnemyRandomSpawn.enemySpawnInit || Boss1Behavior.boss1IsDead == true)
            {
                theShop.SetActive(true);
                EnemyRandomSpawn.enemySpawnInit += 3;
                EnemyBehavior.killcount = 0;
                waveNum += 1;
                Time.timeScale = 0;
            Boss1Behavior.boss1IsDead = false;
            inventoryMenu.canOpenInv = false;
                EnemyBehavior.moveSpeed += 0.2f;
            }
        
    }
}
