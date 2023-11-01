using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{
    //Prefabs for enemy
    public GameObject[] prefabs;

    //Lists for enemy prefabs
    private List<GameObject>[] pools;


    private void Awake()
    {
        //Init pools
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }

    }


    //Get prefab
    //
    public GameObject Get(int index)
    {
        GameObject select = null;

        //if unactivated prefab exist in pool
        //select prefab
        foreach (GameObject item in pools[index])
        {
            if(!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        //if unactivated prefab not exist in pool
        //create new prefab
        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }


        return select;
    }
}
