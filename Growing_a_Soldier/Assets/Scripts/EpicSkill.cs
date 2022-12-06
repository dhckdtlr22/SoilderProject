using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EpicSkill : MonoBehaviour
{
    public float Skillcur;
    public float SkillCool;

    public float Stuncur;
    public float Skill03Cool;


    public bool IsSkill01;
    public bool IsStun;
    public TotalState total;
    public EnemyMaker enemyMaker;
    public AttackZone zone;
    public tutorial Tutorial;
    // Start is called before the first frame update
    void Start()
    {
        zone = GameObject.Find("AttackZone").GetComponent<AttackZone>();
        total = GameObject.Find("TotalState").GetComponent<TotalState>();
        enemyMaker = GameObject.Find("EnemyMake").GetComponent<EnemyMaker>();
        Tutorial = GameObject.Find("Tutorial").GetComponent<tutorial>();
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyMaker.IsBattle == true)
        {
            if (IsSkill01 == false)
            {
                Skillcur += Time.deltaTime;
            }


            if (IsSkill01)
            {
                Skillcur -= Time.deltaTime;
                if (Skillcur < 0)
                {
                    IsSkill01 = false;
                    total.EpicUnitSkillDMG = 0;
                }
            }
        }
        else
        {
            Skillcur = 0;
        }

        if(IsStun == true)
        {
            Stuncur += Time.deltaTime;
            if(Stuncur > total.EpicUnitSkill03)
            {
                for (int i = 0; i < zone.Enemy.Count; i++)
                {
                    if(zone.Enemy[i].GetComponent<EnemyState>().IsAttack == true)
                    {
                        zone.Enemy[i].GetComponent<EnemyState>().state = EnemyState.State.ATTACK;
                    }
                    else
                    {
                        zone.Enemy[i].GetComponent<EnemyState>().state = EnemyState.State.MOVE;
                    }
                    
                }
                IsStun = false;
                Stuncur = 0;
            }
        }
        
    }
    public void Skill01()
    {
        if(enemyMaker.IsBattle == true)
        {
            if (Skillcur >= SkillCool)
            {
                if (Tutorial.Quest == 4)
                {
                    Tutorial.QuestClear = true;
                }
                Skillcur = SkillCool;
                IsSkill01 = true;
                total.EpicUnitSkillDMG = (int)(total.UnitTotalDamage * (total.EpicUnitSkill01 / 100));
                Debug.Log((float)(total.EpicUnitSkill01 / 100));
                
            }

        }
        
        
    }
    public void Skill02()
    {
        if (enemyMaker.IsBattle == true)
        {
            if (Skillcur >= SkillCool)
            {
                if (Tutorial.Quest == 4)
                {
                    Tutorial.QuestClear = true;
                }
                float a = total.CastleHpMax * (total.EpicUnitSkill02 / 100);
                Debug.Log(a);
                total.CastleHp +=(int)a;
                Skillcur = 0;
            }

        }


    }
    public void Skill03()
    {
        if (enemyMaker.IsBattle == true)
        {
            if (Skillcur >= SkillCool)
            {
                if (Tutorial.Quest == 4)
                {
                    Tutorial.QuestClear = true;
                }
                for (int i = 0; i < zone.Enemy.Count; i++)
                {
                    zone.Enemy[i].GetComponent<EnemyState>().state = EnemyState.State.IDLE;
                }
                IsStun = true;
                Skillcur = 0;
            }

        }


    }


}
