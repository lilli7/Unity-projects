//gesick
//proj 2 complete - proj 3 start

using UnityEngine;
using System.Collections;

public class WeaponA : WeaponBase {
	public GameObject shot;
	public Transform shotSpawn,shotSpawnB, shotSpawnC;
	
	public override void shoot()
	{
		if(ammoCount>0)
		{
		           
					Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
					Instantiate (shot, shotSpawnB.position, shotSpawnB.rotation);
					Instantiate (shot, shotSpawnC.position, shotSpawnC.rotation);
			ammoCount-=3;
	}
	}

}
