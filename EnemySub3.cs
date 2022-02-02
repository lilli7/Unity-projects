//gesick
//proj 2 complete - proj 3 start

using UnityEngine;
using System.Collections.Generic;
using System;

public class EnemySub3 : EnemyBase {
    private Vector3 pos;
    private float rotation;
	void Start () {
		timing = 0;
		fireDelay = 3;
        pos = transform.position;
	}

    public override void Move(List<EnemyBase> elist, Transform playerPos, float spMod)
	{
        pos = transform.position;
        Vector3 diff = playerPos.position - pos;
        playerPosition = playerPos.position;
        Vector3 vel = Vector3.Normalize(diff);
        vel *= .02f*spMod;
        if ((vel.x != 0) || (vel.z != 0))
        {
            rotation = (float)Math.Atan2(vel.z, vel.x);
        }

        vel.y = 0f;
        transform.position = transform.position+ vel;

        rotation = rotation * 180 / 3.14f;
        if (rotation > 360)
            rotation -= 360;
        if (rotation < -360)
            rotation += 360;
        transform.rotation = Quaternion.Euler(0, rotation, 0);

		
	
	}
	public override void attack ()
	{
        timing += Time.deltaTime;
        if (timing > fireDelay)
        {
            timing = 0;

            if (Vector3.Distance(pos, playerPosition) < 60)
            {
                Instantiate(shot, e1shotSpawn.position, e1shotSpawn.rotation);
                Instantiate(shot, e1shotSpawn2.position, e1shotSpawn2.rotation);
                Instantiate(shot, e1shotSpawn3.position, e1shotSpawn3.rotation);
            }
        }
	}
}
