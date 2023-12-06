
//�Ʊ� �ִϸ��̼� ó�� ��ũ��Ʈ


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAnimator : MonoBehaviour
{
    //������Ʈ ����
    AllyState state;

    //��������Ʈ
    SpriteRenderer spriter;



    //----- ���� �κ� -----
    private void Awake()
    {
        //ó�� ������ �� �ʱ�ȭ
        state = GetComponent<AllyState>();
        spriter = GetComponent<SpriteRenderer>();
    }


    //�ִϸ��̼� ����
    private void LateUpdate()
    {
        switch (state.state)
        {
            case AllyState.State.Die:
                //�״� �ִϹ̿���
                break;

            case AllyState.State.Idle:
                //���� �ִϸ��̼�
                break;

            case AllyState.State.Move:
                //�̵� �ִϸ��̼�
                break;

            case AllyState.State.Attack:
                //���� �ִϸ��̼�
                break;

            default:
                break;
        }

        //Ÿ�� ���⿡ ���� ��������Ʈ ������
        if (state.curTarget) spriter.flipX = state.curTarget.position.x < transform.position.x;
    }

}
