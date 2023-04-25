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
    [ReadOnly] public float InvincibaleTimer;//无敌计时器
    public float FlashSpeed;//警告闪烁速度
    public float RotateSpeed;//小猫旋转速度
    public float BuffTime;
    public float BuffSpeed;
    [ReadOnly] public float BuffTimer;
    public float RandomBulidTime;
    [ReadOnly] public int PriceNum;//血瓶数量
    public float PriceValue;

    void Start()
    {
        //vm = GameObject.Find("ValueManager").GetComponent<VM>();
    }


    void Update()
    {
        Strength = Player.strength;
        Pressure = Player.pressure;
        InvincibaleTimer = Player.invincibaletimer;
        BuffTimer = Player.bufftimer;

    }
}
