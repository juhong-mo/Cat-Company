
//적 오브젝트의 인공지능
//state에 따라서 행동한다

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    //오브젝트 상태
    private EnemyState state;

    //오브젝트 물리 효과
    private Rigidbody2D rigid;

    //공격 쿨타임
    private float coolTime;



    //----- 실행 부분 -----

    private void Awake()
    {
        //오브젝트 처음 생성될 때 초기화
        state = GetComponent<EnemyState>();
        rigid = GetComponent<Rigidbody2D>();

        coolTime = 0;
    }


    private void OnEnable()
    {
        //활성화될 때 초기화
        coolTime = 0;
    }



    //Enemy의 인공지능 동작
    private void FixedUpdate()
    {
        //공격 쿨타임 업데이트
        coolTime += Time.fixedDeltaTime;

        
        switch (state.state)
        {
            case EnemyState.State.Die:
                //죽음
                break;

            case EnemyState.State.Idle:
                //유휴 상태
                break;

            case EnemyState.State.Move:
                Vector2 dirVec = state.curTarget.position - transform.position;                   //이동 방향
                Vector2 moveVec = dirVec.normalized * state.enemyData.data.speed * Time.fixedDeltaTime;     //이동 속도
                rigid.MovePosition(rigid.position + moveVec);                                               //물리 이동
                break;

            case EnemyState.State.Attack:
                //공격 쿨타임이 돌았다면 공격
                if (coolTime > state.enemyData.data.cooldown)      
                {
                    //데미지만큼 공격
                    if (state.curTarget != state.finalTarget)           //건물이 아닐 때
                        state.curTarget.GetComponent<AllyState>().Hit(state.enemyData.data.damage);

                    if (state.curTarget == state.finalTarget)           //Base 일 때
                        StageManager.Instance.hp -= (int)state.enemyData.data.damage;

                    //공격 쿨타임 초기화
                    coolTime = 0;
                }
                break;

            default:
                break;
        }

    }

    private void Update()
    {
        //물리효과, 오브젝트의 미끄러짐 방지
        rigid.velocity = Vector2.zero;
    }
}
