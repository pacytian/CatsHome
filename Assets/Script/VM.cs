using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VM : MonoBehaviour
{ 
    public int CatBreed;//猫咪种类
    public PlayerController Player;
    public float BGFrontSpeed;//前景移动速度
    public float BGSpeed;//后景移动速度
    public float MoveSpeed;//角色移动速度
    public float MoveCost;//移动消耗体力值
    public float DashCost;//冲刺消耗体力值
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
    public float TrialValue;//考验的数值
    public float DeadDisappearTime;


    void Awake() {
        Application.targetFrameRate = 120;        
    }
    
    void Start()
    {
        //vm = GameObject.Find("ValueManager").GetComponent<VM>();
        Bottle [0] = transform.Find("bottle0").gameObject;
        Bottle [1] = transform.Find("bottle1").gameObject;
        Bottle [2] = transform.Find("bottle2").gameObject;
    }


    void Update()
    {
        if (CatBreed == 0){
            BuffTime = 4.0f;
            InvincibaleTime = 4.0f;
        }
        else{
            BuffTime = 3.0f;
            InvincibaleTime = 3.0f;
        }

        if (CatBreed == 1){
            RotateSpeed = 300;
        }
        else{
            RotateSpeed = 100f;
        }


        if (CatBreed == 2){
            DashCost = 25;
        }
        else if(CatBreed == 8){
            DashCost = 45;
        }
        else{
            DashCost = 35;
        }

        if (CatBreed == 5){
            DeadDisappearTime = 5;
        }
        else if(CatBreed == 7){
            DeadDisappearTime = 15;
        }
        else{
            DeadDisappearTime = 10;
        }
        
        if (CatBreed == 4){
            PriceNum = 1;
            Bottle[0].transform.GetChild (1).gameObject.SetActive(true);
            Bottle[0].transform.GetChild (0).gameObject.SetActive(false);
        }

        Strength = Player.strength;
        Pressure = Player.pressure;
        InvincibaleTimer = Player.invincibaletimer;
        BuffTimer = Player.bufftimer;

    }
}
