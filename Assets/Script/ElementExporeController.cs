using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementExporeController : MonoBehaviour
{
    void Start()
    {
        int i = Random.Range(0,5);
        transform.GetChild (i).gameObject.GetComponent<ElementExplore>().isbigprize = true;
    }

    void Update()
    {
        if (GetComponentsInChildren<Transform>(true).Length <= 1){
            Destroy(gameObject);
        }
    }
}
