using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    EnemyPoolManager poolManager;

    public GameObject allyBase;

    private void Awake()
    {
        poolManager = GetComponent<EnemyPoolManager>();
    }

    //Spawn enemy
    public void spawn(int index)
    {
        //spawn
        GameObject enemy = poolManager.Get(index);

        //set final target
        enemy.GetComponent<EnemyController>().finalTarget = allyBase.transform;

        //random position
        float spawnY = Random.Range(-5, 5);
        enemy.transform.position = new Vector3(transform.position.x, spawnY, transform.position.z);
    }
}
