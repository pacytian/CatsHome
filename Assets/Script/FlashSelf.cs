using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashSelf : MonoBehaviour
{
    bool iscolora;
    SpriteRenderer sp;
    float flashtimer = 4.5f;
    void Start()
    {
        sp = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        flashtimer -= Time.deltaTime;
        float remainder = flashtimer % 0.9f;
		sp.enabled = remainder > 0.3f;
        if (flashtimer < 0){
            flashtimer = 4.5f;
            gameObject.SetActive(false);
        }
    }
}
