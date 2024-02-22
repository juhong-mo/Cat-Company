
//싱글톤 패턴 탬플릿
//이것을 상속하는 클래스는 전역 인스턴스를 생성한다
//이것을 상속하는 클래스는 게임 중 오직 하나의 인스턴스만 존재한다
//이것을 포함한 오브젝트는 씬이 전환되어도 파괴되지 않는다
//모든 스크립트에서 인스턴스를 참조 가능하다


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    //전역 인스턴스 선언
    private static T instance;

    //인스턴스 참조를 위해
    public static T Instance
    {
        get
        {
            //인스턴스가 할당되어 있지 않으면
            //인스턴스를 검색해서 할당
            //인스턴스가 존재하지 않으면 새로 생성
            //인스턴스를 리턴
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name, typeof(T));
                    instance = obj.GetComponent<T>();
                }
            }
            return instance;
        }
    }


    protected void Awake()
    {
        //씬이 전환되어도 오브젝트를 파괴하지 않음
        //오브젝트의 부모도 마찬가지로 파괴하지 않음
        if (transform.parent != null && transform.root != null)
        {
            DontDestroyOnLoad(this.transform.root.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
