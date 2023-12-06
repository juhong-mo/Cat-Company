//���� �ִϸ��̼��� ó���ϴ� ��ũ��Ʈ


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    //������Ʈ ����
    EnemyState state;

    //��������Ʈ
    SpriteRenderer spriter;



    //----- ���� �κ� -----
    private void Awake()
    {   
        //ó�� ������ �� �ʱ�ȭ
        state = GetComponent<EnemyState>();
        spriter = GetComponent<SpriteRenderer>();
    }


    //�ִϸ��̼� ����
    private void LateUpdate()
    {
        switch (state.state)
        {
            case EnemyState.State.Die:
                //�״� �ִϹ̿���
                break;

            case EnemyState.State.Idle:
                //���� �ִϸ��̼�
                break;

            case EnemyState.State.Move:
                //�̵� �ִϸ��̼�
                break;

            case EnemyState.State.Attack:
                //���� �ִϸ��̼�
                break;

            default:
                break;
        }

        //Ÿ�� ���⿡ ���� ��������Ʈ ������
        if (state.curTarget) spriter.flipX = state.curTarget.position.x < transform.position.x;
    }

}
