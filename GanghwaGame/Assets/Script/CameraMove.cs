using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dirY = Player.transform.position.y + 20;
        transform.position = new Vector3(Player.transform.position.x,dirY,Player.transform.position.z);
    }
}
