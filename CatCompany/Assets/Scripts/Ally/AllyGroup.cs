
//그룹 조합 시스템
//개발 중


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyGroup : MonoBehaviour
{
    //마스크(아군)
    public LayerMask targetLayer;

    //부하 그룹
    public List<Transform> group = new List<Transform>();


    //부하 후보 (부장이랑 닿아있는 애)
    Transform temp;

    //부하랑 부장이랑 닿아있을 때
    private void OnTriggerEnter2D(Collider2D collision)
    {
        temp = collision.transform;
    }

    //부하랑 부장이랑 떨어질 때
    private void OnTriggerExit2D(Collider2D collision)
    {
        temp = null;
    }


    //마우스 놓을 때 실행
    private void OnMouseUp()
    {
        //그룹 리스트에 추가
        if (temp) group.Add(temp);
    }


    //그룹원 모이기
    private void Update()
    {
        foreach(Transform target in group)
        {
            //타겟이랑 거리
            float dis = Vector3.Distance(target.position, transform.position);

            

            //거리 멀어지면 끌어오기
            if(dis > 3.0)
            {
                //타겟 방향
                Vector3 dir = Vector3.Normalize(transform.position - target.position);
                target.Translate(new Vector3(dir.x * 0.05f, dir.y * 0.05f, 0));
            }
        }
    }


}
