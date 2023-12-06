using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Gold, HP, StageLevel, IsDefense, GameOver }
    public InfoType type;

    Text myText;

    private void Awake()
    {
        myText = GetComponent<Text>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Gold:
                myText.text = string.Format("Gold : {0:F0}", StageManager.Instance.gold);
                break;

            case InfoType.HP:
                myText.text = string.Format("HP : {0:F0}", StageManager.Instance.hp);
                break;

            case InfoType.StageLevel:
                myText.text = string.Format("Stage Level : {0:F0}", StageManager.Instance.stageLevel);
                break;


            case InfoType.IsDefense:
                if (StageManager.Instance.isDefense) myText.text = "���� ���� ���� ��!";
                else myText.text = "������ ���� �ð�";
                break;

                //�ӽ� ���� ����
            case InfoType.GameOver:
                if (StageManager.Instance.hp < 0) myText.gameObject.SetActive(true);
                break;
        }
    }

}
