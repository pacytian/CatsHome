using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTimer : MonoBehaviour
{
    VM vm;
    float timer;
    SpriteRenderer sp;
    float colora;
    void Start()
    {
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
        timer = vm.DeadDisappearTime;
        sp = GetComponent<SpriteRenderer>();
        colora = sp.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0){
            Destroy(gameObject);
        }        
        if (timer <= 0.5f){
            colora -= 2 * Time.deltaTime;
            sp.color = new Color(sp.color.r,sp.color.g,sp.color.b,colora);
        }
    }
}
