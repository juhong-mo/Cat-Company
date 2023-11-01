using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyPawn : AllyData
{
    public override void Init()
    {
        data.name = "근접공격 아군";
        data.info =
            "아군\n" +
            "근거리 공격형";

        data.hp = 100;
        data.damage = 80;
        data.armor = 80;
        data.speed = 1.0f;
        data.cooldown = 2;
        data.attackRange = 1.5f;
        data.scanRange = 5;
    }
}
