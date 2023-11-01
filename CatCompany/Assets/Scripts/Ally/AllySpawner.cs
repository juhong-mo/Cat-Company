using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawner : MonoBehaviour
{
    AllyPoolManager poolManager;

    private void Awake()
    {
        poolManager = GetComponent<AllyPoolManager>();
    }

    //Spawn enemy
    public void spawn(int index)
    {
        //spawn
        GameObject ally = poolManager.Get(index);

        //random position
        float spawnX = Random.Range(-2.0f, 2.0f);
        float spawnY = Random.Range(-2.0f, 2.0f);
        ally.transform.position = new Vector3(spawnX, spawnY, transform.position.z);
    }
}
