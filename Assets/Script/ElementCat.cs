using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementCat : MonoBehaviour
{
    float bgspeed = 0.1f;
    public Sprite[] cats;
    VM vm;
    
    void Start(){
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
        int i = Random.Range(0,8);
        GetComponent<SpriteRenderer>().sprite = cats[i];
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
            Destroy(other);
        }
        PlayerController player = other.GetComponent<PlayerController>();
        SmallCat cat = other.GetComponent<SmallCat>();
        if (player != null || cat != null){
            if (player == null){
            player = other.transform.parent.parent.GetComponent<PlayerController>();
            }
            player.SendMessage("GetValueOfB",true);
            player.transform.Find("SmallCat").GetComponent<SmallCatController>().ChangeCat(this.gameObject);
            Destroy(gameObject);
        }
        else{
            return;
        }
    } 
}
