using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCountDisplay : MonoBehaviour
{
    Text enemiesRemaining;
    public static int enemies;


    void Start()
    {
        enemies = 0;
        enemiesRemaining = GetComponent<Text>();
    }



    void Update()
    {
        enemiesRemaining.text = "  " + enemies.ToString() + "/" +EnemyRandomSpawn.enemySpawnInit;
    }
}
