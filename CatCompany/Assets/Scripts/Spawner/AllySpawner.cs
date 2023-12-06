using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawner : MonoBehaviour
{
    //이 스포너의 풀 매니저를 선언
    PoolManager poolManager;

    //----- 메소드들 -----

    //오브젝트 할당 메소드
    //GetPool(소환할 프리팹의 번호)
    private void GetPool(int index)
    {
        //index 번호의 프리팹을 오브젝틀 할당하고 활성화
        GameObject enemy = poolManager.Get(index);

        //오브젝트는 스포너의 위치에서 소환
        enemy.transform.position = transform.position;
    }

    //아군 소환 메소드
    public void spawnPawn(int index)
    {
        if(StageManager.Instance.gold >= 20)
        {
            //풀에 소환
            GameObject ally = poolManager.Get(index);
            //스포너 위치로 이동
            float spawnX = Random.Range(-2.0f, 2.0f);
            float spawnY = Random.Range(-2.0f, 2.0f);
            ally.transform.position = new Vector3(transform.position.x + spawnX, transform.position.y + spawnY, transform.position.z);

            //돈 감소
            StageManager.Instance.gold -= 20;
        }
    }
    //부장
    public void spawnRoyal(int index)
    {
        if (StageManager.Instance.gold >= 100)
        {
            //풀에 소환
            GameObject ally = poolManager.Get(index);
            //스포너 위치로 이동
            float spawnX = Random.Range(-2.0f, 2.0f);
            float spawnY = Random.Range(-2.0f, 2.0f);
            ally.transform.position = new Vector3(transform.position.x + spawnX, transform.position.y + spawnY, transform.position.z);

            //돈 감소
            StageManager.Instance.gold -= 100;
        }
    }

    //----- 실행 부분 -----

    private void Awake()
    { 
        //시작할 때 초기화
        poolManager = GetComponent<PoolManager>();
    }

    
}
