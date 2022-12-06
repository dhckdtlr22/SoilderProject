using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BGM : MonoBehaviour
{
    public Slider BGMVOL;
    public AudioSource audio;
    private void Start()
    {
        audio.volume = 0.5f;
    }
   
   
    private void Update()
    {
        audio.volume = BGMVOL.value;
    }
}
