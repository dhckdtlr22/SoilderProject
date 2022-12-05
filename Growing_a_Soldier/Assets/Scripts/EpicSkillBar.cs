using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EpicSkillBar : MonoBehaviour
{
    public Transform target;

    public RectTransform canvas;
    public RectTransform Skillbar;
    
    public Camera mainCam;
    public GameObject SbarPrefab;
    public GameObject Skill01;
    public EpicSkill Skill;
    // Start is called before the first frame update
    void Start()
    {
        Skill01 = Instantiate(SbarPrefab, transform.position, transform.rotation);
        target = gameObject.transform;
        canvas = GameObject.Find("Canvas02").GetComponent<RectTransform>();
        Skill01.transform.parent = canvas;
        Skillbar = Skill01.GetComponent<RectTransform>();
        Skillbar.localScale = new Vector3(1,1,1);
        Skillbar.localRotation = Quaternion.Euler(0, 0, 0);
        mainCam = Camera.main;
        Skill = GetComponentInParent<EpicSkill>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 curPos = target.transform.position;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(curPos);
        Vector2 canvasPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, screenPoint, mainCam, out canvasPos);

        Skill01.GetComponent<Slider>().value = Skill.Skillcur / Skill.SkillCool;
        Skillbar.localPosition = canvasPos + new Vector2(0, 10);
        if (Skill.IsSkill01 == true)
        {
            
            Skill01.transform.GetChild(1).GetComponentInChildren<Image>().color = Color.blue;
        }
        else
        {
            Skill01.transform.GetChild(1).GetComponentInChildren<Image>().color = Color.green;
        }
    }
}
