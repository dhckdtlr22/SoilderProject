using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerSTATE
    {
        IDLE = 0,
        DOWN,
        UP,
        TURN,
        GROUND,
        JUMPUP,
        JUMPDOWN
    }
    public PlayerSTATE State;
    public GameObject Gargori;
   
    public float Speed;
    public float buffSpeed;
    public float DownbuffSpeed;
    public float RotateSpeed;
    public float JumpSpeed;

    public Vector3 dir;
    public bool IsClick;
    public bool IsGround;
    public Vector3 jumpDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && IsGround == false)
        {
            Gargori.transform.position = transform.position;
            transform.rotation = Quaternion.Euler(0,0,0);
            IsClick = false;
            if(State != PlayerSTATE.JUMPUP && State != PlayerSTATE.JUMPDOWN)
            {
                State = PlayerSTATE.GROUND;
            }
            
        }
        if (Input.GetKey(KeyCode.Mouse0) && IsGround == false)
        {

            Gargori.transform.Translate(0, 0, Gargori.GetComponent<GargoriScripts>().Speed * Time.deltaTime);
            IsClick = true;
        }
        switch (State)
        {
            case PlayerSTATE.IDLE:
                
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jumpDir = transform.position;
                    State = PlayerSTATE.JUMPUP;
                }
                break;
            case PlayerSTATE.DOWN:
                transform.Translate(0, -Speed * Time.deltaTime, 0);
                if (transform.position.y <= dir.y - 3f)
                {
                    dir = transform.position;
                    State = PlayerSTATE.UP;
                }
                break;
            case PlayerSTATE.UP:
                transform.Translate(0, (Speed + buffSpeed) * Time.deltaTime, 0);
                if (transform.position.y >= dir.y + 5)
                {
                    State = PlayerSTATE.TURN;
                }
                break;
            case PlayerSTATE.TURN:
                transform.Rotate(RotateSpeed * Time.deltaTime, 0, 0);
                if (transform.rotation.x < 0 && transform.rotation.x > -3)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    State = PlayerSTATE.GROUND;
                }
                break;
            case PlayerSTATE.GROUND:
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {

                        Gargori.transform.Translate(0, 0, Gargori.GetComponent<GargoriScripts>().Speed * Time.deltaTime);
                        IsClick = true;
                    }
                    transform.Translate(0, (-Speed -DownbuffSpeed) * Time.deltaTime, 0);
                }
                break;
            case PlayerSTATE.JUMPUP:
                IsGround = false;
                transform.Translate(0, JumpSpeed * Time.deltaTime, 0);
                if (transform.position.y >= jumpDir.y + 5)
                {
                    State = PlayerSTATE.JUMPDOWN;
                }
                break;
            case PlayerSTATE.JUMPDOWN:
                transform.Translate(0, -JumpSpeed * Time.deltaTime, 0);
                break;

        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            IsGround = true;
            IsClick = false;
            Gargori.transform.position = transform.position;
            transform.position = new Vector3(0, other.transform.position.y + 0.5f, 0);
            State = PlayerSTATE.IDLE;
        }
    }
}
