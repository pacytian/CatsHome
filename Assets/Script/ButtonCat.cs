using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCat : MonoBehaviour
{
    int nowcat1;
    int nowcat2;
    int nowcat3;
    public GameObject[] Cat = new GameObject[3];
    List<int> catlist = new List<int>();
    VM vm;
    public PlayerController PC;
    public GameObject Intro;
    public Sprite[] RunCat;
    public ScoreManager SM;
    public GameObject guide;

    void Start(){
        if ((PlayerPrefs.GetInt("IsBeginner",0)) == 0){
            guide.SetActive(true);
            PlayerPrefs.SetInt("IsBeginner",1);
            PlayerPrefs.Save();
        }
        else{
            guide.SetActive(false);
        }
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
        Time.timeScale = 0;
        PC.gameObject.SetActive(false);
        for(int c = 0; c < 3;c ++){
            Cat[c].GetComponent<Button>().interactable = false;
        }
        catlist.Clear();
        for(int i = 0;i < 11;i ++){
            if(gameObject.GetComponent<CatManager>().CatBreed[i] ==1){
                catlist.Add(i);
            }
        }
        if(catlist.Count >= 3){
            nowcat3 = catlist[Random.Range(0,catlist.Count)];
            catlist.Remove(nowcat3);
            Cat[2].GetComponent<Button>().interactable = true;
            Cat[2].GetComponent<Image>().sprite = gameObject.GetComponent<CatManager>().CatSp[nowcat3];
        }
        if(catlist.Count >= 2){
            nowcat2 = catlist[Random.Range(0,catlist.Count)];
            catlist.Remove(nowcat2);
            Cat[1].GetComponent<Button>().interactable = true;
            Cat[1].GetComponent<Image>().sprite = gameObject.GetComponent<CatManager>().CatSp[nowcat2];
        }
        if(catlist.Count >= 1){
            nowcat1 = catlist[Random.Range(0,catlist.Count)];
            catlist.Remove(nowcat1);
            Cat[0].GetComponent<Button>().interactable = true;
            Cat[0].GetComponent<Image>().sprite = gameObject.GetComponent<CatManager>().CatSp[nowcat1];
        }
    }
    void OnEnable() {
        Time.timeScale = 0;
        PC.gameObject.SetActive(false);
        for(int c = 0;c < 3;c ++){
            Cat[c].GetComponent<Button>().interactable = false;
        }
        catlist.Clear();
        for(int i = 0;i < 11;i ++){
            if(gameObject.GetComponent<CatManager>().CatBreed[i] ==1){
                catlist.Add(i);
            }
        }
        if(catlist.Count >= 3){
            nowcat3 = catlist[Random.Range(0,catlist.Count)];
            catlist.Remove(nowcat3);
            Cat[2].GetComponent<Button>().interactable = true;
            Cat[2].GetComponent<Image>().sprite = gameObject.GetComponent<CatManager>().CatSp[nowcat3];
        }
        if(catlist.Count >= 2){
            nowcat2 = catlist[Random.Range(0,catlist.Count)];
            catlist.Remove(nowcat2);
            Cat[1].GetComponent<Button>().interactable = true;
            Cat[1].GetComponent<Image>().sprite = gameObject.GetComponent<CatManager>().CatSp[nowcat2];
        }
        if(catlist.Count >= 1){
            nowcat1 = catlist[Random.Range(0,catlist.Count)];
            catlist.Remove(nowcat1);
            Cat[0].GetComponent<Button>().interactable = true;
            Cat[0].GetComponent<Image>().sprite = gameObject.GetComponent<CatManager>().CatSp[nowcat1];
        }
    }


    public void ButtonChoosecat(int i){
        switch (i){
        case 1:
            i = nowcat1;
        break;
        case 2:
            i = nowcat2;
        break;
        case 3:
            i = nowcat3;
        break;
        }
        
        vm.CatBreed = i;
        
        if (i < 7){
            SM.isdebuffcat = false;
        }
        else{
            SM.isdebuffcat = true;
        }
        if(Random.Range(0,10) == 0){
            Debug.Log("ispregnant");
            SM.ispregnant = true;
            PC.gameObject.transform.GetChild(3).GetComponent<SmallCatController>().num = 1;
            PC.gameObject.transform.GetChild(3).GetComponent<SmallCatController>().counter = 1;
            PC.gameObject.transform.GetChild(3).GetComponent<SmallCatController>().sp[1].sprite = RunCat[i* 2 + 1];
            PC.gameObject.transform.GetChild(3).GetComponent<SmallCatController>().sp[1].enabled = true;
            PC.gameObject.transform.GetChild(3).GetComponent<SmallCatController>().sp[1].gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }

        PC.spcat[0] = RunCat[i* 2];
        PC.spcat[1] = RunCat[i* 2 + 1];
        Intro.SetActive(false);
        PC.gameObject.SetActive(true);
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
    public void ShowIntro(int i){
        switch (i){
            case 1:
                i = nowcat1;
            break;
            case 2:
                i = nowcat2;
            break;
            case 3:
                i = nowcat3;
            break;
        }
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
        Intro.SetActive(true);
    }
    public void CloseIntro(){
        Intro.SetActive(false);
    }

}
