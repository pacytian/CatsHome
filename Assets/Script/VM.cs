using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VM : MonoBehaviour
{ 
    public PlayerController Player;
    public float BGFrontSpeed;//前景移动速度
    public float BGSpeed;//后景移动速度
    public int BGSwitchMax;//后景切换数量
    public float MoveSpeed;//角色移动速度
    public float MoveCost;//移动消耗体力值
    public float StrengthMax;//体力最大值
    [ReadOnly] public float Strength;//体力
    public float StrengthRecoverStep;//体力恢复值
    public float PressureMax;//压力最大值
    [ReadOnly] public float Pressure;//压力
    public float PressureIncrease;//压力增长值
    public float InvincibaleTime;//无敌时长
    [ReadOnly] public float InvincibaleTimer;//无敌倒计时器
    public float FlashSpeed;//警告闪烁速度
    public float RotateSpeed;//小猫旋转速度
    public float BuffTime;//Buff时长
    public float BuffSpeed;//Buff期间的移动速度
    [ReadOnly] public float BuffTimer;//Buff倒计时器
    public float RandomBulidTime;//元素自动生成的时间
    [ReadOnly] public int PriceNum;//血瓶数量
    public float PriceValue;//血瓶数值
    [ReadOnly] public GameObject[] Bottle = new GameObject[3];
    public float HorizontalSpeed;//元素横向移动的速度
    public float TrialValue;


    void Start()
    {
        //vm = GameObject.Find("ValueManager").GetComponent<VM>();
        Bottle [0] = transform.Find("bottle0").gameObject;
        Bottle [1] = transform.Find("bottle1").gameObject;
        Bottle [2] = transform.Find("bottle2").gameObject;
    }


    void Update()
    {
        Strength = Player.strength;
        Pressure = Player.pressure;
        InvincibaleTimer = Player.invincibaletimer;
        BuffTimer = Player.bufftimer;

    }
}
