using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementTrial : MonoBehaviour
{
    float bgspeed = 0.1f;
    VM vm;
    float timer = 4.5f;
    void Start()
    {
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
        vm.transform.GetChild(3).gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        bgspeed = vm.BGFrontSpeed;
        if (timer > 0){
            timer -= Time.deltaTime;
        }
        else{
            transform.Translate(Vector3.down * Time.deltaTime * bgspeed * 6);
        }
        if (transform.position.y < -3){
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Element")){
            Debug.Log("OnTriggerStay:" + other.name);
            Destroy(other.gameObject);
        }
        PlayerController player = other.GetComponent<PlayerController>();
        SmallCat cat = other.GetComponent<SmallCat>();
        if (player != null || cat != null){
            if (player == null){            
                player = other.transform.parent.parent.GetComponent<PlayerController>();
            }
            player.ChangePressureOnce(vm.TrialValue);
            Destroy(gameObject);
        }
        else{
            return;
        }
    }
}
