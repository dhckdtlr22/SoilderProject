using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BattleStart : MonoBehaviour
{
    public float Curtime;
    public float Cooltime;
    public Transform[] CameraPos;
    public GameObject Cancel;
    public GameObject camera;
    public bool Istrue;
    public int a;
    public int b;
    public GameObject Text;
    public GameObject BG;
    public AudioSource audios;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        
        camera = GameObject.Find("Camera3");
        camera.transform.position = CameraPos[0].transform.position;
        camera.transform.rotation = CameraPos[0].transform.rotation;
        Debug.Log("111");
        
    }

    // Update is called once per frame
    void Update()
    {
        BG.SetActive(true);
        Cancel.SetActive(true);
        Istrue = true;
        Curtime += Time.deltaTime;
        if(Curtime >1f && b== 0)
        {
            audios.Play();
            b = 1;
        }
        if (Curtime > 3 && a == 0)
        {
            Text.SetActive(false);
            camera.transform.DOMove(CameraPos[1].transform.position, 5f);
            camera.transform.DORotateQuaternion(CameraPos[1].transform.rotation, 4f).SetEase(Ease.Unset);
            a = 1;
            
        }
        if (Curtime > Cooltime)
        {
            camera.transform.position = CameraPos[0].transform.position;
            camera.transform.rotation = CameraPos[0].transform.rotation;
            Cancel.SetActive(false);
            a = 0;
            b = 0;
            Curtime = 0;
            Istrue = false;
            BG.SetActive(false);
            gameObject.SetActive(false);
            
        }
    }
   
}
