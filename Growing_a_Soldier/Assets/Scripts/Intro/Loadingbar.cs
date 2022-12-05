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
                text.text = "Tip) �������� �缭 ������ ������!";
                break;
            case 1:
                text.text = "Tip) ���帶�� ���� �� ������ �߰��˴ϴ�!";
                break;
            case 2:
                text.text = "Tip) ��Ƽ�� �����ۺ��� �нú� �������� ����Դϴ�!";
                break;
            case 3:
                text.text = "Tip) 5���帶�� ������ ���Ϳ�!";
                break;
            
        }
    }

}
