using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySkill : MonoBehaviour
{
    private Skill skill;
    void Start()
    {
        AssignRandomSkill();
        DisplaySkill();
    }

    void Update()
    {

    }

    private void AssignRandomSkill()
    {
        System.Random random = new System.Random();
        int skillIndex = random.Next(1, 6);

        skill = null;

        switch (skillIndex)
        {
            case 1:
                skill = new Fireball();
                break;
            case 2:
                skill = new PillarOfFire();
                break;
            case 3:
                skill = new SteamEngine();
                break;
            case 4:
                skill = new Fireworks();
                break;
            case 5:
                skill = new FishingMaster();
                break;
            default:
                Debug.Log("Invalid skill index");
                break;
        }
    }

    private void DisplaySkill()
    {
        if (skill != null)
        {
            skill.Display();
            Debug.Log("Damage: " + skill.GetDamage());
        }
        else
        {
            Debug.Log("No skill assigned");
        }
    }
}

public abstract class Skill
{
    public abstract void Display();
    public abstract int GetDamage();
}

public class Fireball : Skill
{
    public override void Display()
    {
        Debug.Log("Skill: Fireball");
    }

    public override int GetDamage()
    {
        return 50;
    }
}

public class PillarOfFire : Skill
{
    public override void Display()
    {
        Debug.Log("Skill: Pillar of Fire");
    }

    public override int GetDamage()
    {
        return 20;
    }
}

public class SteamEngine : Skill
{
    public override void Display()
    {
        Debug.Log("Skill: Steam Engine");
    }

    public override int GetDamage()
    {
        return 40;
    }
}

public class Fireworks : Skill
{
    public override void Display()
    {
        Debug.Log("Skill: Fireworks");
    }

    public override int GetDamage()
    {
        return 5;
    }
}

public class FishingMaster : Skill
{
    public override void Display()
    {
        Debug.Log("Skill: Fishing Master Kang Taegong");
    }

    public override int GetDamage()
    {
        return 80;
    }
}