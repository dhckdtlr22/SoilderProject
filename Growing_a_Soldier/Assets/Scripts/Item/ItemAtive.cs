using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemAtive : MonoBehaviour
{
    public float Curtime;
    public float Cooltime;
    public Sprite[] imgs;
    public Image img;
    public Inventori invent;
    public TotalState total;
    public AttackZone Zone;
    public EnemyMaker enemyMaker;
    public GameObject Boom;
    public GameObject shield;
    public GameObject WallTr;
    public EpicSkill[] skill;
    // Start is called before the first frame update
    void Start()
    {
        enemyMaker = GameObject.Find("EnemyMake").GetComponent<EnemyMaker>();
        total = GameObject.Find("TotalState").GetComponent<TotalState>();
        Zone = GameObject.Find("AttackZone").GetComponent<AttackZone>();
    }

    // Update is called once per frame
    void Update()
    {
            Curtime += Time.deltaTime;
            switch (invent.itemNum)
            {
                case 0:
                img.GetComponent<Image>().sprite = imgs[0];
                img.GetComponent<Image>().fillAmount = Curtime / Cooltime;
                break;
                case 1:
                img.GetComponent<Image>().sprite = imgs[1];
                img.GetComponent<Image>().fillAmount = Curtime / Cooltime;
                break;
                case 2:
                img.GetComponent<Image>().sprite = imgs[2];
                img.GetComponent<Image>().fillAmount = Curtime / Cooltime;
                break;
                case 3:
                img.GetComponent<Image>().sprite = imgs[3];
                img.GetComponent<Image>().fillAmount = Curtime / Cooltime;
                break;
                case 4:
                img.GetComponent<Image>().sprite = imgs[4];
                img.GetComponent<Image>().fillAmount = 1f;
                break;
                case 5:
                img.GetComponent<Image>().sprite = imgs[5];
                img.GetComponent<Image>().fillAmount = 1f;
                break;
                case 6:
                img.GetComponent<Image>().sprite = imgs[6];
                img.GetComponent<Image>().fillAmount = 1f;
                break;
                case 7:
                img.GetComponent<Image>().sprite = imgs[7];
                img.GetComponent<Image>().fillAmount = 1f;
                break;

                default:
                img.GetComponent<Image>().sprite = imgs[8];
                img.GetComponent<Image>().fillAmount = 1f;
                break;
            }
        for (int i = 0; i < 3; i++)
        {
            if(GameObject.Find($"EpicUnit{i}") == true)
            {
                skill[i] = GameObject.Find($"EpicUnit{i}").GetComponent<EpicSkill>();
            }
            else
            {
                skill[i] = null;
            }
            
        }
    }
    public void Ative()
    {
        if(Curtime > Cooltime)
        {
            Curtime = 0;
            switch (invent.itemNum)
            {
                case 0:
                 total.CastleHp = total.CastleHp + (int)(total.CastleHpMax * 0.2f);
                    break;
                case 1:
                   GameObject boom = Instantiate(Boom, Zone.transform.position, Zone.transform.rotation);
                    Destroy(boom, 1f);
                    break;
                case 2:
                    GameObject Shield = Instantiate(shield, WallTr.transform.position, WallTr.transform.rotation);
                    Destroy(Shield, 3f);
                    break;
                case 3:
                    GetComponent<Image>().sprite = imgs[3];//º¸°­
                    for (int i = 0; i < skill.Length; i++)
                    {
                        if(skill[i] == true )
                        {
                            skill[i].Skillcur = skill[i].SkillCool;
                        }
                    }
                    break;
               
            }
            
        }
       
    }
    
}
