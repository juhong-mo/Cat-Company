
//스테이지 매니저(싱글톤)
//스테이지의 진행을 관리한다
//스테이지의 디펜스 상황과 휴식 상황을 전환
//디펜스가 시작할 때마다 스테이지 레벨 +1
//현재 스테이지의 레벨을 저장


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageManager : Singleton<StageManager>
{

    //현재 스테이지 상황
    //true 일 때 디펜스
    public bool isDefense = false;

    //스테이지 시간 변수들
    public float readyTime = 0;     //첫번째 스테이지 시작까지 준비 시간
    public float defenseTime = 10;  //한번의 디펜스가 소요하는 시간
    public float restTime = 5;     //휴식 시간
    public float curTime = 0;       //스테이지 현재 남은 시간

    //현재 스테이지 레벨
    public int stageLevel = 0;


    //게임 플레이 변수
    public int gold = 100;          //돈
    public int hp = 1000;           //플레이어 체력


    //-------------------- 메소드들 --------------------

    //스테이지 매니저 초기화 메소드
    public void Initialize()
    {
        isDefense = false;
        curTime = readyTime;
        stageLevel = 0;
    }

    //스테이지 타이머
    //업데이트마다 실행
    //현재 스테이지 시간을 진행시킨다
    //디펜스와 휴식을 전환한다
    //스테이지 레벨을 상승시킨다
    private void stageTimer()
    {
        //매초 현재 시간 -1초
        curTime -= Time.deltaTime;

        //현재 시간이 0초보다 작으면 스테이지 상황을 전환한다
        //디펜스 활성화 -> 스테이지 레벨 상승
        if (curTime < 0)
        {
            if (isDefense)
            {
                isDefense = false;
                curTime = restTime;
                gold += 200;
            }
            else
            {
                isDefense = true;
                curTime = defenseTime;
                stageLevel += 1;
            }
        }
    }


    //-------------------- 실행 부분 --------------------

    private void Awake()
    {
        //인스턴스가 처음 생성될 때 초기화
        Initialize();
    }


    //스테이지 도중 항상 실행
    private void Update()
    {
        //스테이지 타이머
        stageTimer();

    }

    
}