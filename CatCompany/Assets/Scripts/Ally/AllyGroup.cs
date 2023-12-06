
//�׷� ���� �ý���
//���� ��


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyGroup : MonoBehaviour
{
    //����ũ(�Ʊ�)
    public LayerMask targetLayer;

    //���� �׷�
    public List<Transform> group = new List<Transform>();


    //���� �ĺ� (�����̶� ����ִ� ��)
    Transform temp;

    //���϶� �����̶� ������� ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        temp = collision.transform;
    }

    //���϶� �����̶� ������ ��
    private void OnTriggerExit2D(Collider2D collision)
    {
        temp = null;
    }


    //���콺 ���� �� ����
    private void OnMouseUp()
    {
        //�׷� ����Ʈ�� �߰�
        if (temp) group.Add(temp);
    }


    //�׷�� ���̱�
    private void Update()
    {
        foreach(Transform target in group)
        {
            //Ÿ���̶� �Ÿ�
            float dis = Vector3.Distance(target.position, transform.position);

            

            //�Ÿ� �־����� �������
            if(dis > 3.0)
            {
                //Ÿ�� ����
                Vector3 dir = Vector3.Normalize(transform.position - target.position);
                target.Translate(new Vector3(dir.x * 0.05f, dir.y * 0.05f, 0));
            }
        }
    }


}
