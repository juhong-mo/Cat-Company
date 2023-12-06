//Ǯ �Ŵ���
//�������� �Ѱ��� ��Ƽ� �����ϰ� ����
//���̳� �Ʊ��� �����ϴ� ����
//�ı��� ������Ʈ�� �޸𸮸� �������� �ʰ�, ���� ������ �������� ������ �� ��Ȱ���Ѵ�

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoolManager : MonoBehaviour
{
    //Ǯ�� ���� �����յ� �迭
    public GameObject[] prefabs;

    //�������� �������� ��ȯ�Ǵ� ���ӿ�����Ʈ���� ����Ʈ �迭(Ǯ)
    private List<GameObject>[] pools;


    //---------- �޼ҵ�� ----------

    //�ʱ�ȭ
    private void Initialize()
    {
        //Ǯ �ʱ�ȭ
        //���ӿ�����Ʈ ����Ʈ �迭(Ǯ)�� ����
        //����Ʈ �迭[�������� ����]
        pools = new List<GameObject>[prefabs.Length];

        //Ǯ�� ���ӿ�����Ʈ ����Ʈ�� ����
        //�� ����Ʈ�� ���ԵǴ� ������Ʈ -> ���ӿ�����Ʈ(��)
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    //�����̳� �Ʊ��� ��ȯ�� ����ϴ� �޼ҵ�
    //index �������� ������Ʈ�� ���´�
    //������Ʈ�� Ǯ�� �߰��ϰų�, ��Ȱ��ȭ�� ������Ʈ�� �ٽ� Ȱ��ȭ�Ѵ�
    //Get (�������� ����)
    //return ������ �������� ���ӿ�����Ʈ
    public GameObject Get(int index)
    {
        //���� ���ӿ�����Ʈ ����
        GameObject select = null;

        //��Ȱ��ȭ�� ������Ʈ�� Ǯ�� �����Ѵٸ�
        //������Ʈ�� �����ؼ� Ȱ��ȭ�Ѵ�
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        //��Ȱ��ȭ�� ������Ʈ�� Ǯ�� �������� �ʴ´ٸ�
        //���ο� ������Ʈ�� �����ϰ� ����Ʈ�� �߰��Ѵ�
        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }


        return select;
    }

    // ---------- ���� �κ� ----------
    private void Awake()
    {
        //Ǯ�Ŵ����� ������ ���ÿ� �ʱ�ȭ
        Initialize();
    }

}
