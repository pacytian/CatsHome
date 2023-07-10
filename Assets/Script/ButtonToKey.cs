using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToKey : MonoBehaviour
{
    public GameObject[] BC;
    void Start()
    {
        
    }

    void Update()
    {
        if(BC[4].activeSelf){
            if((Input.GetKeyDown(KeyCode.Alpha1))){
                BC[4].GetComponent<ButtonCat>().ButtonChoosecat(2);
            }
            else if((Input.GetKeyDown(KeyCode.Alpha2))){
                BC[4].GetComponent<ButtonCat>().ButtonChoosecat(1);
            }
            else if((Input.GetKeyDown(KeyCode.Alpha3))){
                BC[4].GetComponent<ButtonCat>().ButtonChoosecat(3);
            }
        }        
        
        if (BC[0].activeSelf  && !BC[4].activeSelf && Input.GetKeyDown(KeyCode.P)){
            BC[0].GetComponent<ButtonController>().ButtonPause();
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            if (BC[0].activeSelf){
                return;
            }
            else if(BC[1].activeSelf){
                BC[1].GetComponent<ButtonController>().ButtonContinue();
            }
            else if(BC[2].activeSelf){
                BC[2].GetComponent<ButtonController>().ButtonRestart();
            }
        }
        /*else if(Input.GetKeyDown(KeyCode.Escape) && BC[3].activeSelf && !BC[0].activeSelf){
            BC[3].GetComponent<ButtonController>().ButtonEnd();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && BC[0].activeSelf){
            BC[0].GetComponent<ButtonController>().ButtonPause();
        }*/
    }
}
