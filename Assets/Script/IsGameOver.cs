using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsGameOver : MonoBehaviour
{
    VM vm;
    float pressure;
    float pressuremax;
    public bool isgameover = false;
    public GameObject pause;
    public GameObject restart;
    GameObject scoremanager;
    public Text HSText;
    PlayerController player;
    float value;
    public AudioClip[] clip;

    void Start()
    {
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
        scoremanager = GameObject.Find("ScoreManager").gameObject;
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
                if(vm.CatBreed == 3){
                    player.ChangePressureOnce(value * -1);
                }
                player.ChangePressureOnce(value * -1);
                vm.Bottle[vm.PriceNum].transform.GetChild (0).gameObject.SetActive(true);
                vm.Bottle[vm.PriceNum].transform.GetChild (1).gameObject.SetActive(false);
                //Debug.Log("A");
                return;
            }
            else if (vm.PriceNum == 2){
                //Debug.Log("B");
                vm.PriceNum --;
                if(vm.CatBreed == 3){
                    player.ChangePressureOnce(value * -1);
                }
                player.ChangePressureOnce(value * -1);
                vm.Bottle[vm.PriceNum].transform.GetChild (0).gameObject.SetActive(true);
                vm.Bottle[vm.PriceNum].transform.GetChild (1).gameObject.SetActive(false);
                return;
            }
            else if(vm.PriceNum == 1){
                //Debug.Log("C");
                vm.PriceNum --;
                if(vm.CatBreed == 3){
                    player.ChangePressureOnce(value * -1);
                }
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
        scoremanager.GetComponent<ScoreManager>().InitScore();
        switch (scoremanager.GetComponent<ScoreManager>().IsHS){
            case 0:
                GetComponent<AudioSource>().clip = clip[0];
                GetComponent<AudioSource>().Play();
                HSText.text = "KEEP GOING!";
            break;
            case 1:
                GetComponent<AudioSource>().clip = clip[1];
                GetComponent<AudioSource>().Play();
                HSText.text = "NEW RECORD!";
            break;
            case 2:
                GetComponent<AudioSource>().clip = clip[2];
                GetComponent<AudioSource>().Play();
                HSText.text = "TOP SCORE!";
            break;
            default:
                Debug.Log("Unknown Elements");
            break;
        }
        Time.timeScale = 0;
        pause.gameObject.SetActive(false);
        restart.gameObject.SetActive(true);
    }



    
}
