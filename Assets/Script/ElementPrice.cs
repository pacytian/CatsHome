using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementPrice : MonoBehaviour
{
    float bgspeed = 0.1f;
    float value;
    VM vm;
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
        value = vm.PriceValue;
        if (other.CompareTag("Element")){
            Destroy(other.gameObject);
        }
        PlayerController player = other.GetComponent<PlayerController>();
        SmallCat cat = other.GetComponent<SmallCat>();
        if (player != null || cat != null){
            if (player == null){
            player = other.transform.parent.parent.GetComponent<PlayerController>();
            }
            if (vm.PriceNum < 3){
                player.ChangePressureOnce(value);
                vm.GetComponent<AudioEffect>().Price();
                vm.Bottle[vm.PriceNum].transform.GetChild (1).gameObject.SetActive(true);
                vm.Bottle[vm.PriceNum].transform.GetChild (0).gameObject.SetActive(false);
                if (vm.Pressure + value <vm.PressureMax){
                    vm.PriceNum = Mathf.Clamp(vm.PriceNum + 1,0,3);
                }
                GameObject.Find("ScoreManager").GetComponent<ScoreManager>().SendMessage("GetValueOfS","price");
                Destroy(gameObject);
            }
            else{
                Debug.Log("Bottle is already full");
            }
        }
        else{
            return;
        }
    }
}
