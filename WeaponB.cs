//gesick
//proj 2 complete - proj 3 start

using UnityEngine;
using System.Collections;

public class WeaponB : WeaponBase {
	public GameObject shot;
	public Transform shotSpawn,shotSpawnB;

	
	public override void shoot()
	{
		if(ammoCount>0)
		{
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
            Instantiate(shot, shotSpawnB.position, shotSpawnB.rotation);
            ammoCount--;
		}
	}
	
}
