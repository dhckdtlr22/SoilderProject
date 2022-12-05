using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        transform.Translate(0, 0, -Speed * Time.deltaTime);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (transform.position.z <= -50)
        {
            transform.position = new Vector3(0, 0, 100);
        }
    }
}
