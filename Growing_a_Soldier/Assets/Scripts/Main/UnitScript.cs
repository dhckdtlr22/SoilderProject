using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnitScript : MonoBehaviour
{
    public AttackZone attackZone;
    public EnemyState enemyState;
    public EnemyMaker enemyMaker;
    public TotalState totalState;

    public Animator anime;

    public float Attackcur;
    public float Attackcool;
    public Inventori invent;

    public int rand;

    public GameObject MezzlePrefab;
    public Transform MPos;

    public GameObject Effect;
    public AudioSource shootAudio;
   

    // Start is called before the first frame update
    void Start()
    {
        invent = GameObject.Find("ItemMgr").GetComponent<Inventori>();
        anime = GetComponentInChildren<Animator>();
        shootAudio = GetComponent<AudioSource>();

        MezzlePrefab = transform.GetChild(1).gameObject;
        enemyMaker = GameObject.Find("EnemyMake").GetComponent<EnemyMaker>();
        attackZone = GameObject.Find("AttackZone").GetComponent<AttackZone>(); 
        totalState = GameObject.Find("TotalState").GetComponent<TotalState>();
        totalState.ShootAudio.Add(GetComponent<AudioSource>());
    }

    // Update is called once per frame
    void Update()
    {
        Attackcool = totalState.UnitSPD - invent.SPD;
      if(enemyMaker.IsBattle == true)
        {
            if (attackZone.EnemyIn == true && attackZone.Enemy.Count >= 1)
            {
                
                if(attackZone.Enemy.Count >5)
                {
                    rand = Random.Range(0, 3);
                    transform.LookAt(attackZone.Enemy[rand].transform);
                }
                else
                {
                    rand = 0;
                    transform.LookAt(attackZone.Enemy[rand].transform);
                }

                
                anime.SetTrigger("Attack");
                enemyState = attackZone.Enemy[rand].GetComponent<EnemyState>();
                Attackcur += Time.deltaTime;
                if (Attackcur > Attackcool)
                {
                    MezzlePrefab.SetActive(true);
                    StartCoroutine(Wait());
                    shootAudio.Play();
                    Instantiate(Effect, enemyState.gameObject.transform.position, Quaternion.LookRotation(-enemyState.transform.position.normalized));
                    if(enemyState.gameObject.CompareTag("Enemy"))
                    {
                        
                        enemyState.Hp -= totalState.UnitTotalDamage;

                        Attackcur = 0;
                        if (enemyState.Hp <= 0)
                        {
                            enemyState.Die();
                        }
                    }
                    else if (enemyState.gameObject.name == "Boss")
                    {
                        
                        enemyState.BossHp -= totalState.UnitTotalDamage;
                        Attackcur = 0;
                    }
                    
                }
            }
            
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        MezzlePrefab.SetActive(false);
    }
}
