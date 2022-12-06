using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonMgr : MonoBehaviour
{
    public EnemyMaker enemyMaker;
    public GameObject ClosePop;
    public GameObject Cancel;
    public GameObject Option;
    public GameObject Shoppop;
    public GameObject Invent;
    public TotalState total;
    public Popup pop;
    public tutorial Tutorial;
    public GameObject battleStart;
    public GameObject Text;
    public GameObject Quset;
    public GameObject Day;
    public void Start()
    {
        pop = GetComponent<Popup>();
        total = GameObject.Find("TotalState").GetComponent<TotalState>();
    }
    public void BattleBut()
    {
        if(Tutorial.Quest == 1)
        {
            Tutorial.QuestClear = true;
        }
        battleStart.SetActive(true);
        Text.GetComponent<Text>().text = $"ROUND START\nSTAGE{total.Stage}";
        Text.SetActive(true);
        pop.Battle();
        enemyMaker.IsBattle = true;
        enemyMaker.MonsterCount = 0;
    }
    public void  Shop()
    {
        Shoppop.SetActive(true);
        Cancel.SetActive(true);
    }
    public void Inventro()
    {
        Invent.SetActive(true);
        Cancel.SetActive(true);
    }
    public void QusetPop()
    {
        Quset.SetActive(true);
        Cancel.SetActive(true);
    }
    public void DayPop()
    {
        Day.SetActive(true);
        Cancel.SetActive(true);
    }
    public void Close()
    {
        Shoppop.SetActive(false);
        Invent.SetActive(false);
        Cancel.SetActive(false);
        Quset.SetActive(false);
        Day.SetActive(false);
    }
    public void ClosePopUp()
    {
        ClosePop.SetActive(false);
        pop.Close();
    }
    public void Skill01()
    {
       
        if (GameObject.Find("EpicUnit0") == true)
        {
            
            GameObject.Find("EpicUnit0").GetComponent<EpicSkill>().Skill01();
        }

    }
    public void Skill02()
    {
        
        if (GameObject.Find("EpicUnit1") == true)
        {
            
            GameObject.Find("EpicUnit1").GetComponent<EpicSkill>().Skill02();
        }

    }
    public void Skill03()
    {
        
        if (GameObject.Find("EpicUnit2") == true)
        {
           
            GameObject.Find("EpicUnit2").GetComponent<EpicSkill>().Skill03();
        }

    }
    public void OptionPop()
    {
        Cancel.SetActive(true);
        Option.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        Time.timeScale = 1;
        Option.SetActive(false);
        Cancel.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        if(enemyMaker.IsBattle ==true)
        {
            enemyMaker.Restarted();
            Option.SetActive(false);
            Cancel.SetActive(false);
            total.CastleHp = total.CastleHpMax;
            enemyMaker.KillCount = 0;
        }
       
    }
    public void Robi()
    { 
        if(enemyMaker.IsBattle == true)
        {
            enemyMaker.KillCount = 0;
            enemyMaker.IsBattle = false;
            enemyMaker.IsClear = false;
            Cancel.SetActive(false);
            Option.SetActive(false);
            Time.timeScale = 1;
            ClosePopUp();
        }
    }
    
}
