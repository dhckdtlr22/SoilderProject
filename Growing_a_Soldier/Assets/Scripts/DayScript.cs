using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DayScript : MonoBehaviour
{
    public TotalState Total;
    public int a;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        Total = GameObject.Find("TotalState").GetComponent<TotalState>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"{a + 1}¿œ";
        if(Total.nextDay == true && a == Total.DayNum && Total.nextDay == true || a == 0 && Total.DayNum == 0)
        {
            GetComponent<Image>().color = Color.green;
        }
        else
        {
            GetComponent<Image>().color = Color.white;
        }
  
    }
    public void reward()
    {
        if(Total.nextDay == true && a == Total.DayNum || Total.DayNum == 0)
        {
            Total.LastDay = Total.CurDay;
            Total.MyCoin += Total.Day;
            Total.DayNum++;
            Total.nextDay = false;  
        }
        
    }

}
