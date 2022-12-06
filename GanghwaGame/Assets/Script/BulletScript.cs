using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    public int Damage;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyState>().Damage(Damage);
            Destroy(gameObject);
        }
    }
}
