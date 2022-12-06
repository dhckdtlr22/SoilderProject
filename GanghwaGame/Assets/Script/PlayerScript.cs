using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    
    public GameObject FirePos;
    public GameObject Bullet;
    
    public Text bulletText;
    public Image Reloading;

    public bool Roding;
    public bool Auto;

    public float Speed;
    public float Curtime;
    public float Cooltime;
    public float AutoCur;
    public float AutoCool;
    public float ExpPick;

    public int BulletNum;
    public int BulletMaxNum;
    public int Kill;
    public int Exp;
    public int MaxExp;
    public int Lv;
    // Start is called before the first frame update
    void Start()
    {
        bulletText = GameObject.Find("BulletText").GetComponent<Text>();
        BulletNum = BulletMaxNum;
    }

    // Update is called once per frame
    void Update()
    {
        if(Exp >= MaxExp)
        {
            Lv++;
            Exp = 0;
        }
        AutoCur += Time.deltaTime;
        Debug.Log("111");
        bulletText.text = $"{BulletNum}/{BulletMaxNum}";
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        transform.Translate(dir.normalized * Speed * Time.deltaTime);

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && BulletNum > 0 && Roding == false && Auto == false)
            {
                GameObject bullet = Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
                bullet.name = "bullet";
                BulletNum--;
            }
            if(Input.GetKey(KeyCode.Mouse0) && BulletNum > 0 && Roding == false && Auto == true && AutoCur >= AutoCool)
            {
                GameObject bullet = Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
                bullet.name = "bullet";
                BulletNum--;
                AutoCur = 0;
            }
        }
        if(Input.GetKeyDown(KeyCode.R) && BulletNum != BulletMaxNum)
        {
            Roding = true;
        }
        if(Roding == true)
        {
            Curtime += Time.deltaTime;
            if (Curtime >= Cooltime)
            {
                BulletNum = BulletMaxNum;
                Curtime = 0;
                Roding = false;
            }
            Reloading.fillAmount = Curtime / Cooltime;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Exp"))
        {
          Exp += other.GetComponent<ExpScript>().Exp;
            Destroy(other.gameObject);
        }
    }
}
