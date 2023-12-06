
//�� ������Ʈ�� ���� ���¸� �����ϴ� ��ũ��Ʈ
//������Ʈ�� ü��, ���ݷ� ���� ���¸� �����Ѵ�
//������Ʈ�� ����, Ž�� ���� ���¸� �����Ѵ�
//������Ʈ�� Ÿ���� �����Ѵ�


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    //������Ʈ�� �⺻ �������ͽ� ����
    //������Ʈ��  data�� ��ӹ޴� ��ũ��Ʈ�� ������Ʈ�� ����ְ�, �� ������Ʈ�� enemyData�� �Ҵ��Ѵ�.
    public EnemyData enemyData;

    //������Ʈ�� ���� ���
    public enum State
    {
        Die,
        Idle,
        Move,
        Attack
    }

    //������Ʈ�� ���� Ÿ��
    //����Ƽ���� �Ҵ��Ѵ�
    public Transform finalTarget;




    //���� ���µ� ����
    public State state;             //���� ����
    public Transform curTarget;    //���� Ÿ��
    public float curHp;             //���� ü��

    public LayerMask targetLayer;   //Ÿ�� ���̾�



    //----- �޼ҵ�� -----

    //Ÿ�� ��ĵ �޼ҵ�
    //��ĵ ���� ������ ������Ʈ�� ��ĵ
    //Scan(��ĵ ����, Ÿ�� ���̾�)
    //���� ����� Ÿ���� Transform�� ��ȯ
    private RaycastHit2D[] targets;     //��ĵ�� Ÿ�ٵ��� �迭
    private Transform nearsetTarget;    //���� ����� Ÿ��
    public Transform Scan(float scanRange, LayerMask targetLayer)
    {
        //��ĵ�� Ÿ�ٵ��� �迭
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);

        //���� ����� Ÿ���� ����
        nearsetTarget = null;
        float diff = 1000;
        foreach (RaycastHit2D target in targets)
        {
            Vector3 targetPosition = target.transform.position;
            float curDiff = Vector3.Distance(targetPosition, transform.position);

            if (curDiff < diff)
            {
                diff = curDiff;
                nearsetTarget = target.transform;
            }
        }

        return nearsetTarget;
    }


    //���� üũ �޼ҵ�
    private State CheckState()
    {
        if (curHp <= 0) return State.Die;                   //hp�� 0���� ������ ����
        if (curTarget == null) return State.Idle;           //Ÿ���� ������ ���޻���

        //Ÿ�ٰ��� �Ÿ� üũ
        float targetDis;
        targetDis = Vector2.Distance(curTarget.position, transform.position);

        if (targetDis < enemyData.data.attackRange) return State.Attack;    //���� ���� �ȿ� Ÿ���� ������ ����
        return State.Move;                                                  //���� ���� �ۿ� Ÿ���� ������ �̵�
    }


    //������ �Դ� �޼ҵ�
    public void Hit(float damage)
    {
        curHp -= damage;
    }


    //----- ���� �κ� -----
    private void Awake()
    {
        //ó�� ������ ��

        //�� ������ �ʱ�ȭ
        enemyData.Init();

        //���� hp �ʱ�ȭ
        curHp = enemyData.data.hp;

        //���� �ʱ�ȭ
        state = State.Idle;

        //Ÿ�� �ʱ�ȭ
        curTarget = finalTarget;
    }

    private void OnEnable()
    {
        //Ȱ��ȭ�� ������

        //���� hp �ʱ�ȭ
        curHp = enemyData.data.hp;

        //���� �ʱ�ȭ
        state = State.Idle;

        //Ÿ�� �ʱ�ȭ
        curTarget = finalTarget;
    }

    private void Update()
    {
        //���� Ÿ�� ����
        curTarget = Scan(enemyData.data.scanRange, targetLayer);
        //Ÿ���� ����ٸ� ���� Ÿ���� �Ҵ�
        if (curTarget == null) curTarget = finalTarget;
        //���� ���� ����
        state = CheckState();
    }



    //�ӽ� ����
    private void LateUpdate()
    {
        //Active false
        if (curHp < 0)
        {
            gameObject.SetActive(false);
            StageManager.Instance.gold += 10;
        }
    }
}
