using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementExplore : MonoBehaviour
{
    float bgspeed = 0.1f;
    float value;
    VM vm;
    public bool isbigprize = false;
    void Start()
    {
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
    }

    void Update()
    {
        bgspeed = vm.BGFrontSpeed;
        transform.Translate(Vector3.down * Time.deltaTime * bgspeed * 6);
        if (transform.position.y < -3){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Element")){
            //Destroy(other.gameObject);
        }
        PlayerController player = other.GetComponent<PlayerController>();
        SmallCat cat = other.GetComponent<SmallCat>();
        if (player != null || cat != null){
            Debug.Log(transform.GetChild(0).gameObject.name);
            transform.GetChild(0).gameObject.SetActive(true);
            if (player == null){
            player = other.transform.parent.parent.GetComponent<PlayerController>();
            }
            if(isbigprize){
                if (Random.Range(0,2) == 0){
                    transform.GetChild(1).gameObject.SetActive(true);
                    player.SendMessage("GetValueOfI",true);
                    GameObject.Find("ScoreManager").GetComponent<ScoreManager>().SendMessage("GetValueOfS","bonus");
                }
                else{
                    transform.GetChild(2).gameObject.SetActive(true);
                    player.SendMessage("GetValueOfB",true);
                    GameObject.Find("ScoreManager").GetComponent<ScoreManager>().SendMessage("GetValueOfS","buff");
                }
                player.ChangePressureOnce(vm.PressureMax * -1);
                vm.GetComponent<AudioEffect>().Explore();
                GameObject.Find("ScoreManager").GetComponent<ScoreManager>().SendMessage("GetValueOfS","explore");
            }
            //Destroy(gameObject);
        }
        else{
            return;
        }
    }
}
