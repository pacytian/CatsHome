using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStrength : MonoBehaviour
{
    VM vm;
    SpriteRenderer sp;
    Color spcolor;
    float colorgreen = 1;
    float strengthmax =1;
    Transform colortrans;
    GameObject player;
    GameObject color;
    Vector3 pos;

    void Start()
    {
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
        color = this.transform.Find("Player/Strength/Color").gameObject;
        player = this.transform.Find("Player").gameObject;
        colortrans = color.transform;
        sp = color.GetComponent<SpriteRenderer>();
        spcolor = sp.color;
        //Debug.Log(colortrans.localPosition);
    }
    
    void Update()
    {
        pos = colortrans.localPosition;
        strengthmax = vm.StrengthMax;
        //Debug.Log(colorgreen + "   " + strengthmax);
        sp.color = new Color(spcolor.r,Remap(colorgreen,0.0f,strengthmax,0.0f,1.0f),spcolor.b,spcolor.a);
        pos.y = Remap(colorgreen,0.0f,strengthmax,-1.0f,0.0f);
        colortrans.localPosition = pos;
    }

    //映射区间，t是输入区间，s是输出区间，1最小值2最大值
    float Remap(float x, float t1, float t2, float s1, float s2){
        return (s2 - s1) / (t2 - t1) * (x - t1) + s1;
    }

    //接收PlayerController.cs的体力值传参
    void GetValueOfStrength(float value){
        colorgreen = value;
    }
}
