using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatTouch : MonoBehaviour
{
    Animation ani;
    void Start()
    {
        ani = this.GetComponent<Animation>();
    }
    public void CatbeenTouch(){
        ani.Play("CTouch");
    }
}