using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpScript : MonoBehaviour
{
    public int Exp;
    public GameObject Player;
    public Quaternion rotate;
    public float Speed;
    private void Start()
    {
        rotate = transform.rotation;
        Player = GameObject.Find("Player");
    }
    private void Update()
    {
        
        float dir = Vector3.Distance(transform.position, Player.transform.position);
        
        if(dir < Player.GetComponent<PlayerScript>().ExpPick)
        {
            transform.LookAt(Player.transform);
            transform.Translate(0, 0, Speed * Time.deltaTime);

        }
        else
        {
            transform.rotation = rotate;
        }
    }
}
