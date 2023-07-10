using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundFront : MonoBehaviour
{
    VM vm;
    float bgfrontspeed = 0.1f;
    Renderer rend;
    public float y = 0;
    void Start()
    {
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
        rend = this.GetComponent<Renderer>();
    }

    
    void Update()
    {
        bgfrontspeed = vm.BGFrontSpeed * 6 / 5.04f;
        //float y = Mathf.Repeat(Time.time * bgfrontspeed,1);
        y = Mathf.Repeat(Time.deltaTime * bgfrontspeed + y,1);
        rend.material.mainTextureOffset = new Vector2(0,y);
    }
}
