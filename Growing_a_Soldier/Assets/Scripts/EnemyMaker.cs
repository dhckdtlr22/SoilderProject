using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyMaker : MonoBehaviour
{
    public GameObject BattalPop;
    public GameObject EnemyPrefab;
    public GameObject BossPrefab;
    
    public GameObject[] Enemy;

    public Text EnemyCountText;
    public Text KillText;
    public Text Result;
    public Text ExpText;
    public Text CoinText;
    public Slider KillSlider;

    public float curtime;
    public float cooltime;

    public bool IsBattle;
    public bool IsClear;
    public bool Resetting;

    public int MonsterCount;
    public int CountMax;
    public int KillCount;
    public int a;

    public TotalState totalState;
    public AttackZone attackZone;
    public EnemyState enemyState;
    
    public GameObject AtiveBut;
    public BattleStart battle;
    
    // Start is called before the first frame update
    private void Start()
    {
        
        totalState = GameObject.Find("TotalState").GetComponent<TotalState>();
        attackZone = GameObject.Find("AttackZone").GetComponent<AttackZone>();
        for (int i = 0; i < 100; i++)
        {
            GameObject zombie = Instantiate(EnemyPrefab);
            zombie.name = $"Enemy{i}";
            zombie.transform.position = transform.position;
            zombie.transform.parent = gameObject.transform;
        }
        GameObject Boss = Instantiate(BossPrefab);
        Boss.name = "Boss";
        Boss.transform.parent = gameObject.transform;
        Boss.transform.position = transform.position;
        for (int i = 0; i < 100; i++)
        {
            a = i;
            Enemy[i] = GameObject.Find($"Enemy{i}");
        }
        Enemy[100] = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        if (CountMax < 2000)
        {
            CountMax = 10 + totalState.Stage;
        }
        if (IsBattle == true && battle.Istrue == false)
        {   
            AtiveBut.SetActive(true);
            IsClear = false;
            curtime += Time.deltaTime;
            if (cooltime > 0.1)
            {
                cooltime = 1 - (totalState.Stage / 5 * 0.05f);
                if (cooltime < 0.1f)
                {
                    cooltime = 0.1f;
                }
            }
            if (totalState.Stage%5 == 0)
            {
                
                if (curtime > cooltime && MonsterCount < CountMax && attackZone.Enemy.Count < 100)
                {
                    if(MonsterCount == CountMax -1)
                    {
                        //º¸½º ¼ÒÈ¯
                        GameObject Boss = Enemy[100];
                        Boss.transform.position = new Vector3(transform.position.x,3.4f, transform.position.z);
                        Boss.GetComponent<EnemyState>().BossHp = (int)(100 * (totalState.Stage / 5 * 1.5f));
                        Boss.GetComponent<EnemyState>().BossMaxHp = Boss.GetComponent<EnemyState>().BossHp;
                        Boss.GetComponent<EnemyState>().BossDamage = (int)(200 * (totalState.Stage / 5 * 1.2f));
                        Boss.GetComponent<EnemyState>().BossDropCoin = (int)(50 * (totalState.Stage / 5 * 1.5f));
                        Boss.GetComponent<EnemyState>().BossDropExp = (int)(100 * (totalState.Stage / 5 * 1.5f));
                        Boss.SetActive(true);
                        Boss.GetComponentInChildren<UHDHpBar>().Round();
                        Boss.GetComponent<EnemyState>().state = EnemyState.State.MOVE;
                        curtime = 0;
                        MonsterCount++;
                    }
                    else
                    {
                        //Àû ´É·ÂÄ¡ ¼³Á¤
                        
                        GameObject enemy = Enemy[MonsterCount % 100];
                        if(enemy.activeSelf == true)
                        {
                            return;
                        }
                        
                        float a = 10 * (totalState.Stage / 5 * 1.2f);
                        enemy.GetComponent<EnemyState>().Damage = (int)a;
                        float b = 50 * (totalState.Stage / 5 * 1.5f);
                        enemy.GetComponent<EnemyState>().Hp = (int)b;
                        float c = 2 * (totalState.Stage / 5 * 1.5f);
                        enemy.GetComponent<EnemyState>().DropCoin = (int)c;
                        float d = 10 * (totalState.Stage / 5 * 1.1f);
                        enemy.GetComponent<EnemyState>().DropExp = (int)d;
                      
                        if (enemy.GetComponent<EnemyState>().Speed < 3)
                        {
                            enemy.GetComponent<EnemyState>().Speed = 1 + (totalState.Stage / 5 * 0.05f);
                            if (enemy.GetComponent<EnemyState>().Speed > 3)
                            {
                                enemy.GetComponent<EnemyState>().Speed = 3;
                            }
                        }
                        int rand = Random.Range(-15, 14);
                        enemy.SetActive(true);
                        enemy.GetComponentInChildren<UHDHpBar>().Round();
                        enemy.GetComponent<EnemyState>().state = EnemyState.State.MOVE;
                        enemy.transform.position = new Vector3(transform.position.x + rand, transform.position.y, transform.position.z);
                        curtime = 0;
                        MonsterCount++;
                    }
                }
            }
            else
            {
                if (curtime > cooltime && MonsterCount < CountMax)
                {
                    Debug.Log("11111");
                    GameObject enemy = Enemy[MonsterCount % 100];
                    if (enemy.activeSelf == true)
                    {
                        return;
                    }

                    float a =10 + 50 * (int)(totalState.Stage / 5 * 1.5f);
                    enemy.GetComponent<EnemyState>().Hp = (int)a;
                        float b = 50+10 * (int)(totalState.Stage / 5 * 1.2f);
                    enemy.GetComponent<EnemyState>().Damage = (int)b;
                        float c =2+ 2 * (int)(totalState.Stage / 5 * 1.5f);
                    enemy.GetComponent<EnemyState>().DropCoin = (int)c;
                        float d =10+ 10 * (int)(totalState.Stage / 5 * 1.1f);
                    enemy.GetComponent<EnemyState>().DropExp = (int)d;
                        
                        if (enemy.GetComponent<EnemyState>().Speed < 3)
                        {
                        enemy.GetComponent<EnemyState>().Speed = 1 + (int)(totalState.Stage / 5 * 0.05f);
                            if (enemy.GetComponent<EnemyState>().Speed > 3)
                            {
                            enemy.GetComponent<EnemyState>().Speed = 3;
                            }
                        }
                    int rand = Random.Range(-15, 14);
                    enemy.SetActive(true);
                    enemy.GetComponentInChildren<UHDHpBar>().Round();
                    enemy.GetComponent<EnemyState>().state = EnemyState.State.MOVE;
                    enemy.transform.position = new Vector3(transform.position.x + rand, transform.position.y, transform.position.z);
                    curtime = 0;
                    MonsterCount++;
                }
            }
            
            EnemyCountText.text = $"{KillCount}/{CountMax}";
            KillSlider.value = (float)KillCount / CountMax;
        }
        else if(IsBattle == false)
        {
            curtime = 0;
            AtiveBut.SetActive(false);
            AtiveBut.GetComponent<ItemAtive>().Curtime = 0;
            EnemyCountText.text = $"Stage {totalState.Stage}";
            KillSlider.value = 0;
            if(IsClear == false)
            {
                for (int i = 0; i < Enemy.Length-1; i++)
                {
                   if(Enemy[i].activeSelf == true)
                    {
                        Enemy[i].SetActive(false);

                        Enemy[i].GetComponentInChildren<UHDHpBar>().hpBar.gameObject.SetActive(false);
                    }
                   
                }
                if(Enemy[100].activeSelf == true)
                {
                    Enemy[100].SetActive(false);
                    Enemy[100].GetComponentInChildren<UHDHpBar>().hpBar.gameObject.SetActive(false);
                }
               

                IsClear = true;

            }
            
            
            
            if (attackZone.EnemyIn == true)
            {
                attackZone.Enemy.RemoveAt(0);
            }
            
        }
        
        if (KillCount == CountMax)
        {
            totalState.CastleHp = int.Parse(totalState.data[totalState.CastleUpgradeLv]["CastleHp"].ToString());
            IsBattle = false;
            totalState.StageUp();
            curtime = 0;
            KillText.text = $"Ã³Ä¡ :{KillCount}¸¶¸®";
            
            CoinText.text = $"È¹µæ ÄÚÀÎ:{string.Format("{0:#,###}", totalState.CoinCheck)}";
            ExpText.text = $"È¹µæ °æÇèÄ¡:{string.Format("{0:#,###}", totalState.ExpCheck)}";
            totalState.ExpCheck = 0;
            totalState.CoinCheck = 0;
            KillCount = 0;
            MonsterCount = 0;
            BattalPop.SetActive(true);
            Result.text = "½Â¸®";
        }
        
        if(totalState.CastleHp <= 0)
        {
            totalState.CastleHp = totalState.CastleHpMax;
            KillText.text = $"Ã³Ä¡ :{KillCount}¸¶¸®";
            IsBattle = false;
            BattalPop.SetActive(true);
            CoinText.text = $"È¹µæ ÄÚÀÎ:{totalState.CoinCheck}";
            ExpText.text = $"È¹µæ °æÇèÄ¡:{totalState.ExpCheck}";
            totalState.ExpCheck = 0;
            totalState.CoinCheck = 0;
            curtime = 0;
            KillCount = 0;
            MonsterCount = 0;
            Result.text = "ÆÐ¹è";
        }
        if(Resetting == true)
        {
            Restarted();
        }
    }
    public void Restarted()
    {
        
        if (IsClear == true)
        {
            IsBattle = true;
            Resetting = false;
            MonsterCount = 0;
            Time.timeScale = 1;
        }
        else
        {
            Resetting = true; 
            IsClear = false;
            IsBattle = false;

        }


    }

    public void EnemyReset()
    {

    }

}
