//적의 애니메이션을 처리하는 스크립트


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    //오브젝트 상태
    EnemyState state;

    //스프라이트
    SpriteRenderer spriter;



    //----- 실행 부분 -----
    private void Awake()
    {   
        //처음 생성될 때 초기화
        state = GetComponent<EnemyState>();
        spriter = GetComponent<SpriteRenderer>();
    }


    //애니메이션 동작
    private void LateUpdate()
    {
        switch (state.state)
        {
            case EnemyState.State.Die:
                //죽는 애니미에션
                break;

            case EnemyState.State.Idle:
                //유휴 애니메이션
                break;

            case EnemyState.State.Move:
                //이동 애니메이션
                break;

            case EnemyState.State.Attack:
                //공격 애니메이션
                break;

            default:
                break;
        }

        //타겟 방향에 따라 스프라이트 뒤집기
        if (state.curTarget) spriter.flipX = state.curTarget.position.x < transform.position.x;
    }

}
