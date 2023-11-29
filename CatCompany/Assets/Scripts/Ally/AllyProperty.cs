using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AllyProperty : MonoBehaviour
{
    public string pName = "not yet";
    public Element element;

    public enum Element
    {
        Water,
        Fire,
        Grass,
        Electric
    }

    private void Start()
    {
        // 랜덤으로 속성 선택
        element = GetRandomElement();
        pName = GetElementName();

        // 캐릭터 정보 출력
        DisplayInfo();
    }

    public void DisplayInfo()
    {
        Debug.Log($"Name: {pName}\nElement: {GetElementName()}");
    }

    private string GetElementName()
    {
        switch (element)
        {
            case Element.Water:
                return "Water";
            case Element.Fire:
                return "Fire";
            case Element.Grass:
                return "Grass";
            case Element.Electric:
                return "Electric";
            default:
                return "Unknown";
        }
    }

    private Element GetRandomElement()
    {
        // Seed 설정
        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);

        // 0부터 3까지 중에서 랜덤으로 선택
        int randomValue = UnityEngine.Random.Range(0, 4);

        switch (randomValue)
        {
            case 0:
                return Element.Water;
            case 1:
                return Element.Fire;
            case 2:
                return Element.Grass;
            case 3:
                return Element.Electric;
            default:
                return Element.Water; // 기본적으로 Water로 설정
        }
    }

}
