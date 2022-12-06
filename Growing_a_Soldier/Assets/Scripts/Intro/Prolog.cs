using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prolog : MonoBehaviour
{
    public enum STATE
    {
        IDLE =0,
        ATTACK
    }
    public STATE state;
    public float Speed;
    public GameObject[] Character;
    public Animator Anim;
    public bool IsTake;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(IsTake)
        {
            switch (state)
            {
                case STATE.IDLE:
                    transform.Translate(0, 0, Speed * Time.deltaTime);

                    break;
                case STATE.ATTACK:
                    Anim.SetBool("IsAttack", true);
                    break;
                default:
                    break;
            }

        }
        
    }
    public void Attack()
    {
        Destroy(Character[0]);
        Character[1].SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name =="Change")
        {
            state = STATE.ATTACK;
        }
    }
}
