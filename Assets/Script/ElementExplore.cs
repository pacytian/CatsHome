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
            Destroy(other.gameObject);
        }
        PlayerController player = other.GetComponent<PlayerController>();
        SmallCat cat = other.GetComponent<SmallCat>();
        if (player != null || cat != null){
            if (player == null){
            player = other.transform.parent.parent.GetComponent<PlayerController>();
            }
            if(isbigprize){
                player.ChangePressureOnce(vm.PressureMax * -1);
            }
            Destroy(gameObject);
        }
        else{
            return;
        }
    }
}
