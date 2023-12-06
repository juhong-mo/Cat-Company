using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawner : MonoBehaviour
{
    //�� �������� Ǯ �Ŵ����� ����
    PoolManager poolManager;

    //----- �޼ҵ�� -----

    //������Ʈ �Ҵ� �޼ҵ�
    //GetPool(��ȯ�� �������� ��ȣ)
    private void GetPool(int index)
    {
        //index ��ȣ�� �������� ������Ʋ �Ҵ��ϰ� Ȱ��ȭ
        GameObject enemy = poolManager.Get(index);

        //������Ʈ�� �������� ��ġ���� ��ȯ
        enemy.transform.position = transform.position;
    }

    //�Ʊ� ��ȯ �޼ҵ�
    public void spawnPawn(int index)
    {
        if(StageManager.Instance.gold >= 20)
        {
            //Ǯ�� ��ȯ
            GameObject ally = poolManager.Get(index);
            //������ ��ġ�� �̵�
            float spawnX = Random.Range(-2.0f, 2.0f);
            float spawnY = Random.Range(-2.0f, 2.0f);
            ally.transform.position = new Vector3(transform.position.x + spawnX, transform.position.y + spawnY, transform.position.z);

            //�� ����
            StageManager.Instance.gold -= 20;
        }
    }
    //����
    public void spawnRoyal(int index)
    {
        if (StageManager.Instance.gold >= 100)
        {
            //Ǯ�� ��ȯ
            GameObject ally = poolManager.Get(index);
            //������ ��ġ�� �̵�
            float spawnX = Random.Range(-2.0f, 2.0f);
            float spawnY = Random.Range(-2.0f, 2.0f);
            ally.transform.position = new Vector3(transform.position.x + spawnX, transform.position.y + spawnY, transform.position.z);

            //�� ����
            StageManager.Instance.gold -= 100;
        }
    }

    //----- ���� �κ� -----

    private void Awake()
    { 
        //������ �� �ʱ�ȭ
        poolManager = GetComponent<PoolManager>();
    }

    
}
