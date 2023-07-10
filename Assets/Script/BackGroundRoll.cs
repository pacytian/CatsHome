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
    float speed;
    public int switchcounter = 0;
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

    public void BGInit(){
        bg1.transform.position = startPosition;
        bg2.transform.position = endPosition;
        bg1.SetActive(true);
        bg2.SetActive(true);
        bg3.SetActive(false);
        bg4.SetActive(false);
        bg3.transform.position = endPosition;
        bg4.transform.position = endPosition;
        switchcounter = 0;
        bgnow1 = bg1;
        bgnow2 = bg2;
    }
    
    void Update()
    {
        speed = vm.BGSpeed;
        bgnow2.transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
        bgnow1.transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
        if (bgnow2.transform.position.y < startPosition.y)
        {
            bgnow1.transform.position = endPosition;
            bgnow1 = bgnow2;
            if (switchcounter == 0){
                bg1.SetActive(false);
                bg3.SetActive(true);
                bgnow2 = bg3;
                switchcounter ++;
            }
            else if (switchcounter == 1){
                bg2.SetActive(false);
                bg4.SetActive(true);
                bgnow2 = bg4;
                switchcounter ++;
            }
            else if (switchcounter == 2){
                bg3.SetActive(false);
                bg1.SetActive(true);
                bgnow2 = bg1;
                switchcounter ++;
            }
            else if (switchcounter == 3){
                bg4.SetActive(false);
                bg2.SetActive(true);
                bgnow2 = bg2;
                switchcounter = 0;
            }
         //Debug.Log(switchcounter);
        }
    }

}
