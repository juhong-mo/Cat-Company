using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct EData
{
    public string name;
    public string info;
    public float hp;
    public float damage;
    public float armor;
    public float speed;
    public float cooldown;
    public float attackRange;
    public float scanRange;
}

public abstract class EnemyData : MonoBehaviour
{
    public EData data;

    public abstract void Init();

}
