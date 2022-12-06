using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public enum State
    {
        IDLE = 0,
        MOVE,
        ATTACK,
        STANDOFF,
    }
    public State state;
    //일반 좀비들
    public float Hp;//기본10
    public int Damage;//기본50
    public int DropCoin;//기본2
    public int DropExp;//기본10

    public float Speed = 1f;
    public float Attackcur;
    public float AttackCool =1f;

    public float ThrowingCur;
    public float ThrowingCool;

    //보스 
    public float BossHp;//기본100
    public float BossMaxHp;//기본100
    public int BossDamage;//기본200
    public int BossDropCoin;//기본50
    public int BossDropExp;//기본100

    public float BossSpeed;//기본0.5

    public bool IsAttack;

    public AttackZone attackZone;
    public EnemyMaker enemyMaker;
    public TotalState total;
    public Animator animZ;
    public AudioSource DieAudio;
    public Inventori inventori;
    public GameObject Stone;
    public Transform StonePos;
    public QusetScript quset;
    // Start is called before the first frame update
    void Start()
    {
        quset = GameObject.Find("QusetMgr").GetComponent<QusetScript>();
        inventori = GameObject.Find("ItemMgr").GetComponent<Inventori>();
        animZ = GetComponentInChildren<Animator>();
        DieAudio = GetComponent<AudioSource>();
        enemyMaker = GameObject.Find("EnemyMake").GetComponent<EnemyMaker>();
        attackZone = GameObject.Find("AttackZone").GetComponent<AttackZone>();
        total = GameObject.Find("TotalState").GetComponent<TotalState>();
        state = State.MOVE;
        BossMaxHp = BossHp;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyMaker.IsBattle)
        {
            switch (state)
            {
                case State.IDLE:
                    break;
                case State.MOVE:
                    if (gameObject.CompareTag("Enemy"))
                    {
                        transform.Translate(0, 0, -Speed * Time.deltaTime * 10);
                    }
                    if (gameObject.name == "Boss")
                    {
                        transform.Translate(0, 0, -BossSpeed * Time.deltaTime * 10);
                    }
                    break;
                case State.ATTACK:
                    Attackcur += Time.deltaTime;
                    animZ.SetBool("Attack",true);
                    if (Attackcur > AttackCool)
                    {
                        
                        if(gameObject.CompareTag("Enemy"))
                        {
                            
                            total.CastleHp -= Damage;
                            Attackcur = 0;
                        }
                        if(gameObject.name == "Boss")
                        {
                            
                            total.CastleHp -= BossDamage;
                            Attackcur = 0;
                        }
                        
                    }
                    break;
                case State.STANDOFF:
                    ThrowingCur += Time.deltaTime;
                    if (ThrowingCur > ThrowingCool)
                    {
                        animZ.SetBool("Attack", true);
                        Instantiate(Stone, StonePos.position, StonePos.rotation);
                        ThrowingCur = 0;
                    }
                   
                    break;

            }
        }
        
       
        
        if(BossHp <=0)
        {
            if (gameObject.name == "Boss")
            {
                attackZone.Enemy.RemoveAt(0);
                enemyMaker.KillCount++;
                total.MyCoin += BossDropCoin;
                total.PlayerExp += BossDropExp;
                total.ExpCheck += DropExp;
                total.CoinCheck += DropCoin;
                quset.kill++;
                gameObject.SetActive(false);

            }
        }
        if(BossHp >BossMaxHp)
        {
            BossHp = BossMaxHp;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            state = State.ATTACK;
            IsAttack = true;
        }
        if(other.CompareTag("shield"))
        {
            state = State.IDLE;
            Debug.Log("wwwwww");
            StartCoroutine(Wait());
        }

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        state = State.MOVE;
    }
    
    public void Die()
    {
        animZ.SetBool("Die", true);
        DieAudio.Play();
        attackZone.Enemy.Remove(gameObject);
        GetComponentInChildren<UHDHpBar>().DestroyHpBar();
        enemyMaker.KillCount++;
        quset.kill++;
        total.MyCoin += DropCoin + inventori.Coin;
        total.PlayerExp += DropExp;
        total.ExpCheck += DropExp;
        total.CoinCheck += DropCoin;
        state = State.IDLE;
        StartCoroutine(die());
    }
    IEnumerator die()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
    
}
