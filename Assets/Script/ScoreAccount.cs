using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreAccount : MonoBehaviour
{
    /*public GameObject[] Digital;
    public Transform[] tf;
    public GameObject[] texture = new GameObject[12];*/
    int Score;
    ScoreManager sm;
    public Text[] Account = new Text[6];
    [ReadOnly] public int[] Achievement = new int[11];
    public GameObject reddot;
    void OnEnable()
    {
        sm = GameObject.Find("ScoreManager").gameObject.GetComponent<ScoreManager>();
        Score = Convert.ToInt32(sm.CurrentScore);
        Account[0].text = Score.ToString().PadLeft(6,'0');
        for (int i = 1;i < 6;i++){
            if (sm.ElementCount[i] > 99){
                Account[i].text = "99";
            }
            else{
                Account[i].text = sm.ElementCount[i].ToString().PadLeft(2,'0');
            }
        }
        IsAchievement();

    }

    void IsAchievement(){
        Achievement[0] = PlayerPrefs.GetInt("Achi0",1);
        Achievement[1] = PlayerPrefs.GetInt("Achi1",0);
        Achievement[2] = PlayerPrefs.GetInt("Achi2",0);
        Achievement[3] = PlayerPrefs.GetInt("Achi3",0);
        Achievement[4] = PlayerPrefs.GetInt("Achi4",0);
        Achievement[5] = PlayerPrefs.GetInt("Achi5",0);
        Achievement[6] = PlayerPrefs.GetInt("Achi6",0);
        Achievement[7] = PlayerPrefs.GetInt("Achi7",0);
        Achievement[8] = PlayerPrefs.GetInt("Achi8",0);
        Achievement[9] = PlayerPrefs.GetInt("Achi9",0);
        Achievement[10] = PlayerPrefs.GetInt("Achi10",0);
        for (int i = 1;i < 11;i ++){
            Debug.Log("try"+ i );
            if(Achievement[i] == 0){
                switch(i){
                    case 1:
                        PlayerPrefs.SetInt("Achi1",1);
                        reddot.SetActive(true);
                        PlayerPrefs.SetInt("newachi",1);
                    break;
                    case 2:
                        if (sm.isdebuffcat && Score > 3000){
                            PlayerPrefs.SetInt("Achi2",1);
                            reddot.SetActive(true);
                            PlayerPrefs.SetInt("newachi",1);
                        }
                    break;
                    case 3:
                        if (Score > 4000){
                            PlayerPrefs.SetInt("Achi3",1);
                            reddot.SetActive(true);
                            PlayerPrefs.SetInt("newachi",1);
                        }
                    break;
                    case 4:
                        if (sm.isdebuffcat && Score > 5000){
                            PlayerPrefs.SetInt("Achi4",1);
                            reddot.SetActive(true);
                            PlayerPrefs.SetInt("newachi",1);
                        }
                    break;
                    case 5:
                        if(sm.ElementCount[6] > 0){
                            PlayerPrefs.SetInt("Achi5",1);
                            reddot.SetActive(true);
                            PlayerPrefs.SetInt("newachi",1);
                        }
                    break;
                    case 6:
                        if (sm.ispregnant){
                            PlayerPrefs.SetInt("Achi6",1);
                            reddot.SetActive(true);
                            PlayerPrefs.SetInt("newachi",1);
                        }
                    break;
                    case 7:
                        if(sm.ElementCount[5] > 0){
                            PlayerPrefs.SetInt("Achi7",1);
                            reddot.SetActive(true);
                            PlayerPrefs.SetInt("newachi",1);
                        }
                    break;
                    case 8:
                    break;
                    case 9:
                        if(sm.isthreebottle){
                            PlayerPrefs.SetInt("Achi9",1);
                            reddot.SetActive(true);
                            PlayerPrefs.SetInt("newachi",1);
                        }
                    break;
                    case 10:
                            if (Score > 10000){
                            PlayerPrefs.SetInt("Achi10",1);
                            reddot.SetActive(true);
                            PlayerPrefs.SetInt("newachi",1);
                        }
                    break;          
                }
            }
        }
        PlayerPrefs.Save();
    }
}
