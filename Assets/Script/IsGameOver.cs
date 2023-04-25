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
        pressure = player.pressure;
        pressuremax = vm.PressureMax;
        if (pressure >= pressuremax && isgameover == false){
            value = vm.PriceValue;
            if (vm.PriceNum == 3){
                vm.PriceNum --;
                player.ChangePressureOnce(value * -1);
                vm.Bottle[vm.PriceNum].transform.GetChild (0).gameObject.SetActive(true);
                vm.Bottle[vm.PriceNum].transform.GetChild (1).gameObject.SetActive(false);
                Debug.Log("A");
                return;
            }
            else if (vm.PriceNum == 2){
                Debug.Log("B");
                vm.PriceNum --;
                player.ChangePressureOnce(value * -1);
                vm.Bottle[vm.PriceNum].transform.GetChild (0).gameObject.SetActive(true);
                vm.Bottle[vm.PriceNum].transform.GetChild (1).gameObject.SetActive(false);
                return;
            }
            else if(vm.PriceNum == 1){
                Debug.Log("C");
                vm.PriceNum --;
                player.ChangePressureOnce(value * -1);
                vm.Bottle[vm.PriceNum].transform.GetChild (0).gameObject.SetActive(true);
                vm.Bottle[vm.PriceNum].transform.GetChild (1).gameObject.SetActive(false);
                return;
            }
            else{
                Debug.Log("GameOver");
                GameOver();
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
