using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventori : MonoBehaviour
{
    public Item[] item;
    public float SPD;
    public float HP;
    public int Coin;
    public int itemNum;
    public TotalState total;
    public EnemyState enemy;
    public bool damage;
    public bool Speed;
    // Start is called before the first frame update
    void Start()
    {
        total = GameObject.Find("TotalState").GetComponent<TotalState>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < item.Length; i++)
        {
            if (i != itemNum)
            {
                item[i].GetComponent<Image>().color = Color.white;
            }
        }
        switch (itemNum)
        {
            case 0:
                item[0].GetComponent<Image>().color = Color.red;
                break;
            case 1:
                item[1].GetComponent<Image>().color = Color.red;
                //ÆøÆÈ
                break;
            case 2:
                item[2].GetComponent<Image>().color = Color.red;
                //ÄÚÀÎ 100% Áõ°¡
                break;
            case 3:
                item[3].GetComponent<Image>().color = Color.red;
                break;
            case 4:
                item[4].GetComponent<Image>().color = Color.red;
                enemy.Speed = 0.5f;
                break;
            case 5:
                item[5].GetComponent<Image>().color = Color.red;
                if (damage == false)
                {
                    total.ItemDamage = (int)(total.UnitDamage * 0.2f);
                    damage = true;
                }    
                break;
            case 6:
                item[6].GetComponent<Image>().color = Color.red;
                SPD = total.UnitSPD / 2;
                break;
            case 7:
                item[7].GetComponent<Image>().color = Color.red;
                Coin = enemy.DropCoin * 2;
                break;

        }
        if(itemNum != 6)
        {
            SPD = 0;
        }
        if (itemNum != 4)
        {
            enemy.Speed = 1f;
        }
        if (itemNum != 5)
        {
            total.ItemDamage = 0;
        }
    }
}
