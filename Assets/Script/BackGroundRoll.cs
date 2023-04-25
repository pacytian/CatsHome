using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRoll : MonoBehaviour
{
    GameObject bg1;
    GameObject bg2;
    GameObject bg3;
    GameObject bg4;
    GameObject bgnow1;
    GameObject bgnow2;
    GameObject swap;
    float speed = 0.1f;
    int switchcounter = -1;
    int switchcountermax = 2;
    VM vm;
    Vector3 startPosition;
    Vector3 endPosition;
    
    void Start()
    {
        //Invoke("SwitchBackGround", 10.0f);
        bg1 = transform.Find("BG1").gameObject;
        bg2 =  transform.Find("BG2").gameObject;
        bg3 =  transform.Find("BG3").gameObject;
        bg4 =  transform.Find("BG4").gameObject;
        bgnow1 = bg1;
        bgnow2 = bg2;
        startPosition = bg1.transform.position;
        endPosition = bg2.transform.position;
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
    }

    void Update()
    {
        speed = vm.BGSpeed;
        switchcountermax = vm.BGSwitchMax;
        bgnow1.transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
        bgnow2.transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
        if (bgnow2.transform.position.y < startPosition.y)
        {
            bgnow1.transform.position = endPosition;
            swap = bgnow1;
            bgnow1 = bgnow2;
            bgnow2 = swap;
            switchcounter ++;
            if (switchcounter == switchcountermax - 1){
                bg2.SetActive(false);
                bg4.SetActive(true);
                bgnow2 = bg4;
            }
            else if (switchcounter == switchcountermax){
                bg1.SetActive(false);
                bg3.SetActive(true);
                bgnow2 = bg3;
            }
            else if (switchcounter == switchcountermax * 2 - 1){
                bg4.SetActive(false);
                bg2.SetActive(true);
                bgnow2 = bg2;
            }
            else if (switchcounter == switchcountermax * 2){
                bg3.SetActive(false);
                bg1.SetActive(true);
                bgnow2 = bg1;
                switchcounter = 0;
            }
         //Debug.Log(switchcounter);
        }
    }

}
