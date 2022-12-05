using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class CameraTr : MonoBehaviour
{
    public Transform[] CameraTrs;
    public GameObject imgs;
    public Text text;
    public int IsTake;
    public Prolog prolog;
    public GameObject BG;
    public GameObject But;
    public GameObject Text;
    public GameObject SkipBut;
    public GameObject Loading;
    public float Curtime;
    public float Cooltime;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();

        Curtime = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Curtime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && IsTake >= 0 && Curtime > Cooltime)
        {
            SkipBut.SetActive(true);
            BG.SetActive(false);
            But.SetActive(false);
            Text.SetActive(true);
            switch (IsTake)
            {
                case 0:
                    text.DOText("2066�� �ڷγ� ���̷��� 46�� ������ �������� �߻�", 3f);
                    transform.position = CameraTrs[IsTake].position;
                    transform.rotation = CameraTrs[IsTake].rotation;
                    break;
                case 1:
                    text.text = "";
                    text.DOText("�߻��� �������̴� ���� ���ݼ��� �ٸ� ������� �����ϱ� �����߰�", 3f);
                    transform.position = CameraTrs[IsTake].position;
                    transform.rotation = CameraTrs[IsTake].rotation;
                    prolog.IsTake = true;
                    break;
                case 2:
                    text.text = "";
                    text.DOText("�߻� 3�ϸ��� ������ �Զ��Ǳ� �����ߴ�.",2f);
                    transform.position = CameraTrs[IsTake].position;
                    transform.rotation = CameraTrs[IsTake].rotation;
                    break;
                case 3:
                    text.text = "";
                    text.DOText("���ε��� ������ �������� ��Ű�� �ο�����", 2f);
                    transform.position = CameraTrs[IsTake].position;
                    transform.rotation = CameraTrs[IsTake].rotation;
                    StartCoroutine(Wait());
                    
                    break;
                case 4:
                    But.SetActive(false);
                    Text.SetActive(false);
                    SkipBut.SetActive(false);
                    Loading.SetActive(true);
                    break;
            }
            IsTake++;
            Curtime = 0;
        }
        
        
            
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        transform.DOMove(CameraTrs[4].position, 2f);
        transform.DORotateQuaternion(CameraTrs[4].rotation, 2f);
    }
    public void Skip()
    {
        But.SetActive(false);
        Text.SetActive(false);
        SkipBut.SetActive(false );
        Loading.SetActive(true);
    }
}
