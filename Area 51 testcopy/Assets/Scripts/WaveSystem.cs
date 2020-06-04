using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    Text Waves;
    public int waveNum = 1;
    public GameObject theShop;
    void Start()
    {
        Waves = GetComponent<Text>();
    }
    void Update()
    {
        Waves.text = "Wave: " + waveNum.ToString();
        if (EnemyBehavior.killcount == EnemyRandomSpawn.enemySpawnInit)
        {
            theShop.SetActive(true);
            EnemyRandomSpawn.enemySpawnInit += 3;
            EnemyBehavior.killcount = 0;
            waveNum += 1;
            Time.timeScale = 0;
            inventoryMenu.canOpenInv = false;
        }
    }
}
