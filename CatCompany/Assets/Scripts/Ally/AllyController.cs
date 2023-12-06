
//�Ʊ��� �ΰ����� ��ũ��Ʈ
//state�� ���� �ൿ�Ѵ�

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyController : MonoBehaviour
{
    //������Ʈ ����
    private AllyState state;

    //������Ʈ ���� ȿ��
    private Rigidbody2D rigid;

    //���� ��Ÿ��
    private float coolTime;



    //----- ���� �κ� -----

    private void Awake()
    {
        //������Ʈ ó�� ������ �� �ʱ�ȭ
        state = GetComponent<AllyState>();
        rigid = GetComponent<Rigidbody2D>();

        coolTime = 0;
    }


    private void OnEnable()
    {
        //Ȱ��ȭ�� �� �ʱ�ȭ
        coolTime = 0;
    }


    //���콺�� ��Ƽ� �̵�
    private void OnMouseDrag()
    {
        Vector2 pos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = (Vector3)pos;
    }


    //Enemy�� �ΰ����� ����
    private void FixedUpdate()
    {
        //���� ��Ÿ�� ������Ʈ
        coolTime += Time.fixedDeltaTime;


        switch (state.state)
        {
            case AllyState.State.Die:
                //����
                break;

            case AllyState.State.Idle:
                //���� ����
                break;

            case AllyState.State.Move:
                Vector2 dirVec = state.curTarget.position - transform.position;                   //�̵� ����
                Vector2 moveVec = dirVec.normalized * state.allyData.data.speed * Time.fixedDeltaTime;     //�̵� �ӵ�
                rigid.MovePosition(rigid.position + moveVec);                                               //���� �̵�
                break;

            case AllyState.State.Attack:
                //���� ��Ÿ���� ���Ҵٸ� ����
                if (coolTime > state.allyData.data.cooldown)
                {
                    //��������ŭ ����
                    state.curTarget.GetComponent<EnemyState>().Hit(state.allyData.data.damage);

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
