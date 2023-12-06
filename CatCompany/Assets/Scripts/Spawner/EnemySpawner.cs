
//�� ���� �ý���
//���潺 Ÿ���� �Ǹ� ������ �����Ѵ�
//�� �������� Ǯ �Ŵ����� �����Ѵ�


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    //�� �������� Ǯ �Ŵ����� ����
    PoolManager poolManager;

    //���� ���� ��ǥ�� ����Ƽ���� �����ؾ��Ѵ�
    //��������� ��ȯ�� ������ �������� �ʴ´�
    public Transform finalTarget;

    //����� ���� ���� ��ũ��Ʈ
    //---������
    //---�����Ϳ� �°� �ٸ� ������ �����ʸ� �����

    //��ȯ�� �ʿ��� ������
    public float cooldown = 5;      //��ȯ ��Ÿ��
    private float timer = 0;        //��ȯ Ÿ�̸�


    //---------- �޼ҵ�� ----------

    //������Ʈ �Ҵ� �޼ҵ�
    //GetPool(��ȯ�� �������� ��ȣ)
    private void GetPool(int index)
    {
        //index ��ȣ�� �������� ������Ʋ �Ҵ��ϰ� Ȱ��ȭ
        GameObject enemy = poolManager.Get(index);

        //������Ʈ�� ���� Ÿ���� �Ҵ�
        enemy.GetComponent<EnemyState>().finalTarget = finalTarget;

        //������Ʈ�� �������� ��ġ���� ��ȯ
        float spawnX = Random.Range(-3.0f, 3.0f);
        float spawnY = Random.Range(-3.0f, 3.0f);
        enemy.transform.position = new Vector3(transform.position.x + spawnX, transform.position.y + spawnY, transform.position.z);
    }

    


    //---------- ���� �κ� ----------

    private void Awake()
    {
        //������Ʈ���� Ǯ �Ŵ��� �޾ƿ���
        poolManager = GetComponent<PoolManager>();
    }

    private void Update()
    {
        //���� Ÿ�̸�
        timer += Time.deltaTime;

        //�� ��ȯ �κ�
        //���� ���潺 ��Ȳ�̶�� ���� ��ȯ�Ѵ�
        if (StageManager.Instance.isDefense)
        {
            //��Ÿ�Ӹ��� Ǯ�� �Ҵ�
            if (timer > cooldown)
            {
                GetPool(0);
                timer = 0;
            }
        }

        
    }

}
