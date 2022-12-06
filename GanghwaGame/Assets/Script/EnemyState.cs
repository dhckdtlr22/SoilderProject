using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public enum STATE
    {
        IDLE = 0,
        MOVE,
        ATTACK,
        DIE
    }
    public STATE State;
    public GameObject Player;
    public GameObject Exp;
    public EnemyMakerScirpt enemyMaker;

    public int Hp;
    public int ATK;
    public float ASPDcool;
    public float ASPDcur;
    public float Speed;
    public float AttackRange;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyMaker = GameObject.Find("EnemyMaker").GetComponent<EnemyMakerScirpt>();
        Player = GameObject.Find("Player");
        State = STATE.MOVE;
    }

    // Update is called once per frame
    void Update()
    {
        float dir = Vector3.Distance(gameObject.transform.position, Player.transform.position);
        switch (State)
        {
            case STATE.IDLE:
                break;
            case STATE.MOVE:
                transform.Translate(0, 0, Speed * Time.deltaTime);
                transform.LookAt(Player.transform);
                if(dir <= AttackRange)
                {
                    State = STATE.ATTACK;
                }
                break;
            case STATE.ATTACK:
                ASPDcur += Time.deltaTime;
                if(ASPDcur >= ASPDcool)
                {
                    ASPDcur = 0;
                }
                if (dir > AttackRange)
                {
                    State = STATE.MOVE;
                }
                break;
            case STATE.DIE:
                GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(Die());
                break;
            default:
                break;
        }
        if(Hp <=0)
        {
            State = STATE.DIE;
        }
    }
    public IEnumerator Die()
    {
        yield return new WaitForSeconds(0.5f);
        enemyMaker.EnemyNum--;
        Player.GetComponent<PlayerScript>().Kill++;
        Instantiate(Exp, transform.position, Exp.transform.rotation);
        Destroy(gameObject);
    }
    
    public void Damage(int damage)
    {
        Hp -= damage;
        
    }
}
