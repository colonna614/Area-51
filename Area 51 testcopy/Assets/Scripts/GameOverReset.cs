using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverReset : MonoBehaviour
{
    public GameObject MainCharacter;
    public static int HighScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HighScore < Scoring.score)
        {
            HighScore = Scoring.score;
        }
            if (Input.GetKeyDown(KeyCode.Return)&& MainCharacter.activeSelf == false)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                EnemyRandomSpawn.enemySpawnInit = 10;
                EnemyBehavior.killcount = 0;
                TheShop.currency = 0;
                Scoring.score = 0;
                Time.timeScale = 1;
                MoveAndShootMouse.purchasedShotgun = false;
                MoveAndShootMouse.purchasedAR = false;
                MoveAndShootMouse.pistolState = true;
                MoveAndShootMouse.isShotgunState = false;
                MoveAndShootMouse.isARState = false;
                MoveAndShootMouse.purchasedKnife = false;
            unlockKnifeUp.knifeUnlocked = false;
            unlockKnifeUp.numOfKnifeKills = 0;
            UnlockAmmoUp.ammoUnlocked = false;
            UnlockAmmoUp.numOfAmmoBought = 0;
            UnlockHealthUp.numOfHealthBought = 0;
            UnlockHealthUp.healthUnlocked = false;
                EnemyBehavior.moveSpeed = 2f;
                WaveSystem.waveNum = 1;
                Boss1Behavior.bossHealth = 300;
                TimsBehavior.timsHealth = 200;
                TomsBehavior.tomsHealth = 200;
                Boss3Behavior.bossHealth = 300;
                Boss4Behavior.bossHealth = 350;
        }

    }
}
