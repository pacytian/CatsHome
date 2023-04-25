using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    float pressure = 0;
    float pressuremax = 100;
    float colorA;
    bool warn = false;
    bool iscolora;
    SpriteRenderer sp;
    float speed = 0.6f;
    VM vm;
    
    void Start()
    {
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
        sp = this.GetComponent<SpriteRenderer>();
        colorA = sp.color.a;
    }

    void Update()
    {
        pressuremax = vm.PressureMax;
        speed = vm.FlashSpeed;
        if (pressure >= pressuremax * 0.8){
            warn = true;
            //Debug.Log("Warning! Nearly GameOver");
        }
        else if (pressure < pressuremax){
            warn = false;
            sp.color = new Color(sp.color.r,sp.color.g,sp.color.b, 0);
            colorA = 0;
        }
        if (warn){
            if (colorA >= 0.3){
                iscolora = true;
            }
            else if (colorA <=0){
                iscolora = false;
            }
            if (iscolora){
                colorA -= speed * Time.deltaTime;
            }
            else{
                colorA += speed * Time.deltaTime;
            }
            sp.color = new Color(sp.color.r,sp.color.g,sp.color.b,colorA);
            //Debug.Log(colorA);
        }
    }

    void GetValueOfW(float value){
        pressure = value;
    }
}
