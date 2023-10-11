using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    //      선언
    //      레이어마스크
    LayerMask layerAlly;
    LayerMask layerEnemy;
    LayerMask layerStructure;

    //      퍼블릭 변수
    public GameObject target;           //최종타겟, 베이스
    public float speed = 1;             //이동속도
    public float maxScanDistance = 1;   //공격대상을 인지하는 최대 거리

    //      AI 구성 함수의 변수
    Vector2 vectorTargetDirection;      //타겟이 있는 방향(좌우), x값은 1,0,-1 중 하나, y값은 항상 0
    EnumState state;                    //적의 상태 (이동, 공격)

    enum EnumState
    {
        Move,
        Attack
    }



    private void Awake()
    {
        //      레이어마스크 할당
        layerAlly = 1 << LayerMask.NameToLayer("Ally");
        layerEnemy = 1 << LayerMask.NameToLayer("Enemy");
        layerStructure = 1 << LayerMask.NameToLayer("Structure");
    }



    private void Start()
    {
        //      디버그
        if (target == null)
        {
            Debug.Log("Set target object");
        }
    }



    private void FixedUpdate()
    {

        //      타겟이 있는 방향 세팅
        vectorTargetDirection = new Vector2(System.Math.Sign(target.transform.position.x - transform.position.x), 0);

        //      적이 있는지 없는지 스캔, 없으면 이동, 있으면 공격 상태로 전환
        RaycastHit2D scanHit = Physics2D.Raycast(transform.position, vectorTargetDirection, maxScanDistance, layerAlly | layerStructure);
        if (scanHit.transform == null)
        {
            state = EnumState.Move;
        }
        else
        {
            state = EnumState.Attack;
        }
                
    }



    private void Update()
    {

        //      이동
        if (state == EnumState.Move)
        {
            Vector2 vectorTargetMovement = vectorTargetDirection * speed * Time.deltaTime;
            transform.Translate(vectorTargetMovement);
        }

        //      공격
        if (state == EnumState.Attack)
        {
            Debug.Log("공격");
        }
    }

}