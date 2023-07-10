using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    public GameObject Target1;
    public GameObject Target2;
    public GameObject Reddot;
    void Start()
    {
        if (Reddot != null && PlayerPrefs.GetInt("newachi",0) == 1){
            Reddot.SetActive(true);
        }
    }

    public void ButtonChange(){
        Target2.SetActive(true);
        Target1.SetActive(false);
    }

    public void ButtonStart(){
        SceneManager.LoadScene("MainScene");
    }

}
