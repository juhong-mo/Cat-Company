
//아군 오브젝트의 현재 상태를 관리하는 스크립트
//오브젝트의 체력, 공격력 등의 상태를 변경한다
//오브젝트의 공격, 탐지 등의 상태를 변경한다
//오브젝트의 타겟을 설정한다

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyState : MonoBehaviour
{
    //오브젝트의 기본 스테이터스 설정
    //오브젝트에  data를 상속받는 스크립트를 컴포넌트로 집어넣고, 그 컴포넌트를 enemyData에 할당한다.
    public AllyData allyData;

    //오브젝트의 상태 목록
    public enum State
    {
        Die,
        Idle,
        Move,
        Attack
    }

    //현재 상태들 변수
    public State state;             //현재 상태
    public Transform curTarget;    //현재 타겟
    public float curHp;             //현재 체력

    public LayerMask targetLayer;   //타겟 레이어

    //----- 메소드들 -----

    //타겟 스캔 메소드
    //스캔 범위 내에서 오브젝트를 스캔
    //Scan(스캔 범위, 타겟 레이어)
    //가장 가까운 타겟의 Transform을 반환
    private RaycastHit2D[] targets;     //스캔한 타겟들의 배열
    private Transform nearsetTarget;    //가장 가까운 타겟
    public Transform Scan(float scanRange, LayerMask targetLayer)
    {
        //스캔한 타겟들의 배열
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        
        //가장 가까운 타겟을 설정
        float diff = 1000;
        foreach (RaycastHit2D target in targets)
        {
            Vector3 targetPosition = target.transform.position;
            float curDiff = Vector3.Distance(targetPosition, transform.position);

            if (curDiff < diff)
            {
                diff = curDiff;
                nearsetTarget = target.transform;
            }
        }

        return nearsetTarget;
    }


    //상태 체크 메소드
    private State CheckState()
    {
        if (curHp <= 0) return State.Die;                   //hp가 0보다 작으면 죽음
        if (curTarget == null) return State.Idle;           //타겟이 없으면 유휴상태

        //이 아래는 타겟이 있는 경우
        //타겟과의 거리 체크
        float targetDis;
        targetDis = Vector2.Distance(curTarget.position, transform.position);

        if (targetDis < allyData.data.attackRange) return State.Attack;     //공격 범위 안에 타겟이 있으면 공격
        return State.Move;                                                  //공격 범위 밖에 타겟이 있으면 이동
    }


    //데미지 입는 메소드
    public void Hit(float damage)
    {
        curHp -= damage;
    }

    //----- 실행 부분 -----
    private void Awake()
    {
        //처음 생성될 때

        //데이터 초기화
        allyData.Init();

        //현재 hp 초기화
        curHp = allyData.data.hp;

        //상태 초기화
        state = State.Idle;

    }

    private void OnEnable()
    {
        //활성화될 때마다

        //현재 hp 초기화
        curHp = allyData.data.hp;

        //상태 초기화
        state = State.Idle;

    }

    private void Update()
    {
        //현재 타겟 설정
        curTarget = Scan(allyData.data.scanRange, targetLayer);

        //현재 상태 설정
        state = CheckState();
    }



    //임시 죽음
    private void LateUpdate()
    {
        //Active false
        if (curHp < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
