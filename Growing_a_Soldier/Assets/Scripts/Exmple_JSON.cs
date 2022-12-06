using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
public class Exmple_JSON : MonoBehaviour
{
    public int hp;
    public int mp;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        State();
        Data();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void State()
    {
        var state = new JSONObject();

        state["hp"] = hp;
        state["mp"] = mp;
        state["Speed"] = Speed;

        PlayerPrefs.SetString("PlayerState", state.ToString());
    }
    public void Data()
    {
        string JSONdata = PlayerPrefs.GetString("PlayerState");

        var comeData = JSON.Parse(JSONdata);

        Debug.Log(comeData["hp"]);
        Debug.Log(comeData["mp"]);
        Debug.Log(comeData["Speed"]);

    }
}
