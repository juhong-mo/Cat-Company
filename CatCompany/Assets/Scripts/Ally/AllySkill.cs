using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    [SerializeField]
    protected int health = 100; // 예시로 health를 100으로 초기화

    private void Start()
    {
        // 예시로 객체가 생성될 때 AllySkill 스크립트에 접근하여 스킬을 적용
        AllySkill allySkill = GetComponent<AllySkill>();
        if (allySkill != null)
        {
            allySkill.ApplySkill(this);
        }
    }

    public void ApplySkill(Skill skill)
    {
        if (skill != null)
        {
            health -= skill.GetDamage();
            Debug.Log("Health after applying damage: " + health);
        }
        else
        {
            Debug.Log("No skill assigned, no damage applied");
        }
    }
}

public class AllySkill : MonoBehaviour
{
    private Skill skill;

    public void ApplySkill(Ally ally)
    {
        AssignRandomSkill();
        DisplaySkill();
        ally.ApplySkill(skill);
    }

    void Update()
    {
        // 추가적인 로직이 필요한 경우 여기에 작성
    }

    private void AssignRandomSkill()
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
                skill = new FishingMaster(0);
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