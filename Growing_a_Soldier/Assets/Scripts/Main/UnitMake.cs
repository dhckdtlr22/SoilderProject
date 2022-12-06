using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMake : MonoBehaviour
{
    public Transform[] Pos;
    public Transform[] EpicPos;
   

    public GameObject UnitPrefab;
    public GameObject EpicUnitPrefab;
    

    public TotalState total;

    public int UnitNumMax = 15;
    public tutorial Tutorial;
    // Start is called before the first frame update
    void Start()
    {
        Tutorial = GameObject.Find("Tutorial").GetComponent<tutorial>();
        for (int i = 0; i < 15; i++)
        {
            Pos[i] = GameObject.Find($"UnitPos{i+1}").GetComponent<Transform>();

        }
        for (int i = 0; i < 3; i++)
        {
            EpicPos[i] = GameObject.Find($"EpicUnitPos{i + 1}").GetComponent<Transform>();

        }

        if(total.UnitNum == 0)
        {
            total.UnitNum = 1;
        }
        for (int i = 0; i < total.UnitNum; i++)
        {
            GameObject Unit = Instantiate(UnitPrefab, Pos[i].position, transform.rotation);
            Unit.name = $"Unit{i}";
            
        }
        for (int i = 0; i < total.EpicUnitNum; i++)
        {
            GameObject EpicUnit = Instantiate(EpicUnitPrefab, EpicPos[i].position, transform.rotation);
            EpicUnit.name = $"EpicUnit{i}";
            
        }
        if(total.UnitNum == 0)
        {
            total.UnitNum = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void UnitInstantiate()
    {
        if(total.UnitNum < UnitNumMax && total.MyCoin >= total.UnitInsCost )
        {
            total.MyCoin -= total.UnitInsCost;
            GameObject Unit = Instantiate(UnitPrefab, Pos[total.UnitNum].position, transform.rotation);
            Unit.name = $"Unit{total.UnitNum}";
            total.UnitNum++;
        }
        
    }
    public void EpicUnitInstantiate()
    {
        
        if (total.EpicUnitNum < total.EpicMax && total.MyCoin >= total.EpicUnitInsCost)
        {
            if (Tutorial.Quest == 3)
            {
                Tutorial.QuestClear = true;
            }
            total.MyCoin -= total.EpicUnitInsCost;
            GameObject EpicUnit = Instantiate(EpicUnitPrefab, EpicPos[total.EpicUnitNum].position, transform.rotation);
            EpicUnit.name = $"EpicUnit{total.EpicUnitNum}";
            total.EpicUnitNum++;
        }

    }

}
