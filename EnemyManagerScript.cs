//gesick
//proj 2 complete - proj 3 start

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyManagerScript : MonoBehaviour {


    public EnemyBase[] enemyObjects;
    public static List<EnemyBase> eList=new List<EnemyBase>();
    public playerControl player;
    public Vector3 spawnValues;
    public int numEnemy;
    //elist will have size of 2 x numEnemy to start
    DDA_Controller dda;
    void Start()
    {
        GameObject g = GameObject.Find("Main Camera");
        dda = g.GetComponent<DDA_Controller>();

       Spawn();
    }
    /// <summary>
    /// controls the move and attack of the enemy
    /// </summary>
    void Update()
    {
        if (DestroyByContact.dead)
            return;
        if (player == null)
            return;
        Transform playerPos = player.transform;
        float spMod = dda.SpeedModifier;
        
        foreach (EnemyBase e in eList)
        {
            if (e != null)
            {
                e.Move(eList, playerPos,spMod);

                e.attack();
            }

        }
    }
    /// <summary>
    /// spawns the enemy
    /// </summary>
    void Spawn()
    { 
        Quaternion spawnRotation = Quaternion.identity;
        for (int i = 0; i < numEnemy / 2; i++)
        {
             Vector3 spawnPosition = new Vector3(Random.Range(250-spawnValues.x, 250+spawnValues.x), spawnValues.y, Random.Range(250-spawnValues.z, 250+spawnValues.z));
             eList.Add((EnemySub1)Instantiate(enemyObjects[0], spawnPosition, spawnRotation));
        }
        for (int i = 0; i < numEnemy ; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(250-spawnValues.x, 250+spawnValues.x), spawnValues.y, Random.Range(250-spawnValues.z, 250+spawnValues.z));
             eList.Add((EnemySub2)Instantiate(enemyObjects[1], spawnPosition, spawnRotation));
        }
        for (int i = 0; i < numEnemy / 2; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(250-spawnValues.x, 250+spawnValues.x), spawnValues.y+.5f, Random.Range(250-spawnValues.z, 250+spawnValues.z));
             eList.Add((EnemySub3)Instantiate(enemyObjects[2], spawnPosition, spawnRotation));
        }
    }


}

