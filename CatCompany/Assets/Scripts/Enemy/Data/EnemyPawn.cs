using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPawn : EnemyData
{
    public override void Init()
    {
        data.name = "�⺻ ����";
        data.info = 
            "�⺻���� ��\n" +
            "�ٰŸ� ������";

        data.hp = 100;
        data.damage = 15;
        data.armor = 80;
        data.speed = 1.2f;
        data.cooldown = 2;
        data.attackRange = 1;
        data.scanRange = 5;
    }
}
