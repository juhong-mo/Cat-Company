
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
    public float readyTime = 0;     //ù��° �������� ���۱��� �غ� �ð�
    public float defenseTime = 10;  //�ѹ��� ���潺�� �ҿ��ϴ� �ð�
    public float restTime = 5;     //�޽� �ð�
    public float curTime = 0;       //�������� ���� ���� �ð�

    //���� �������� ����
    public int stageLevel = 0;


    //���� �÷��� ����
    public int gold = 100;          //��
    public int hp = 1000;           //�÷��̾� ü��


    //-------------------- �޼ҵ�� --------------------

    //�������� �Ŵ��� �ʱ�ȭ �޼ҵ�
    public void Initialize()
    {
        isDefense = false;
        curTime = readyTime;
        stageLevel = 0;
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


    //-------------------- ���� �κ� --------------------

    private void Awake()
    {
        //�ν��Ͻ��� ó�� ������ �� �ʱ�ȭ
        Initialize();
    }


    //�������� ���� �׻� ����
    private void Update()
    {
        //�������� Ÿ�̸�
        stageTimer();

    }

    
}