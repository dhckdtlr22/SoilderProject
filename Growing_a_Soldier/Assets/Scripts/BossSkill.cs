using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill : MonoBehaviour
{
    public int rand;
    public float Curtime;
    public float Cooltime;
    public GameObject healEFT;
    public GameObject BoomEFT;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        switch (rand)
        {
            case 0:
                if(GetComponent<EnemyState>().state == EnemyState.State.ATTACK)
                {
                    Curtime += Time.deltaTime;
                    if(Curtime > Cooltime)
                    {
                        GameObject Boom = Instantiate(BoomEFT, transform.position, transform.rotation);
                        Destroy(Boom, 1f);
                        GameObject.Find("TotalState").GetComponent<TotalState>().CastleHp -= GetComponent<EnemyState>().BossDamage * 10;
                        Destroy(gameObject);
                        //에너미 사라짐
                        //일정대미지 or 패배
                    }
                }
                //자폭
                break;
            case 1:
                Curtime += Time.deltaTime;
                if(Curtime > Cooltime)
                {
                    GetComponent<EnemyState>().BossHp += GetComponent<EnemyState>().BossHp * 0.1f;
                    GameObject Heal = Instantiate(healEFT, transform.position, transform.rotation);
                    Destroy(Heal, 1f);
                    Curtime = 0;
                }
                //주기적 피회복
                break;
            case 3:
                break;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.name == "StandOffAttack" && rand == 2)
        {
            Debug.Log("1111111");
            GetComponent<EnemyState>().state = EnemyState.State.STANDOFF;
        }
    }

}
