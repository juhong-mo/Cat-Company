
//적 스폰 시스템
//디펜스 타임이 되면 적군을 스폰한다
//적 프리팹은 풀 매니저에 저장한다


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    //이 스포너의 풀 매니저를 선언
    PoolManager poolManager;

    //적의 최종 목표를 유니티에서 설정해야한다
    //비어있으면 소환된 적들이 동작하지 않는다
    public Transform finalTarget;

    //사용할 스폰 정보 스크립트
    //---개발중
    //---데이터에 맞게 다른 종류의 스포너를 만든다

    //소환에 필요한 변수들
    public float cooldown = 5;      //소환 쿨타임
    private float timer = 0;        //소환 타이머


    //---------- 메소드들 ----------

    //오브젝트 할당 메소드
    //GetPool(소환할 프리팹의 번호)
    private void GetPool(int index)
    {
        //index 번호의 프리팹을 오브젝틀 할당하고 활성화
        GameObject enemy = poolManager.Get(index);

        //오브젝트의 최종 타겟을 할당
        enemy.GetComponent<EnemyState>().finalTarget = finalTarget;

        //오브젝트는 스포너의 위치에서 소환
        float spawnX = Random.Range(-3.0f, 3.0f);
        float spawnY = Random.Range(-3.0f, 3.0f);
        enemy.transform.position = new Vector3(transform.position.x + spawnX, transform.position.y + spawnY, transform.position.z);
    }

    


    //---------- 실행 부분 ----------

    private void Awake()
    {
        //컴포넌트에서 풀 매니저 받아오기
        poolManager = GetComponent<PoolManager>();
    }

    private void Update()
    {
        //스폰 타이머
        timer += Time.deltaTime;

        //적 소환 부분
        //현재 디펜스 상황이라면 적을 소환한다
        if (StageManager.Instance.isDefense)
        {
            //쿨타임마다 풀에 할당
            if (timer > cooldown)
            {
                GetPool(0);
                timer = 0;
            }
        }

        
    }

}
