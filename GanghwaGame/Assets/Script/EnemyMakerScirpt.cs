using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMakerScirpt : MonoBehaviour
{
    public float Curtime;
    public float Cooltime;
    public GameObject Player;
    public GameObject EnemyPrefab;
    public int randX, randZ;
    public int EnemyMaxNum;
    public int EnemyNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Curtime += Time.deltaTime;
        if(Curtime >= Cooltime && EnemyNum < EnemyMaxNum)
        {
            randX = Random.Range(-25, 25);
            int a = Random.Range(0, 4);
            switch (a)
            {
                case 0:
                    randX = -25;
                    randZ = Random.Range(-20,20);
                    break;
                case 1:
                    randX = 20;
                    randZ = Random.Range(-20,20);
                    break;
                case 2:
                    randX = Random.Range(-25, 25);
                    randZ = -20;
                    break;
                case 3:
                    randX = Random.Range(-25, 25);
                    randZ = 20;
                    break;

            }
            Vector3 dir = new Vector3(randX, 0.5f, randZ);
            GameObject enemy = Instantiate(EnemyPrefab,dir,transform.rotation);
            EnemyNum++;
            Curtime = 0;

        }
    }
}
