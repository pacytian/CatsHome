using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashClose : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke ("close", 0.15f);
    }
    void close(){
        this.gameObject.SetActive(false);
    }
}
