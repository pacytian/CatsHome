using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatIdle : MonoBehaviour
{
    Animation ani;
    void Start()
    {
        ani = this.GetComponent<Animation>();
        InvokeRepeating("PlayAni",0.0f,0.8f);
    }

    // Update is called once per frame
    void PlayAni()
    {
        if (!ani.isPlaying){
            if(Random.Range(0.0f,2.0f) > 1){
                ani.Play();
            }
        }
    }
}
