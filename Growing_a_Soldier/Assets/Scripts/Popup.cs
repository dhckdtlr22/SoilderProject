using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Popup : MonoBehaviour
{
    public RectTransform UpPop;
    public RectTransform BPop;
    public RectTransform SPop;
    public RectTransform InPop;
    float a;
    float b;
    float c;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        a = Screen.width;
        b = Screen.height;
        c = a / b;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Battle()
    {
        if (c <= 1.8)
        {
            UpPop.DOLocalMove(new Vector2(1700, 50), 1f, false);
            BPop.DOLocalMove(new Vector2(850, -630), 1f, false);
            SPop.DOLocalMove(new Vector2(250, -630), 1f, false);
            InPop.DOLocalMove(new Vector2(540, -630), 1f, false);
        }
        else if (c > 1.8)
        {
            UpPop.DOLocalMove(new Vector2(1700, 50), 1f, false);
            BPop.DOLocalMove(new Vector2(950, -630), 1f, false);
            SPop.DOLocalMove(new Vector2(370, -630), 1f, false);
            InPop.DOLocalMove(new Vector2(670, -630), 1f, false);
        }

    }
    public void Close()
    {
     if(c <= 1.8)
        {
            UpPop.DOLocalMove(new Vector2(410, 50), 1f, false);
            BPop.DOLocalMove(new Vector2(850, -430), 1f, false);
            SPop.DOLocalMove(new Vector2(250, -430), 1f, false);
            InPop.DOLocalMove(new Vector2(540, -430), 1f, false);
        }
     else if(c > 1.8)
        {
            UpPop.DOLocalMove(new Vector2(530, 50), 1f, false);
            BPop.DOLocalMove(new Vector2(950, -430), 1f, false);
            SPop.DOLocalMove(new Vector2(370, -430), 1f, false);
            InPop.DOLocalMove(new Vector2(670, -430), 1f, false);
        }
        
    }
}
