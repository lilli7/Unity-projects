//gesick
//proj 2 complete - proj 3 start

using UnityEngine;
using System.Collections.Generic;

public class EnemySub1 : EnemyBase
{
    protected UnityEngine.AI.NavMeshAgent agent;
    void Start ()
    {
		timing = 0;
		fireDelay = 10;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = playerPosition;
        speed = agent.speed;
	}

    public override void Move(List<EnemyBase> elist, Transform playerPos,float spMod)
	{
        
            
         playerPosition = playerPos.position;
        agent.destination = playerPosition;
        agent.speed = speed * .5f*spMod;
       
		
	}
	public override void attack ()
	{
        timing += Time.deltaTime;
        if (timing > fireDelay)
        {
            timing = 0;


            if (Vector3.Distance(agent.transform.position, playerPosition) < 100)
            {
                Instantiate(shot, e1shotSpawn.position, e1shotSpawn.rotation);
                Instantiate(shot, e1shotSpawn2.position, e1shotSpawn2.rotation);
            }
        }
	}
}
