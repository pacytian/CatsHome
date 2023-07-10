using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRandom : MonoBehaviour
{
    public float[] prob;
    float posx;
    Object[] array;
    GameObject pref;
    VM vm;
    float buildtime;
    float counttime;
    int i = 6;
    Object[] trial = new Object[3];
    bool isbuild = true;
    float punishtime = 0;
    public bool ispunish = false;
    
    void Start()
    {
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
        trial[0] = Resources.Load<GameObject>("Trial");
        trial[1] = Resources.Load<GameObject>("Trial1");
        trial[2] = Resources.Load<GameObject>("Trial2");
        Object fuel1 = Resources.Load<GameObject>("Fuel1");
        Object fuel2 = Resources.Load<GameObject>("Fuel2");
        Object fuel3 = Resources.Load<GameObject>("Fuel3");
        Object fuelmax = Resources.Load<GameObject>("FuelMax");
        Object bonus = Resources.Load<GameObject>("Bonus");
        Object buff = Resources.Load<GameObject>("Buff");
        Object cat = Resources.Load<GameObject>("Cat");
        Object punish = Resources.Load<GameObject>("Punish");
        Object price = Resources.Load<GameObject>("Price");
        Object explore = Resources.Load<GameObject>("Explores"); 
        Object fuel4 = Resources.Load<GameObject>("Fuel4");
        Object punishdoor = Resources.Load<GameObject>("PunishDoor");

        array = new Object[] {fuel1,fuel2,fuel3,fuelmax,bonus,buff,cat,punish,price,explore,fuel4,punishdoor};
        //GameObject Fuel1 = Instantiate(fuel1) as GameObject;
        buildtime = 0.0f;
        BulidElement();
    }
    public void BulidElement(){
        if (vm.CatBreed == 10){
            prob[7] = 8;
        }else{
            prob[7] = 5;
        }
        InvokeRepeating("RandomBulidElement",0.0f,3.0f);
        InvokeRepeating("BulidSettledElement",10.0f,25.0f);
        InvokeRepeating("BulidTrialElement",20.0f,33.0f);
        isbuild = true;
    }

    public void BuildPause(){
        CancelInvoke();
        isbuild = false;
    } 
    
    void Update()
    {
        //buildtime = vm.RandomBulidTime;
        counttime += Time.deltaTime;
        if (counttime > buildtime){
            RandomBulidElement();
            counttime = 0;
            buildtime = Random.Range(vm.RandomBulidTime - 0.25f,vm.RandomBulidTime + 0.25f);
        }

        if (ispunish){
            punishtime += Time.deltaTime;
            BulidPunishElement();
        }
    }

    void RandomBulidElement(){
        if (!isbuild){
            return;
        }
        posx = Random.Range(-1.15f,1.15f);
        pref = Instantiate(array[Choose(prob)]) as GameObject;
        pref.transform.parent = this.transform;
        pref.transform.localPosition = new Vector3(posx,3.0f,-3.0f);
    }

    void BulidSettledElement(){
        posx = Random.Range(-1.15f,1.15f);
        pref = Instantiate(array[i]) as GameObject;
        pref.transform.parent = this.transform;
        pref.transform.localPosition = new Vector3(posx,3.0f,-3.0f);
    }

    void BulidTrialElement(){
        pref = Instantiate(trial[Random.Range(0, 3)]) as GameObject;
        pref.transform.parent = this.transform;
        pref.transform.localPosition = new Vector3(0.0f,4.0f,-8.0f);
        ispunish = true;
    }

    void BulidPunishElement(){
        if (punishtime >= 0.8f){
            posx = Random.Range(-1.15f,1.15f);
            pref = Instantiate(array[11]) as GameObject;
            pref.transform.parent = this.transform;
            pref.transform.localPosition = new Vector3(posx,2.6f,-3.0f);
            //Debug.Log("BulidPunish");
            punishtime = 0;
        }
    }

    
    int Choose (float[] probs) {
        float total = 0;
        foreach (float elem in probs) {
            total += elem;
        }
        float randomPoint = Random.value * total;
        for (int i= 0; i < probs.Length; i++) {
            if (randomPoint < probs[i]) {
                return i;
            }
            else {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }
}
