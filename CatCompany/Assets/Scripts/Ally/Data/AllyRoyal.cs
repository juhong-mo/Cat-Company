using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyRoyal : AllyData
{
    public override void Init()
    {
        data.name = "�ӽ� ����";
        data.info =
            "�Ʊ�\n" +
            "����";

        data.hp = 200;
        data.damage = 100;
        data.armor = 80;
        data.speed = 1.0f;
        data.cooldown = 2;
        data.attackRange = 1.5f;
        data.scanRange = 5;
    }
}
