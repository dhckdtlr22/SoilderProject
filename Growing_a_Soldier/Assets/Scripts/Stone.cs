using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public float Speed;

    public GameObject Effect;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, 0, -Speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            if(GameObject.Find("Boss") == true)
            {
                GameObject.Find("TotalState").GetComponent<TotalState>().CastleHp -= GameObject.Find("Boss").GetComponent<EnemyState>().BossDamage;
                GameObject effect = Instantiate(Effect, transform.position, transform.rotation);
                Destroy(effect, 0.5f);
            }
            
           
            Destroy(gameObject);

        }
    }
}
