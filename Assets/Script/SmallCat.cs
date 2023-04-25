using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCat : MonoBehaviour
{
    Transform center;
    float dis =0.5f;
    float progress = 0;
    VM vm;
    float rotatespeed;
    
    // Start is called before the first frame update
    void Start()
    {
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
        center = this.transform.parent.parent;
        rotatespeed = vm.RotateSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //rotatespeed = vm.RotateSpeed;
        progress += Time.deltaTime * rotatespeed;
        if(progress >= 360){
            progress -= 360;
        }
        float x1 = center.position.x + dis * Mathf.Cos(progress);
        float y1 = center.position.y + dis * Mathf.Sin(progress);
        this.transform.position = new Vector3(x1,y1,-5);
    }
}
