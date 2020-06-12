using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    Text Waves;
    public static int waveNum = 1;
    public GameObject theShop;
    public Animator bossIndicator;
    public GameObject boss2Contain;
    void Start()
    {
        Waves = GetComponent<Text>();
    }
    void Update()
    {
        Waves.text = "Wave: " + waveNum.ToString();
       
            if (EnemyBehavior.killcount == EnemyRandomSpawn.enemySpawnInit || Boss1Behavior.boss1IsDead == true || (TimsBehavior.TimIsDead == true && TomsBehavior.TomIsDead == true) || Boss3Behavior.boss3IsDead == true)
            {
                theShop.SetActive(true);
                EnemyRandomSpawn.enemySpawnInit += 3;
                EnemyBehavior.killcount = 0;
                waveNum += 1;
                Time.timeScale = 0;
            bossIndicator.enabled = false;
            boss2Contain.SetActive(false);
            Boss3Behavior.boss3IsDead = false;
            Boss1Behavior.boss1IsDead = false;
            TimsBehavior.TimIsDead = false;
            TomsBehavior.TomIsDead = false;
            inventoryMenu.canOpenInv = false;
                EnemyBehavior.moveSpeed += 0.2f;
            //EnemyRandomSpawn.spawnRate -= .1f;
            }
        
    }
}
