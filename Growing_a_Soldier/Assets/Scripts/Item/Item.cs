using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : MonoBehaviour
{
    public bool buy = false;
    public int MyNum;
    public Inventori inven;
    public tutorial Tutorial;
    // Start is called before the first frame update
    void Start()
    {
        Tutorial = GameObject.Find("Tutorial").GetComponent<tutorial>();
    }

    // Update is called once per frame
    void Update()
    {
       if(buy == true)
        {
            transform.GetChild(0).GetComponent<Image>().color = Color.white;
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().color = Color.black;
        }
    }
    public void Click()
    {
        
        if (buy == true)
        {
            if (Tutorial.Quest == 6)
            {
                Tutorial.QuestClear = true;
            }
            inven.itemNum = MyNum;
        }
    }
    
}
