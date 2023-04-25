using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCatController : MonoBehaviour
{
    
    GameObject cat;
    SpriteRenderer spcat;
    public int num = 0;
    public int counter = 0 ;
    VM vm;
    //SpriteRenderer sp1;
    
    //SpriteRenderer sp2;
    public SpriteRenderer[] sp;
    float pressureplus = 0.5f;
    //SpriteRenderer sp3;
    void Start()
    {
        //sp1 = transform.Find("Cat1").GetComponent<SpriteRenderer>();
        //sp2 = transform.Find("Cat2").GetComponent<SpriteRenderer>();
        //sp3 = transform.Find("Cat3").GetComponent<SpriteRenderer>();
        //vm.PressureIncrease = vm.PressureIncrease + pressureplus;
        //Debug.Log("vm.PressureIncrease");

    }

    void Update()
    {

    }

    public void ChangeCat(GameObject Cat){
        cat = Cat;
        spcat = cat.GetComponent<SpriteRenderer>();
        Debug.Log(spcat.sprite.name);
        if (counter == 3){
            num = Random.Range(0, 3);
        }
        else{
            num = ( num + 1) % 3;
            counter ++;
        }
        sp[num].sprite = spcat.sprite;
        if (sp[num].enabled == false){
            sp[num].enabled = true;
            sp[num].gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
    public void DestroyCat(){
        if (counter == 0){
            this.transform.parent.parent.GetComponent<IsGameOver>().GameOver();
        }
        else if (counter == 3){
            num = Random.Range(0, 3);
            sp[num].enabled = false;
            sp[num].gameObject.GetComponent<CircleCollider2D>().enabled = false;
            counter --;
            num = ( num + 2) % 3;
        }
        else if (counter == 1){
            sp[num].enabled = false;
            sp[num].gameObject.GetComponent<CircleCollider2D>().enabled = false;
            counter--;
            num = 0;
        }
        else{
            counter--;
            switch (num){
                case 0:
                    num = Random.Range(0,2) * 2;
                    sp[num].enabled = false;
                    sp[num].gameObject.GetComponent<CircleCollider2D>().enabled = false;
                    num = 2 - num;
                break;
                case 1:
                    num = Random.Range(0,2);
                    sp[num].enabled = false;
                    sp[num].gameObject.GetComponent<CircleCollider2D>().enabled = false;
                    num = 1 - num;
                break;
                case 2:
                    num = Random.Range(1,3);
                    sp[num].enabled = false;
                    sp[num].gameObject.GetComponent<CircleCollider2D>().enabled = false;
                    num = 3 - num;
                break;
            }
        }
    }
}

