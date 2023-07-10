using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffect : MonoBehaviour
{
    public AudioClip[] clips;
    AudioSource soundeffect;
    public AudioSource soundeffectother1;
    public AudioSource soundeffectother2;
    public AudioSource soundeffectother3;
    int i = 0;
    float time = 1;
    bool istime = false;
    
    void Start()
    { 
        soundeffect = GetComponent<AudioSource>();  
    }

    void Update()
    {
        Timing();
    }
    void Timing(){
        if (istime){
            time -= Time.deltaTime;
            if (time <= 0){
                i = 0;
                istime = false;
            }
        }
    }

    public void Normal(){
        //Debug.Log(i);
        if (i < 4){
            i++;
        }
        soundeffect.clip = clips[i];
        soundeffect.Play();
        istime = true;
        time = 1;
    }
    public void Buff(){
        soundeffectother1.clip = clips[5];
        soundeffectother1.Play();
    }
    public void Price(){
        soundeffectother2.clip = clips[6];
        soundeffectother2.Play();
    }
    public void Explore(){
        soundeffectother1.clip = clips[7];
        soundeffectother1.Play();
    }
    public void Cat(){
        soundeffectother3.clip = clips[8];
        soundeffectother3.Play();
    }
    public void Pass(){
        soundeffectother3.clip = clips[10];
        soundeffectother3.Play();
    }

    public void Punish(){
        soundeffectother2.clip = clips[9];
        soundeffectother2.Play();
    }
}
