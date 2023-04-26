using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTimer : MonoBehaviour
{
    VM vm;
    float timer;
    void Start()
    {
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
        timer = vm.DeadDisappearTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0){
            Destroy(gameObject);
        }
    }
}
