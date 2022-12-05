using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    public bool IsTutorial;
    public Text TutorialText;
    public Image img;
    public Sprite[] Sprite;
    public int Quest;
    public bool QuestClear;
    public int QusetMoney;
    TotalState total;
    public GameObject tutorialgaid;
    // Start is called before the first frame update
    void Start()
    {
        total = GameObject.Find("TotalState").GetComponent<TotalState>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (Quest)
        {
            case 1:
                TutorialText.text = "�ϴ� ������ư�� �ִ� �ذ��ư�� ���������� ����:<color=#FFFF00>20���</color>";
                QusetMoney = 20;
                break;
            case 2:
                TutorialText.text = "�����ϰ��ִ� ������ ���� ���׷��̵帣 �غ����� ����:<color=#FFFF00>50���</color>";
                QusetMoney = 50;
                break;
            case 3:
                TutorialText.text = "������� ���� ������ �纸���� ����:<color=#FFFF00>1000���</color>";
                QusetMoney = 1000;
                break;
            case 4:
                TutorialText.text = "�������� ���� ������ ������ų�� ����غ����� ����:<color=#FFFF00>1000���</color>";
                QusetMoney = 1000;
                break;
            case 5:
                TutorialText.text = "���� ��� �������� �纸���� ����:<color=#FFFF00>10000���</color>";
                QusetMoney = 10000;
                break;
            case 6:
                TutorialText.text = "�κ��丮���� �������� �����غ����� ����:<color=#FFFF00>10000���</color>";
                QusetMoney = 10000;
                break;
            case 7:
                TutorialText.text = "1000���忡 �����غ����� ����:<color=#FFFF00>10����</color>";
                QusetMoney = 1000000000;
                break;
            default:
                tutorialgaid.SetActive(false);
                break;

        }
        if(QuestClear ==true)
        {
            img.sprite = Sprite[1];
        }
        else
        {
            img.sprite = Sprite[0];
        }
        if (total.Stage >= 1000)
        {
            QuestClear = true;
        }
    }
    public void QuestCheck()
    {
        if(QuestClear== true)
        {
            total.MyCoin += QusetMoney;
            QuestClear = false;
            Quest++;
        }
    }

}
