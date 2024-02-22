
//�̱��� ���� ���ø�
//�̰��� ����ϴ� Ŭ������ ���� �ν��Ͻ��� �����Ѵ�
//�̰��� ����ϴ� Ŭ������ ���� �� ���� �ϳ��� �ν��Ͻ��� �����Ѵ�
//�̰��� ������ ������Ʈ�� ���� ��ȯ�Ǿ �ı����� �ʴ´�
//��� ��ũ��Ʈ���� �ν��Ͻ��� ���� �����ϴ�


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    //���� �ν��Ͻ� ����
    private static T instance;

    //�ν��Ͻ� ������ ����
    public static T Instance
    {
        get
        {
            //�ν��Ͻ��� �Ҵ�Ǿ� ���� ������
            //�ν��Ͻ��� �˻��ؼ� �Ҵ�
            //�ν��Ͻ��� �������� ������ ���� ����
            //�ν��Ͻ��� ����
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
        //���� ��ȯ�Ǿ ������Ʈ�� �ı����� ����
        //������Ʈ�� �θ� ���������� �ı����� ����
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
