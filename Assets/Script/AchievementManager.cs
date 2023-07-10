using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AchievementManager : MonoBehaviour
{
    public int nowachi;
    int achinum;
    public GameObject[] Achi = new GameObject[11];
    public GameObject Intro;
    public GameObject Reddot;
    public GameObject ReddotA;
    [ReadOnly] public int[] Achievement = new int[11];
    void Start(){
        nowachi = 0;
        achinum = 0;
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
        for(int i = 1;i < 11;i ++){
            if(gameObject.GetComponent<CatManager>().CatBreed[i] == 1){
                Achi[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<CatManager>().CatSp[i];
                Achi[i].transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color(1,1,1,1);
                Achi[i].transform.GetChild(4).gameObject.SetActive(true);
            }
            if(Achievement[i] == 1){
                achinum ++;
                Achi[i].transform.GetChild(3).gameObject.GetComponent<Button>().interactable = true;
            }
        }
    }
    void OnEnable()
    {
        nowachi = 0;
        achinum = 0;
        ReddotA.SetActive(false);
        PlayerPrefs.SetInt("newachi",0);
        PlayerPrefs.Save();
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
        for(int i = 1;i < 11;i ++){
            if(gameObject.GetComponent<CatManager>().CatBreed[i] == 1){
                Achi[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<CatManager>().CatSp[i];
                Achi[i].transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color(1,1,1,1);
                Achi[i].transform.GetChild(4).gameObject.SetActive(true);
            }
            if(Achievement[i] == 1){
                achinum ++;
                Achi[i].transform.GetChild(3).gameObject.GetComponent<Button>().interactable = true;
            }
        }
    }

    public void ObtainAchievement(int i){
        if (Achievement[8] == 0 && achinum >= 6){
            PlayerPrefs.SetInt("Achi8",1);
            PlayerPrefs.Save();
            Achi[8].transform.GetChild(3).gameObject.GetComponent<Button>().interactable = true;
        }
        Reddot.SetActive(true);
        nowachi = i;
        PlayerPrefs.SetInt("Cat"+ nowachi.ToString(), 1);
        Debug.Log("finish" + i);
        PlayerPrefs.Save();
        Intro.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<CatManager>().CatSp[i];
        Intro.transform.GetChild(2).gameObject.transform.localScale = new Vector3(3,3,1);
        
        if (i < 7){
            Intro.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            Intro.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        }
        else{
            Intro.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            Intro.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        }
        Intro.transform.GetChild(1).GetChild(2).gameObject.GetComponent<Text>().text = gameObject.GetComponent<CatManager>().CatName[i];
        Intro.transform.GetChild(1).GetChild(3).gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<CatManager>().CatSp[i];
        Intro.transform.GetChild(1).GetChild(4).gameObject.GetComponent<Text>().text = gameObject.GetComponent<CatManager>().CatIntro[i];
        Intro.SetActive(true);
        
        Achi[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<CatManager>().CatSp[i];
        Achi[i].transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color(1,1,1,1);
        Achi[i].transform.GetChild(4).gameObject.SetActive(true);
    }
    public void CloseGetCat(){
        Intro.SetActive(false);
    }
}
