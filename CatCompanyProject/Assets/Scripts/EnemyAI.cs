using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    //      ����
    //      ���̾��ũ
    LayerMask layerAlly;
    LayerMask layerEnemy;
    LayerMask layerStructure;

    //      �ۺ� ����
    public GameObject target;           //����Ÿ��, ���̽�
    public float speed = 1;             //�̵��ӵ�
    public float maxScanDistance = 1;   //���ݴ���� �����ϴ� �ִ� �Ÿ�

    //      AI ���� �Լ��� ����
    Vector2 vectorTargetDirection;      //Ÿ���� �ִ� ����(�¿�), x���� 1,0,-1 �� �ϳ�, y���� �׻� 0
    EnumState state;                    //���� ���� (�̵�, ����)

    enum EnumState
    {
        Move,
        Attack
    }



    private void Awake()
    {
        //      ���̾��ũ �Ҵ�
        layerAlly = 1 << LayerMask.NameToLayer("Ally");
        layerEnemy = 1 << LayerMask.NameToLayer("Enemy");
        layerStructure = 1 << LayerMask.NameToLayer("Structure");
    }



    private void Start()
    {
        //      �����
        if (target == null)
        {
            Debug.Log("Set target object");
        }
    }



    private void FixedUpdate()
    {

        //      Ÿ���� �ִ� ���� ����
        vectorTargetDirection = new Vector2(System.Math.Sign(target.transform.position.x - transform.position.x), 0);

        //      ���� �ִ��� ������ ��ĵ, ������ �̵�, ������ ���� ���·� ��ȯ
        RaycastHit2D scanHit = Physics2D.Raycast(transform.position, vectorTargetDirection, maxScanDistance, layerAlly | layerStructure);
        if (scanHit.transform == null)
        {
            state = EnumState.Move;
        }
        else
        {
            state = EnumState.Attack;
        }
                
    }



    private void Update()
    {

        //      �̵�
        if (state == EnumState.Move)
        {
            Vector2 vectorTargetMovement = vectorTargetDirection * speed * Time.deltaTime;
            transform.Translate(vectorTargetMovement);
        }

        //      ����
        if (state == EnumState.Attack)
        {
            Debug.Log("����");
        }
    }

}