using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementTrial : MonoBehaviour
{
    float bgspeed;
    VM vm;
    float timer = 1.0f;
    bool ismove = true;
    LevelRandom LR;
    float colorA;
    SpriteRenderer sp;
    void Start()
    {
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
        LR = GameObject.Find("Element").GetComponent<LevelRandom>();
        sp = this.GetComponent<SpriteRenderer>();
        colorA = sp.color.a;
        //player.isinvincible = true;
    }

    // Update is called once per frame
    void Update()
    {
        bgspeed = vm.BGFrontSpeed;
        if (ismove){
            transform.Translate(Vector3.down * Time.deltaTime * bgspeed * 6);
        }
        if (timer > 0){
            timer -= Time.deltaTime;
        }
        if (!ismove && timer < 2){
            vm.transform.GetChild(3).gameObject.SetActive(true);

        }

        if (timer <= 0 && ismove){
            ismove = false;
            //GameObject.Find("Player").GetComponent<PlayerController>().SendMessage("GetValueOfI",true);
            //LR.BuildPause();
            timer = 4.0f;
        }
        if (!ismove){
            colorA -= Time.deltaTime * 0.5f / 4;
            sp.color = new Color(sp.color.r,sp.color.g,sp.color.b,colorA);
        }
        
        if (!ismove && timer <= 0){
            //LR.BulidElement();
            LR.ispunish = false;
            ismove = true;
            timer = 10;
        }

        
        if (transform.position.y < -3){
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        /*if (other.CompareTag("Element")){
            //Debug.Log("OnTriggerStay:" + other.name);
            //Destroy(other.gameObject);
        }*/
        PlayerController player = other.GetComponent<PlayerController>();
        SmallCat cat = other.GetComponent<SmallCat>();
        if (player != null || cat != null){
            if (player == null){            
                player = other.transform.parent.parent.GetComponent<PlayerController>();
            }
            player.ChangePressureOnce(vm.TrialValue);
            player.SendMessage("GetValueOfI",true);
            vm.GetComponent<AudioEffect>().Pass();
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().SendMessage("GetValueOfS","trial");
            Destroy(gameObject);
        }
        else{
            return;
        }
    }
}
