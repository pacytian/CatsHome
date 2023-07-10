using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour
{
    //public GameObject[] Digital;
    //public Transform[] tf;
    //public GameObject[] texture = new GameObject[5];
    public Text CScore;
    void Start()
    {
        Show(0);
    }

    public void Show(int Score){
        CScore.text = Score.ToString().PadLeft(6,'0');
    }
    /*public void Show(int Score)  //创建函数
    {
        for (int i = 0; i < 5; i++)
        {
            if (texture[i] != null)
            {
                Destroy(texture[i]);
            }
        }

        int G = Score % 10;
        int S = Score / 10 % 10;
        int B = Score / 100 % 10;
        int Q = Score / 1000 % 10;
        int W = Score / 10000 % 10;

        texture[0] = Instantiate(Digital[G], tf[0]);
        texture[1] = Instantiate(Digital[S], tf[1]);
        texture[2] = Instantiate(Digital[B], tf[2]);
        texture[3] = Instantiate(Digital[Q], tf[3]);
        texture[4] = Instantiate(Digital[W], tf[4]);

    }*/
}
