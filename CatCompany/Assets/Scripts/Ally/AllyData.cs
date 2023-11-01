using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct AData
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

public abstract class AllyData : MonoBehaviour
{
    public AData data;

    public abstract void Init();

}
