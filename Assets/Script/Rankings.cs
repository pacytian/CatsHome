using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Rankings : MonoBehaviour
{
    int[] HighScore = new int[6];
    public Text[] HS= new Text[5];
    void Start()
    {
        HighScore[0] = PlayerPrefs.GetInt("HS0",0);
        HighScore[1] = PlayerPrefs.GetInt("HS1",0);
        HighScore[2] = PlayerPrefs.GetInt("HS2",0);
        HighScore[3] = PlayerPrefs.GetInt("HS3",0);
        HighScore[4] = PlayerPrefs.GetInt("HS4",0);
        for (int i = 0;i < 5;i++){
            HS[i].text = HighScore[i].ToString().PadLeft(6,'0');
        }
    }

}
