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
                TutorialText.text = "하단 우측버튼에 있는 해골버튼을 눌러보세요 보상:<color=#FFFF00>20골드</color>";
                QusetMoney = 20;
                break;
            case 2:
                TutorialText.text = "보유하고있는 돈으로 유닛 업그레이드르 해보세요 보상:<color=#FFFF00>50골드</color>";
                QusetMoney = 50;
                break;
            case 3:
                TutorialText.text = "돈을모아 영웅 유닛을 사보세여 보상:<color=#FFFF00>1000골드</color>";
                QusetMoney = 1000;
                break;
            case 4:
                TutorialText.text = "전투에서 영웅 유닛의 고유스킬을 사용해보세요 보상:<color=#FFFF00>1000골드</color>";
                QusetMoney = 1000;
                break;
            case 5:
                TutorialText.text = "돈을 모아 아이템을 사보세요 보상:<color=#FFFF00>10000골드</color>";
                QusetMoney = 10000;
                break;
            case 6:
                TutorialText.text = "인벤토리에서 아이템을 장착해보세요 보상:<color=#FFFF00>10000골드</color>";
                QusetMoney = 10000;
                break;
            case 7:
                TutorialText.text = "1000라운드에 도달해보세요 보상:<color=#FFFF00>10억골드</color>";
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
