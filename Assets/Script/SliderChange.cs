using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderChange : MonoBehaviour
{
    public VM vm;
    public float Speed;
    public Slider slider1;
    public Text text1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSlider0(){
        vm.BGFrontSpeed = slider1.value;
        text1.text = slider1.value.ToString("f2");
    }
    public void ChangeSlider1(){
        vm.MoveSpeed = slider1.value;
        text1.text = slider1.value.ToString("f2");
    }
    public void ChangeSlider2(){
        vm.DashCost = slider1.value;
        text1.text = slider1.value.ToString("f2");
    }
    public void ChangeSlider3(){
        vm.StrengthRecoverStep = slider1.value;
        text1.text = slider1.value.ToString("f2");
    }
    public void ChangeSlider4(){
        vm.PressureIncrease = slider1.value;
        text1.text = slider1.value.ToString("f2");
    }
    public void ChangeSlider5(){
        vm.RandomBulidTime = slider1.value;
        text1.text = slider1.value.ToString("f2");
    }



}
