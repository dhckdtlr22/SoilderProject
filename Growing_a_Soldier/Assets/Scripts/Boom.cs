using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public QusetScript quset;
    // Start is called before the first frame update
    void Start()
    {
        quset = GameObject.Find("QusetMgr").GetComponent<QusetScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyState>().Die();
            quset.SkillDie++;
        }
    }
}
