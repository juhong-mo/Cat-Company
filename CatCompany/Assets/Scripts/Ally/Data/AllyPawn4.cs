using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyPawn4 : AllyData
{
    public override void Init()
    {
        data.name = "근접공격 아군 테스트용 ";
        data.info =
            "아군\n" +
            "근거리 공격형";

        data.hp = 400;
        data.damage = 5;
        data.armor = 80;
        data.speed = 3.0f;
        data.cooldown = 2;
        data.attackRange = 1.0f;
        data.scanRange = 10;
    }
}
