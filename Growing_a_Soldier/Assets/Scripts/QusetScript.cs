using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QusetScript : MonoBehaviour
{
   public TotalState total;
    public int kill;
    public int QusetLV;
    public int QusetKill;
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public int SkillDie;
    public int QusetClearNum;
    public int QusetStage;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("Kill") == "")
        {

        }
        else
        {
            kill = int.Parse(PlayerPrefs.GetString("Kill"));
            SkillDie = PlayerPrefs.GetInt("SkillDie");
            QusetClearNum = PlayerPrefs.GetInt("QusetClearNum");
            QusetStage = PlayerPrefs.GetInt("QusetStage");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        QusetKill = total.QusetNum;
        text1.text = $"좀비{kill}/{QusetKill} 마리 처치";
        text2.text = $"폭발 스킬로 {SkillDie}/500 마리 처치";
        text3.text = $"퀘스트 {QusetClearNum}/5 완료";
        text4.text = $"{QusetStage}/5 스테이지마다 보상 ";
        PlayerPrefs.SetString("Kill", kill.ToString());
        PlayerPrefs.SetInt("SkillDie", SkillDie);
        PlayerPrefs.SetInt("QusetClearNum", QusetClearNum);
        PlayerPrefs.SetInt("QusetStage", QusetStage);
    }
    public void But()
    {
        if (kill >= QusetKill)
        {
           total.MyCoin = QusetKill * (QusetLV + 4);
            QusetLV++;
            if(QusetLV > 7)
            {
                QusetLV = 7;
            }
            kill -= QusetKill;
            QusetClearNum++;
        }
    }
    public void But1()
    {
        if (SkillDie >= 500)
        {
            total.MyCoin += 3000000;
            SkillDie -= 500;
            QusetClearNum++;
        }
    }
    public void But2()
    {
        if (QusetClearNum >=5)
        {
            QusetClearNum -= 5;
            total.MyCoin = 1000000;
        }
    }
    public void But3()
    {
        if (QusetStage >= 5)
        {
            QusetStage -= 5;
            total.MyCoin = QusetStage * 100;
        }
    }
}
