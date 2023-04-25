using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGameOver : MonoBehaviour
{
    VM vm;
    float pressure;
    float pressuremax;
    public bool isgameover = false;
    public GameObject pause;
    public GameObject restart;
    PlayerController player;
    float value;

    void Start()
    {
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
        player = this.transform.Find("Player").gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        pressuremax = vm.PressureMax;
        if (pressure == pressuremax && isgameover == false){
            value = vm.PriceValue;
            if (vm.PriceNum == 3){
                Debug.Log("A");
                Debug.Log(value * -1);
                player.ChangePressure(value * -2);
                vm.PriceNum --;
                return;
            }
            else if (vm.PriceNum == 2){
                Debug.Log("B");
                player.ChangePressure(value * -2);
                vm.PriceNum --;
                return;
            }
            else if(vm.PriceNum == 1){
                Debug.Log("C");
                Debug.Log(value * -2);
                player.ChangePressure(value * -2);
                vm.PriceNum --;
                return;
            }
            else{
                Debug.Log("D");
                //GameOver();
            }
        }
    }

    void GetValueOfIGO(float value){
        pressure = value;
    }

    public void GameOver(){
        isgameover = true;
        Debug.Log("GameOver");
        Time.timeScale = 0;
        pause.gameObject.SetActive(false);
        restart.gameObject.SetActive(true);
    }
}
