/* System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Ally.Data
{
    public class AllyProperty : ScriptableObject
    {
        [MenuItem("Tools/MyTool/Do It in C#")]
        static void DoIt()
        {
            EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
        }
    }
}*/

using UnityEngine;
using System;

public class Property : MonoBehaviour
{
    public string Name { get; private set; }
    public Element Element { get; private set; }

    public Property(string name, Element element)
    {
        Name = name;
        Element = element;
    }

    public void DisplayInfo()
    {
        Debug.Log($"Name: {Name}\nElement: {GetElementName()}");
    }

    private string GetElementName()
    {
        switch (Element)
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
}

public enum Element
{
    Water,
    Fire,
    Grass,
    Electric
}

public class PropertyManager : MonoBehaviour
{
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

    private void Start()
    {
        // 랜덤으로 속성 선택
        Element randomElement = GetRandomElement();

        // 랜덤으로 선택된 속성으로 캐릭터 생성
        Property randomProperty = new Property("RandomProperty", randomElement);

        // 캐릭터 정보 출력
        randomProperty.DisplayInfo();
    }
}