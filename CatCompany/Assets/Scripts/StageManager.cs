using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{


    //isDefense
    bool defense = false;

    //stage times
    public float readyTime = 0;
    public float defenseTime = 30;
    public float restTime = 20;
    public float curTime;

    //stage level
    public int stageLevel;

    //Spawners
    //Enemy
    public EnemySpawner enemySpawner;
    public float enemySpawnGap = 5;
    private float enemySpawnTimer = 0;


    //Ally
    public AllySpawner allySpawner;
    public AllyPoolManager allyPoolManager;

    private void Awake()
    {
        stageLevel = 0;
        curTime = readyTime;
    }

    private void Update()
    {
        stageTimer();


        //Stage do
        //Spawn mobs logic

        //EnemySpawn in defense
        //spawn Gap second
        if(defense)
        {
            enemySpawnTimer += Time.deltaTime;

            if(enemySpawnTimer > enemySpawnGap)
            {
                enemySpawner.spawn(0);
                enemySpawnTimer = 0;
            }
        }


        //AllySpawn WIP
        if(Input.GetButtonDown("Jump"))
        {
            allySpawner.spawn(0);
        }

    }


    /**Stage Timer
     * stage level update
     * stage change
     */
    private void stageTimer()
    {
        curTime -= Time.deltaTime;

        if (curTime < 0)
        {
            //set stage rest
            if (defense)
            {
                defense = false;
                curTime = restTime;
            }
            //set stage defense
            else
            {
                defense = true;
                curTime = defenseTime;

                stageLevel += 1;
            }
        }
    }



}