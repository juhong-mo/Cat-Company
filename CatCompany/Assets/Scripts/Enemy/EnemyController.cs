
//�� ������Ʈ�� �ΰ�����
//state�� ���� �ൿ�Ѵ�

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    //������Ʈ ����
    private EnemyState state;

    //������Ʈ ���� ȿ��
    private Rigidbody2D rigid;

    //���� ��Ÿ��
    private float coolTime;



    //----- ���� �κ� -----

    private void Awake()
    {
        //������Ʈ ó�� ������ �� �ʱ�ȭ
        state = GetComponent<EnemyState>();
        rigid = GetComponent<Rigidbody2D>();

        coolTime = 0;
    }


    private void OnEnable()
    {
        //Ȱ��ȭ�� �� �ʱ�ȭ
        coolTime = 0;
    }



    //Enemy�� �ΰ����� ����
    private void FixedUpdate()
    {
        //���� ��Ÿ�� ������Ʈ
        coolTime += Time.fixedDeltaTime;

        
        switch (state.state)
        {
            case EnemyState.State.Die:
                //����
                break;

            case EnemyState.State.Idle:
                //���� ����
                break;

            case EnemyState.State.Move:
                Vector2 dirVec = state.curTarget.position - transform.position;                   //�̵� ����
                Vector2 moveVec = dirVec.normalized * state.enemyData.data.speed * Time.fixedDeltaTime;     //�̵� �ӵ�
                rigid.MovePosition(rigid.position + moveVec);                                               //���� �̵�
                break;

            case EnemyState.State.Attack:
                //���� ��Ÿ���� ���Ҵٸ� ����
                if (coolTime > state.enemyData.data.cooldown)      
                {
                    //��������ŭ ����
                    if (state.curTarget != state.finalTarget)           //�ǹ��� �ƴ� ��
                        state.curTarget.GetComponent<AllyState>().Hit(state.enemyData.data.damage);

                    if (state.curTarget == state.finalTarget)           //Base �� ��
                        StageManager.Instance.hp -= (int)state.enemyData.data.damage;

                    //���� ��Ÿ�� �ʱ�ȭ
                    coolTime = 0;
                }
                break;

            default:
                break;
        }

    }

    private void Update()
    {
        //����ȿ��, ������Ʈ�� �̲����� ����
        rigid.velocity = Vector2.zero;
    }
}
