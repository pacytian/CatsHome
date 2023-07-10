using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CatManager : MonoBehaviour
{
    public Sprite[] CatSp = new Sprite[11];
    public string[] CatName = new string[11];
    public string[] CatIntro = new string[11];
    [ReadOnly] public int[] CatBreed = new int[11];
    void Start(){
        CatBreed[0] = PlayerPrefs.GetInt("Cat0",1);
        CatBreed[1] = PlayerPrefs.GetInt("Cat1",0);
        CatBreed[2] = PlayerPrefs.GetInt("Cat2",0);
        CatBreed[3] = PlayerPrefs.GetInt("Cat3",0);
        CatBreed[4] = PlayerPrefs.GetInt("Cat4",0);
        CatBreed[5] = PlayerPrefs.GetInt("Cat5",0);
        CatBreed[6] = PlayerPrefs.GetInt("Cat6",0);
        CatBreed[7] = PlayerPrefs.GetInt("Cat7",0);
        CatBreed[8] = PlayerPrefs.GetInt("Cat8",0);
        CatBreed[9] = PlayerPrefs.GetInt("Cat9",0);
        CatBreed[10] = PlayerPrefs.GetInt("Cat10",0);
    }
    
    void OnEnable()
    {
        CatBreed[0] = PlayerPrefs.GetInt("Cat0",1);
        CatBreed[1] = PlayerPrefs.GetInt("Cat1",0);
        CatBreed[2] = PlayerPrefs.GetInt("Cat2",0);
        CatBreed[3] = PlayerPrefs.GetInt("Cat3",0);
        CatBreed[4] = PlayerPrefs.GetInt("Cat4",0);
        CatBreed[5] = PlayerPrefs.GetInt("Cat5",0);
        CatBreed[6] = PlayerPrefs.GetInt("Cat6",0);
        CatBreed[7] = PlayerPrefs.GetInt("Cat7",0);
        CatBreed[8] = PlayerPrefs.GetInt("Cat8",0);
        CatBreed[9] = PlayerPrefs.GetInt("Cat9",0);
        CatBreed[10] = PlayerPrefs.GetInt("Cat10",0);

    }

}
