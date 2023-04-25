using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementHoriMove : MonoBehaviour
{
    float bgspeed = 0.1f;
    float horispeed;
    bool ismovingright;
    VM vm;
    void Start()
    {
         vm = GameObject.Find("ValueManager").GetComponent<VM>();
         horispeed = vm.HorizontalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        bgspeed = vm.BGFrontSpeed;
        //Debug.Log(Mathf.Clamp(transform.position.x, -1.2f, 1.2f));
        if (ismovingright){
            transform.Translate(Vector3.right * Time.deltaTime * horispeed * 6);
            if (transform.position.x >= 1.2f){
                ismovingright = false;
            }
        }
        else{
            transform.Translate(Vector3.left * Time.deltaTime * horispeed * 6);
            if (transform.position.x <= -1.2f){
                ismovingright = true;
            }
        }
    }
}
