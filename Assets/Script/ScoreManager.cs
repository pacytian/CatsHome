using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour
{
    int[] HighScore = new int[6];
    //public Text[] HS= new Text[5];
    public float CurrentScore;
    public int[] ElementCount = new int[7];
    public int IsHS = 0;
    public bool isdebuffcat = false;
    public bool ispregnant = false;
    public bool isthreebottle = false;
    VM vm;

    //public Text Score;
    void Start()
    {
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
        CurrentScore = 0;
        HighScore[0] = PlayerPrefs.GetInt("HS0",0);
        HighScore[1] = PlayerPrefs.GetInt("HS1",0);
        HighScore[2] = PlayerPrefs.GetInt("HS2",0);
        HighScore[3] = PlayerPrefs.GetInt("HS3",0);
        HighScore[4] = PlayerPrefs.GetInt("HS4",0);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentScore += Time.deltaTime * 10;
        if(CurrentScore > 999999){
            CurrentScore = 999999;
        }
        //Score.text = Convert.ToInt32(CurrentScore).ToString();
        this.GetComponent<ScoreShow>().Show(Convert.ToInt32(CurrentScore));
        if (vm.PriceNum == 3 && !isthreebottle){
            isthreebottle = true;
        }
    }

   void GetValueOfS(string value){
        switch (value){
            case "bonus":
                ElementCount[1]++;
                CurrentScore += 100;
            break;
            case "buff":
                ElementCount[2]++;
                CurrentScore += 100;
            break;
            case "cat":
                ElementCount[4]++;
                CurrentScore += 500;
            break;
            case "explore":
                ElementCount[6]++;
                CurrentScore += 200;
            break;
            case "price":
                ElementCount[3]++;
                CurrentScore += 200;
            break;
            case "punish":
                ElementCount[0]++;
                CurrentScore += 0;
            break;
            case "trial":
                ElementCount[5]++;
                CurrentScore += 1000;
            break;
            default:
            Debug.Log("Unknown Elements");
            break;
        }

    }
    
    public void InitScore(){
        HighScore[5] = Convert.ToInt32(CurrentScore);
        for (int i = 0;i < 5;i++){
            if (HighScore[5] > HighScore[i]){
                if (i == 0){
                    IsHS = 2;
                }
                else{
                    IsHS = 1;
                }
                for (int j = 4;j > i;j--){
                    HighScore[j] = HighScore[j - 1];
                }
                HighScore[i] = HighScore[5];
                break;
            }
        }

        for (int i = 0;i < 5;i++){
            PlayerPrefs.SetInt("HS"+ i.ToString(), HighScore[i]);
        }

        PlayerPrefs.Save();
        //CurrentScore = 0;

        //for (int i = 0;i < 5;i++){
            //HS[i].text = HighScore[i].ToString();
        //}
    }


}
