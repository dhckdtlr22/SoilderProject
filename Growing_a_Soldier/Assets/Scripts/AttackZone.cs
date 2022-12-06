using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public List<GameObject> Enemy;
    public bool EnemyIn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy.Count == 0)
        {
            EnemyIn = false;
        }    
        else
        { EnemyIn = true; }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            Enemy.Add(other.gameObject);
            
        }
    }
}
