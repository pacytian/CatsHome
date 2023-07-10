using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FuelType{
        Fuel1,
        Fuel2,
        Fuel3,
        Fuel4,
        FuelMax,
    }

public class ElementFuel : MonoBehaviour
{
    float value;
    public FuelType fueltype;
    float bgspeed = 0.1f;
    VM vm;
    
    void Start(){
       vm = GameObject.Find("ValueManager").GetComponent<VM>();
       switch(fueltype){
            case FuelType.Fuel1:
            if (vm.CatBreed == 6){
                value = -40;
            }
            else{
                value = -20;
            }
                break;
            case FuelType.Fuel2:
                value = -40;
                break;
            case FuelType.Fuel3:
                value = -60;
                break;
            case FuelType.Fuel4:
                value = +50;
                break;
            case FuelType.FuelMax:
                value = -100;
                break;
        } 
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
            Destroy(gameObject);
        }
        PlayerController player = other.GetComponent<PlayerController>();
        SmallCat cat = other.GetComponent<SmallCat>();
        if (player != null || cat != null){
            if (player == null){
                player = other.transform.parent.parent.GetComponent<PlayerController>();
            }
            player.ChangePressureOnce(value);
            vm.GetComponent<AudioEffect>().Normal();
            Destroy(gameObject);
        }
        else{
            return;
        }
            /*if (player.pressure > 0){
                player.ChangePressureOnce(value);
                vm.GetComponent<AudioEffect>().Normal();
                Destroy(gameObject);
            }
            else{
                Debug.Log("Pressure is already null");
            }*/
    }
}
