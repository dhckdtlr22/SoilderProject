using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_Maker : MonoBehaviour
{
    public GameObject ZombiePrefab;
    public GameObject[] Enemy;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject zombie = Instantiate(ZombiePrefab);
            zombie.name = "Enemy";
            zombie.transform.parent = gameObject.transform;
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            Debug.Log(i);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
