using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPunishment : MonoBehaviour
{
    public GameObject[] deadbody;
    GameObject cloneobj;
    void Start()
    {
         //InvokeRepeating("DeadAppear",0f,6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeadAppear(){
        for (int i = 1; i < 10 ; i++ ){
            GameObject dead = deadbody[Random.Range(0, deadbody.Length)];
            float x = Random.Range(-1.3f,1.3f);
            float y = Random.Range(-1.0f,2.3f);
            float z = Random.Range(0,360);
            bool flip = (Random.value > 0.5f);
            cloneobj = Instantiate(dead) as GameObject;
            cloneobj.transform.parent = transform;
            cloneobj.transform.position = new Vector3(x,y,-13);
            cloneobj.transform.eulerAngles = new Vector3(0,0,z);
            cloneobj.GetComponent<SpriteRenderer>().flipX = flip;
            cloneobj.SetActive(true);
        }
    }
}
