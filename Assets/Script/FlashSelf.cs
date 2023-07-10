using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashSelf : MonoBehaviour
{
    SpriteRenderer sp;
    public float flashtimer = 2.0f;
    void Start()
    {
        sp = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        flashtimer -= Time.deltaTime;
        float remainder = flashtimer % 0.2f;
		sp.enabled = remainder < 0.1f;
        if (flashtimer < 0){
            flashtimer = 2.0f;
            gameObject.SetActive(false);
        }
    }
}
