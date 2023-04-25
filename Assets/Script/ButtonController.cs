using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject other;
    GameObject player;
    GameObject element;
    void Start()
    {
        //GetComponent<Button>().onClick.AddListener(ButtonClick);
    }

    void Update()
    {
        
    }

    public void ButtonPause(){
        Time.timeScale = 0;
        other.SetActive(true);
        this.gameObject.SetActive(false);
        //Debug.Log("A");
    }

    public void ButtonContinue(){
        Time.timeScale = 1;
        other.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ButtonRestart(){
        player = GameObject.Find("Controller").transform.Find("Player").gameObject;
        player.transform.position = new Vector3(0,-1.489f,-5);
        UnActiveAllChildren(player.transform.Find("SmallCat").gameObject);
        element = GameObject.Find("Element");
        RemoveAllChildren(element);
        player.GetComponent<PlayerController>().Init();
        player.transform.parent.GetComponent<IsGameOver>().isgameover = false;
        Time.timeScale = 1;
        other.SetActive(true);
        this.transform.parent.gameObject.SetActive(false);
        Debug.Log(Time.timeScale);
    }

    void RemoveAllChildren(GameObject parent)
        {
            Transform transform;
            for(int i = 0;i < parent.transform.childCount; i++)
            {
                transform = parent.transform.GetChild(i);
                GameObject.Destroy(transform.gameObject);
            }
        }
    void UnActiveAllChildren(GameObject parent)
        {
            Transform transform;
            for(int i = 0;i < parent.transform.childCount; i++)
            {
                transform = parent.transform.GetChild(i);
                transform.gameObject.SetActive(false);
            }
        }    
}
