using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;


public class Ally : MonoBehaviour
{
    private void Start()
    {
        // 객체가 생성될 때 스킬을 적용
        AllySkill allySkill = GetComponent<AllySkill>();
        if (allySkill != null)
        {
            allySkill.AssignRandomSkill(); // 초기 스킬 할당
        }
    }

    private void Update()
    {
        // 키 입력 스킬 발동
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ApplySkill();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateSkill();
        }
    }

    private void ApplySkill()
    {
        AllySkill allySkill = GetComponent<AllySkill>();
        if (allySkill != null)
        {
            allySkill.ApplySkill();
        }
    }

    private void ActivateSkill()
    {
        AllySkill allySkill = GetComponent<AllySkill>();
        if (allySkill != null)
        {
            allySkill.ActivateSkill();
        }
    }
}

public class AllySkill : MonoBehaviour
{
    private Skill skill;

    public void AssignRandomSkill()
    {
        int skillIndex = UnityEngine.Random.Range(1, 6);

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

    public void ApplySkill()
    {
        if (skill != null)
        {
            Enemy enemy = FindObjectOfType<Enemy>(); // Enemy 찾아서 사용
            if (enemy != null)
            {
                int health = enemy.GetHealth();
                health -= skill.GetDamage();
                Debug.Log("Enemy's health after applying damage: " + health);
            }
            else
            {
                Debug.Log("No enemy found");
            }
        }
        else
        {
            Debug.Log("No skill assigned, no damage applied");
        }
    }

    public void ActivateSkill()
    {
        if (skill != null)
        {
            Debug.Log("Activating skill:");
            skill.Display();
            Debug.Log("Damage: " + skill.GetDamage());
            // 추가 스킬 발동
        }
        else
        {
            Debug.Log("No skill assigned");
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