using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyPawn2 : AllyData
{
    public override void Init()
    {
        data.name = "�������� �Ʊ� �׽�Ʈ�� ";
        data.info =
            "�Ʊ�\n" +
            "�ٰŸ� ������";

        data.hp = 200;
        data.damage = 100;
        data.armor = 80;
        data.speed = 1.0f;
        data.cooldown = 2;
        data.attackRange = 1.5f;
        data.scanRange = 7;
    }
}
