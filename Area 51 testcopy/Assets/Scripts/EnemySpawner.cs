using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

  public GameObject enemy;
  public float randX;
  Vector2 wheretoSpawn;
  public float spawnRate = 2f;
  float nextSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn){
          nextSpawn = Time.time + spawnRate;
          randX = Random.Range(0f, 8.4f);
          wheretoSpawn = new Vector2 (randX, transform.position.y);
          Instantiate(enemy, wheretoSpawn, Quaternion.identity);
        }
    }
}
