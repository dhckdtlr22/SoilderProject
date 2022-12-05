using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpicUnitState : MonoBehaviour
{
    public AttackZone attackZone;
    public EnemyState enemyState;
    public EnemyMaker enemyMaker;
    public TotalState totalState;

    public Animator anime;

    public float Attackcur;
    public float Attackcool;
    public GameObject MezzlePrefab;
    public Transform MPos;

    public GameObject Effect;
    public AudioSource shootAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        MezzlePrefab = transform.GetChild(1).gameObject;
        anime = GetComponentInChildren<Animator>();
        enemyMaker = GameObject.Find("EnemyMake").GetComponent<EnemyMaker>();
        attackZone = GameObject.Find("AttackZone").GetComponent<AttackZone>();
        totalState = GameObject.Find("TotalState").GetComponent<TotalState>();
        totalState.ShootAudio.Add(GetComponent<AudioSource>());
    }

    // Update is called once per frame
    void Update()
    {
        Attackcool = totalState.EpicUnitSPD;
        if(enemyMaker.IsBattle == true)
        {
            if (attackZone.EnemyIn == true && attackZone.Enemy.Count >= 1)
            {
                Debug.Log(attackZone.Enemy);
                transform.LookAt(attackZone.Enemy[0].transform);
                Vector3 dir = transform.localRotation.eulerAngles;
                dir.x = 0;
                transform.localRotation = Quaternion.Euler(dir);
                enemyState = attackZone.Enemy[0].GetComponent<EnemyState>();
                Attackcur += Time.deltaTime;
                anime.SetTrigger("Attack");
                if (Attackcur > Attackcool)
                {
                    shootAudio.Play();
                    MezzlePrefab.SetActive(true);
                    StartCoroutine(Wait());
                    Instantiate(Effect, enemyState.gameObject.transform.position, Quaternion.LookRotation(-enemyState.transform.position.normalized));
                    if (enemyState.CompareTag("Enemy"))
                    {
                        enemyState.Hp -= totalState.EpicUnitDamage;
                        Attackcur = 0;
                        if (enemyState.Hp <= 0)
                        {
                            enemyState.Die();
                        }
                    }
                    else if (enemyState.gameObject.name == "Boss")
                    {
                        
                        enemyState.BossHp -= totalState.EpicUnitDamage;
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
