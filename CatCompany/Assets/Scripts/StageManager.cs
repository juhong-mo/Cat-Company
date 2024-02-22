
//�������� �Ŵ���(�̱���)
//���������� ������ �����Ѵ�
//���������� ���潺 ��Ȳ�� �޽� ��Ȳ�� ��ȯ
//���潺�� ������ ������ �������� ���� +1
//���� ���������� ������ ����


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageManager : Singleton<StageManager>
{

    //���� �������� ��Ȳ
    //true �� �� ���潺
    public bool isDefense = false;

    //�������� �ð� ������
    public float readyTime = 30;     //�������� ���۱��� �غ� �ð�
    public float defenseTime = 30;  //�ѹ��� ���潺�� �ҿ��ϴ� �ð�
    public float curTime = 0;       //�������� ���� ���� �ð�

    //���� �������� ����
    public int stageLevel = 0;

    //���� �÷��� ����
    public int gold = 100;          //��
    public int hp = 1000;           //�÷��̾� ü��

    public int curEnemy = 0;

    //�Ʊ� ���� UI ������Ʈ
    public GameObject pawnSpawn;
    public GameObject royalSpawn;


    //-------------------- �޼ҵ�� --------------------

    //�������� �Ŵ��� �ʱ�ȭ �޼ҵ�
    public void Initialize()
    {
        isDefense = false;
        curTime = readyTime;
        stageLevel = 0;
        pawnSpawn.gameObject.SetActive(true);
        royalSpawn.gameObject.SetActive(true);
    }

    //�������� Ÿ�̸�
    //������Ʈ���� ����
    //���� �������� �ð��� �����Ų��
    //���潺�� �޽��� ��ȯ�Ѵ�
    //�������� ������ ��½�Ų��
    private void stageTimer()
    {
        //���� ���� �ð� -1��
        curTime -= Time.deltaTime;

        //���� �ð��� 0�ʺ��� ������ �������� ��Ȳ�� ��ȯ�Ѵ�
        //���潺 Ȱ��ȭ -> �������� ���� ���
        if (curTime < 0)
        {
            if (isDefense && curEnemy == 0)
            {
                isDefense = false;
                curTime = readyTime;
                gold += 200;
                pawnSpawn.gameObject.SetActive(true);
                royalSpawn.gameObject.SetActive(true);
            }
            else if (!isDefense)
            {
                isDefense = true;
                curTime = defenseTime;
                stageLevel += 1;
                pawnSpawn.gameObject.SetActive(false);
                royalSpawn.gameObject.SetActive(false);
            }
        }
    }

    //-------------------- ���� �κ� --------------------

    private void Awake()
    {
        //�ν��Ͻ��� ó�� ������ �� �ʱ�ȭ
        base.Awake();
        Initialize();
    }


    //�������� ���� �׻� ����
    private void Update()
    {
        //�������� Ÿ�̸�
        stageTimer();

    }

    
}