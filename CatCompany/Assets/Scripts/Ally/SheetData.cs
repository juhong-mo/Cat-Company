using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetData : MonoBehaviour
{
    public TextAsset catcompany;
    private AllData datas;

    private void Awake()
    {
        datas = JsonUtility.FromJson<AllData>(catcompany.text);

        foreach (var VARIABLE in datas.TEST)
        {
            print(VARIABLE.name);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class AllData
{
    public CatData[] TEST;
}
[System.Serializable]
public class CatData
{
    public string name;
    public int health;
    public int attack;
}
