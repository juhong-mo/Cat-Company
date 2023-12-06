//풀 매니저
//프리팹을 한곳에 모아서 생성하고 삭제
//적이나 아군을 저장하는 역할
//파괴된 오브젝트의 메모리를 해제하지 않고, 같은 종류의 프리팹을 생성할 때 재활용한다

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoolManager : MonoBehaviour
{
    //풀에 넣을 프리팹들 배열
    public GameObject[] prefabs;

    //프리팹을 바탕으로 소환되는 게임오브젝트들의 리스트 배열(풀)
    private List<GameObject>[] pools;


    //---------- 메소드들 ----------

    //초기화
    private void Initialize()
    {
        //풀 초기화
        //게임오브젝트 리스트 배열(풀)을 생성
        //리스트 배열[프리팹의 종류]
        pools = new List<GameObject>[prefabs.Length];

        //풀에 게임오브젝트 리스트를 생성
        //이 리스트에 포함되는 오브젝트 -> 게임오브젝트(적)
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    //적군이나 아군의 소환에 사용하는 메소드
    //index 프리팹의 오브젝트를 얻어온다
    //오브젝트를 풀에 추가하거나, 비활성화된 오브젝트를 다시 활성화한다
    //Get (프리팹의 종류)
    //return 선택한 프리팹의 게임오브젝트
    public GameObject Get(int index)
    {
        //얻어올 게임오브젝트 변수
        GameObject select = null;

        //비활성화된 오브젝트가 풀에 존재한다면
        //오브젝트를 선택해서 활성화한다
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        //비활성화된 오브젝트가 풀에 존재하지 않는다면
        //새로운 오브젝트를 생성하고 리스트에 추가한다
        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }


        return select;
    }

    // ---------- 실행 부분 ----------
    private void Awake()
    {
        //풀매니저의 생성과 동시에 초기화
        Initialize();
    }

}
