using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//dda is attached to camera main

public class DDA_Controller : MonoBehaviour
{
    int enemy;
    EnemyManagerScript ems;
    float speedModifier;
    public float SpeedModifier
    {
        get { return speedModifier; }
    }
    void Start()
    {
        speedModifier = 1.0f;
        GameObject g = GameObject.Find("EnemyManager");
        ems = g.GetComponent<EnemyManagerScript>();
     
    }
    //elist will have size of 2 x numEnemy to start
    
    void Update()
    {
        float ratio = (float)EnemyManagerScript.eList.Count / (float)ems.numEnemy;
        if (ratio > 1.5)
            speedModifier = .7f;
        else if (ratio > 1.0)
            speedModifier = .8f;
        else if (ratio > .5)
            speedModifier = .9f;
        else
            speedModifier = 1;
    }
}
