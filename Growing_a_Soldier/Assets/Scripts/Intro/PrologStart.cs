using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologStart : MonoBehaviour
{
    public GameObject img;
    public CameraTr Tr;
    public GameObject Bg;
    public GameObject Text;
    public GameObject Loading;
    public bool IsProlog;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        if(PlayerPrefs.GetString("IsProlog") == "")
        {

        }
        else
        {
            IsProlog = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetString ("IsProlog", IsProlog.ToString());
    }
    public void Prolog()
    {
        Text.SetActive(false);
        if (IsProlog == false)
        {
            Bg.SetActive(true);
            Tr.IsTake = 0;
            IsProlog = true;
        }
        else
        {
            Loading.SetActive(true);
        }
    }
}
