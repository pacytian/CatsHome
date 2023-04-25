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
    Object trial;
    
    void Start()
    {
        vm = GameObject.Find("ValueManager").GetComponent<VM>();
        trial = Resources.Load<GameObject>("Trial");
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
        array = new Object[] {fuel1,fuel2,fuel3,fuelmax,bonus,buff,cat,punish,price,explore};
        //GameObject Fuel1 = Instantiate(fuel1) as GameObject;
        InvokeRepeating("RandomBulidElement",0.0f,2.0f);
        InvokeRepeating("BulidSettledElement",10.0f,10.0f);
        InvokeRepeating("BulidTrialElement",36.0f,36.0f);
        buildtime = 0.0f;
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
    }

    void RandomBulidElement(){
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
        pref = Instantiate(trial) as GameObject;
        pref.transform.parent = this.transform;
        pref.transform.localPosition = new Vector3(0.0f,4.0f,-3.0f);
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
