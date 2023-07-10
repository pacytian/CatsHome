using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    VM vm;
    float movex;
    float movey;
    Vector2 dir;
    float movespeed;
    [ReadOnly] public float strength;
    float strengthmax;
    float moveconsume;
    float strengthrevoverstep;
    bool isstrengthrecoverable = false;
    bool isoverheat = false;
    public Animator ani;
    private Rigidbody2D rbody;
    float pressuremax;
    [ReadOnly] public float pressure;
    float pressurestep;
    [ReadOnly] public bool isinvincible = false;
    [ReadOnly] public float invincibaletimer;
    float invincibaletime;
    float bufftime;
    float buffspeed;
    [ReadOnly] public float bufftimer;
    [ReadOnly] public bool isbuff = false;
    bool candash = true;
    SpriteRenderer spS;
    SpriteRenderer spB;
    public GameObject Pressure;
    public GameObject Warning;
    public SpriteRenderer Playercat;
    public GameObject[] dash = new GameObject[2];
    public Sprite[] spcat;
    GameObject Strength;
    public GameObject bgg;
    
    void Start()
    {
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
        //ani = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        ani.SetFloat("movex",0);
        ani.SetFloat("movey",0);
        strength = vm.StrengthMax;
        pressure = 0;
        //invincibaletimer = vm.InvincibaleTime;
        bufftimer = vm.BuffTime;
        isinvincible = true;
        isbuff = false;
        invincibaletimer = 1.5f;
        spS = this.transform.Find("Invincibale").gameObject.GetComponent<SpriteRenderer>();
        spB = this.transform.Find("Buff").gameObject.GetComponent<SpriteRenderer>();
        Strength = this.transform.Find("Strength").gameObject;
    }

    public void Init(){
        ani.SetFloat("movex",0);
        ani.SetFloat("movey",0);
        strength = vm.StrengthMax;
        pressure = 0;
        isinvincible = true;
        isbuff = false;
        invincibaletimer = 1.5f;
        bufftimer = vm.BuffTime;
        SetValueOfStrength(strength);
        SetValueOfPressure(pressure);
    }

    void Update()
    {
        if (vm.CatBreed == 9){
            bgg.SetActive(true);
            if(pressure < 25){
                pressure = 25;
                SetValueOfPressure(pressure);
            }
        }
        else{
            bgg.SetActive(false);
        }

        if (!isbuff){
            movespeed = vm.MoveSpeed;
        }
        strengthmax = vm.StrengthMax;
        moveconsume = vm.MoveCost;
        strengthrevoverstep = vm.StrengthRecoverStep;
        pressuremax = vm.PressureMax;
        pressurestep = vm.PressureIncrease;
        invincibaletime = vm.InvincibaleTime;
        bufftime = vm.BuffTime;
        buffspeed = vm.BuffSpeed;

        //if (Time.frameCount % 10 == 0){
            movex = Input.GetAxisRaw ("Horizontal");
            movey = Input .GetAxisRaw ("Vertical");
            dir = new Vector2(movex,movey);
            if (isinvincible){
                IsInvincible();
            }
            else{
                ChangePressure(pressurestep);
            }

            if (isbuff){
                IsBuff();
            }

            if (dir.magnitude != 0 && IsStrengthEnough(moveconsume) && !isoverheat){
            //if (dir.magnitude != 0 && !isoverheat){
                IsMove();
            } 
            else{
                IsIdle();
            };
            RecoverStrength();
            //传参
            SetValueOfStrength(strength);
        //}
    }
    
    // 是否能恢复能量以及恢复能量
    void RecoverStrength(){
        if (!isstrengthrecoverable)
            return;
        else if (strength >= strengthmax){
            strength = strengthmax;
            isoverheat = false;
            return;
        }
        else if (strength < strengthmax){
            //strengthrevoverstep = Time.deltaTime * 100;
            strength += strengthrevoverstep * Time.deltaTime * 30;
        }
    }
    
    //是否能够移动以及移动扣能量
    bool IsStrengthEnough(float val){
        if (isbuff){
            return true;
        }
        else {
            if (!isoverheat){
                if (strength <= 0){
                    //isoverheat = true;
                    return false;
                }
                else{
                    strength -= val * Time.deltaTime * 30;
                    return true;
                }
            }
            else{
                return false;
            }
        }
    }   
    
    //无输入状态下静止回能量
    void IsIdle(){
        ani.SetFloat("movex",0);
        ani.SetFloat("movey",0);
        rbody.velocity = new Vector2(0,0);
        isstrengthrecoverable = true;
        Playercat.sprite = spcat[1];
        Playercat.flipX = false;
    }
    
    //有输入且无Buff状态下移动/冲刺，不回能量
    void IsMove(){
        if (Time.timeScale == 0){
            return;
        }
        if (movex != 0){
            ani.SetFloat("movex",movex);
            ani.SetFloat("movey",0);
            if (movex > 0){
                Playercat.sprite = spcat[0];
                Playercat.flipX = true;
            }
            else{   
                Playercat.sprite = spcat[0];
                Playercat.flipX = false;
            }
        }
        if (movey != 0){
            ani.SetFloat("movey",movey);
            ani.SetFloat("movex",0);
            Playercat.sprite = spcat[1];
            Playercat.flipX = false;
        }
        if (!isbuff){
            //isstrengthrecoverable = false;
        }
        /*if (Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown(KeyCode.RightShift)){
            if (IsStrengthEnough(moveconsume)){
                rbody.velocity = dir * buffspeed * Time.deltaTime * 30;
            }
        }
        else{
            rbody.velocity = dir * movespeed * Time.deltaTime * 30;
        }*/
        rbody.velocity = dir * movespeed * Time.deltaTime * 30;
        if (Input.GetKeyDown(KeyCode.Space)){
            if(isbuff){
                rbody.position = dir * 0.6f + rbody.position;
                if (movex > 0){
                    dash[1].SetActive(true);
                }
                else{   
                    dash[0].SetActive(true);
                }
            }
            else if (strength - vm.DashCost >= 0){
                strength -= vm.DashCost;
                rbody.position = dir * 0.6f + rbody.position;
                if (movex > 0){
                    dash[1].SetActive(true);
                }
                else{   
                    dash[0].SetActive(true);
                }
            }
        }
        rbody.position = new Vector3(Mathf.Clamp(rbody.position.x, -1.2f, 1.2f),Mathf.Clamp(rbody.position.y ,-2.1f, 2.1f),-5);
        if (rbody.position.x < -0.65){
            Strength.transform.localPosition = new Vector3(2.5f,-0.3f,-1);
        }
        else{
            Strength.transform.localPosition = new Vector3(-2.5f,-0.3f,-1);
        }
    }
    


    //压力值（燃料）变化
    public void ChangePressure(float num){
        if (num > 0){
            if (isinvincible){
                return;
            }
        }
        pressure = Mathf.Clamp(pressure + num * Time.deltaTime * 30, 0, pressuremax);
        SetValueOfPressure(pressure);
        //Debug.Log("CurrentPressure: " + pressure + "/" + pressure);
    }


    public void ChangePressureOnce(float num){
        pressure = pressure + num;
        SetValueOfPressure(pressure);
    }
    
    // 传参到ChangeStrength.cs
    void SetValueOfStrength(float Strength){
        this.transform.parent.gameObject.GetComponent<ChangeStrength>().SendMessage("GetValueOfStrength",Strength);
    }
    
    // 传参到ChangePressure.cs,IsGameOver.cs,Warning.cs
    void SetValueOfPressure(float value){
        Pressure.GetComponent<ChangePressure>().SendMessage("GetValueOfPressure",value);
        //this.transform.parent.gameObject.GetComponent<IsGameOver>().SendMessage("GetValueOfIGO",value);
        Warning.GetComponent<Warning>().SendMessage("GetValueOfW",value);
    }
    
    //接收无敌状态变化
    void GetValueOfI(bool value){
        if (pressure < pressuremax){
            isinvincible = value;
        }

    }

    //接收增益状态变化
    void GetValueOfB(bool value){
        isbuff = value;

    }
    
    //无敌倒计时
    void IsInvincible(){
        if (spS.enabled == false){
            spS.enabled = true;
        }
        invincibaletimer -= Time.deltaTime;
        
        if (invincibaletimer < 1 && invincibaletimer > 0){
            float remainder = invincibaletimer % 0.2f;
		    spS.enabled = remainder > 0.1f;
        }
        Debug.Log("Your are invincible");
        if (invincibaletimer < 0){
            isinvincible = false;
            spS.enabled = false;
            invincibaletimer = invincibaletime;
        }
    }

    //增益倒计时
    void IsBuff(){
        if (spB.enabled == false){
            spB.enabled = true;
            isstrengthrecoverable = true;
            movespeed = buffspeed;
            strength = strengthmax;
        }
        bufftimer -= Time.deltaTime;
        if (bufftimer < 1 && bufftimer > 0){
            float remainder = bufftimer % 0.2f;
		    spB.enabled = remainder > 0.1f;
        }
        Debug.Log("Your obtain the buff");
        if (bufftimer < 0){
            isbuff = false;
            spB.enabled = false;
            bufftimer = bufftime;
        }
    }

}
    