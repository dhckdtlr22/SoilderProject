using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Loadingbar : MonoBehaviour
{
    public Slider Loading;
    public float Curtime;
    
    public Text text;
    int a; 
    // Start is called before the first frame update
    void Start()
    {
        a = Random.Range(4, 8);
        InvokeRepeating("TextChage", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Loading.value = Curtime / a;
        Curtime += Time.deltaTime;
        if(Curtime >a)
        {
            SceneManager.LoadScene("02_Main");
        }

        
    }
   
    public void TextChage()
    {
        int rand = Random.Range(0, 4);

        switch (rand)
        {
            case 0:
                text.text = "Tip) 아이템을 사서 장착해 보세요!";
                break;
            case 1:
                text.text = "Tip) 라운드마다 적이 한 마리씩 추가됩니다!";
                break;
            case 2:
                text.text = "Tip) 액티브 아이템보다 패시브 아이템이 더비쌉니다!";
                break;
            case 3:
                text.text = "Tip) 5라운드마다 보스가 나와요!";
                break;
            
        }
    }

}
