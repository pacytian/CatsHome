using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePressure : MonoBehaviour
{
    VM vm;
    SpriteRenderer sp;
    Color spcolor;
    float pressure = 0;
    float pressuremax = 100;
    Transform colortrans;
    Vector3 pos;

    void Start()
    {
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
        GameObject color = this.transform.Find("Color").gameObject;
        colortrans = color.transform;
        sp = color.GetComponent<SpriteRenderer>();
        spcolor = sp.color;
        //Debug.Log(colortrans.localPosition);
    }
   
    void Update()
    {
        pos = colortrans.localPosition;
        pressuremax = vm.PressureMax;
        //Debug.Log(colorgreen + "   " + strengthmax);
        sp.color = new Color(spcolor.r,spcolor.g,Remap(pressure,0.0f,pressuremax,1.0f,0.0f),spcolor.a);
        pos.y = Remap(pressure,0.0f,pressuremax,-0.5f,0.0f);
        colortrans.localPosition = pos;
    }
    
    //映射区间，t是输入区间，s是输出区间，1最小值2最大值
    float Remap(float x, float t1, float t2, float s1, float s2){
        return (s2 - s1) / (t2 - t1) * (x - t1) + s1;
    }

    //接收PlayerController.cs的燃料值传参
    void GetValueOfPressure(float value){
        pressure = value;
        //Debug.Log("CurrentPressure: " + pressure + "/" + pressure);
    }
}

