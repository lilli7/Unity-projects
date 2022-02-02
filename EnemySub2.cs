//gesick
//proj 2 complete - proj 3 start
using UnityEngine;
using System.Collections.Generic;
using System;

public class EnemySub2 : EnemyBase
{
    private Vector3 pos, vel;
    private float rotation;

    void Start()
    {
        timing = 0;
        fireDelay = 7;
    }

    public override void Move(List<EnemyBase> elist, Transform playerPos, float spMod)
    {
        pos = transform.position;
        playerPosition = playerPos.position;
        avoidNeighbors(elist);
        Vector3 diff = playerPos.position - pos;
        vel += Vector3.Normalize(diff) / 5000;

        if ((vel.x != 0) || (vel.z != 0))
        {
            rotation = (float)Math.Atan2(vel.z, vel.x);
        }

        pos += vel*.7f*spMod;
        pos.y = .3f;
        transform.position = pos;
        rotation = rotation * 180 / 3.14f;
        if (rotation > 360)
            rotation -= 360;
        if (rotation < 0)
            rotation += 360;
        transform.rotation = Quaternion.Euler(0, rotation, 0);
       

    }
    public override void attack()
    {
        timing += Time.deltaTime;
        if (timing > fireDelay)
        {
            timing = 0;

            if (Vector3.Distance(pos, playerPosition) < 80)
            {
                Instantiate(shot, e1shotSpawn.position, e1shotSpawn.rotation);
            }
        }
    }
    public void avoidNeighbors(List<EnemyBase> eList)
    {

        Vector3 avoidanceVector = Vector3.zero;
        int neighborCount = 0;
        foreach (EnemyBase e in eList)
        {
            if (e != null)
            {
                if (this != e)
                {
                    if (Vector3.Distance(pos, e.transform.position) < .8f)
                    {
                        neighborCount++;
                        avoidanceVector += pos - e.transform.position;
                    }
                }

                if (neighborCount > 0)
                    vel += (avoidanceVector / 1000);
            }
        }
    }
}
