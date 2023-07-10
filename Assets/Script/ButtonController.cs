using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject other;
    GameObject player;
    GameObject element;
    GameObject dead;
    GameObject background;
    GameObject scoremanager;
    public GameObject Adopt;
    VM vm;
    void Start()
    {
        dead = GameObject.Find("DeadController");
        element = GameObject.Find("Element");
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
        background = GameObject.Find("BackGround");
        player = GameObject.Find("Controller").transform.Find("Player").gameObject;
        scoremanager = GameObject.Find("ScoreManager").gameObject;
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

    public void ButtonEnd(){
        Time.timeScale = 1;

        scoremanager.GetComponent<ScoreManager>().ElementCount = new int[7];
        scoremanager.GetComponent<ScoreManager>().CurrentScore = 0;
        scoremanager.GetComponent<ScoreManager>().IsHS = 0;
        other.SetActive(false);

        SceneManager.LoadScene("MenuScene");

        //other.SetActive(true);
        //this.gameObject.SetActive(false);
    }

    public void ButtonRestart(){  
        
        background.transform.GetChild(0).gameObject.GetComponent<BackGroundFront>().y = 0;
        background.GetComponent<BackGroundRoll>().BGInit();

        player.transform.position = new Vector3(0,-1,-5);
        UnActiveAllChildrenSP(player.transform.Find("SmallCat").gameObject);
        
        scoremanager.GetComponent<ScoreManager>().ElementCount = new int[7];
        scoremanager.GetComponent<ScoreManager>().CurrentScore = 0;
        scoremanager.GetComponent<ScoreManager>().IsHS = 0;


        vm.PriceNum = 0;
        for (int i = 0; i < 3;i ++){
            vm.Bottle[i].transform.GetChild (0).gameObject.SetActive(true);
            vm.Bottle[i].transform.GetChild (1).gameObject.SetActive(false);
        }
        vm.transform.GetChild(3).gameObject.GetComponent<FlashSelf>().flashtimer = 2.0f;
        vm.transform.GetChild(3).gameObject.SetActive(false);

        RemoveAllChildren(element);
        RemoveAllChildren(dead);
        element.SetActive(false);
        element.SetActive(true);
        element.GetComponent<LevelRandom>().ispunish = false;
        element.GetComponent<LevelRandom>().BuildPause();
        element.GetComponent<LevelRandom>().BulidElement();
        player.GetComponent<PlayerController>().Init();
        
        player.transform.parent.GetComponent<IsGameOver>().isgameover = false;
        Adopt.SetActive(true);
        //Time.timeScale = 1;
        other.SetActive(true);
        this.transform.parent.gameObject.SetActive(false);
        //Debug.Log(Time.timeScale);
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
    void UnActiveAllChildrenSP(GameObject parent)
        {
            Transform transform;
            for(int i = 0;i < parent.transform.childCount; i++)
            {
                transform = parent.transform.GetChild(i);
                transform.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }    
}
