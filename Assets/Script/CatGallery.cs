using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CatGallery : MonoBehaviour
{
    public int nowcat;
    public GameObject[] CatImage = new GameObject[11];
    public GameObject Intro;
    public GameObject Reddot;
    public GameObject UIOut;

    void Start(){
        Reddot.SetActive(false);
        nowcat = 0;
        for(int i = 0;i < 11;i ++){
            if(gameObject.GetComponent<CatManager>().CatBreed[i] == 1){
                CatImage[i].SetActive(true);
                CatImage[i].gameObject.transform.parent.GetComponent<Image>().enabled = false;
            }
        }
        PlayerPrefs.SetInt("Cat0", 1);
        //PlayerPrefs.SetInt("Cat1", 1);
        PlayerPrefs.Save();
        UIOut.SetActive(false);
    }
    void OnEnable()
    {
        UIOut.SetActive(false);
        Intro.SetActive(false);
        Reddot.SetActive(false);
        nowcat = 0;
        for(int i = 0;i < 11;i ++){
            if(gameObject.GetComponent<CatManager>().CatBreed[i] == 1){
                CatImage[i].SetActive(true);
                CatImage[i].gameObject.transform.parent.GetComponent<Image>().enabled = false;
            }
        }
        PlayerPrefs.SetInt("Cat0", 1);
        PlayerPrefs.SetInt("Cat1", 1);
        PlayerPrefs.Save();
    }

    public void SetNowCat(int i){
        UIOut.SetActive(false);
        nowcat = i;
        if (i < 7){
            Intro.transform.GetChild(0).gameObject.SetActive(true);
            Intro.transform.GetChild(1).gameObject.SetActive(false);
        }
        else{
            Intro.transform.GetChild(1).gameObject.SetActive(true);
            Intro.transform.GetChild(0).gameObject.SetActive(false);
        }
        Intro.transform.GetChild(2).gameObject.GetComponent<Text>().text = gameObject.GetComponent<CatManager>().CatName[i];
        Intro.transform.GetChild(3).gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<CatManager>().CatSp[i];
        Intro.transform.GetChild(4).gameObject.GetComponent<Text>().text = gameObject.GetComponent<CatManager>().CatIntro[i];
        if (i == 9){
            Intro.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0,-300,0);
        }
        else{
            Intro.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0,-750,0);
        }
        Intro.SetActive(true);
    }

    public void CloseIntro(){
        Intro.SetActive(false);
        UIOut.SetActive(true);
    }

    

}
