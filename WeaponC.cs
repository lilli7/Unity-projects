//gesick
//proj 2 complete - proj 3 start

using UnityEngine;
using System.Collections;

public class WeaponC : WeaponBase {
	public GameObject shotB;
	public Transform shotSpawn;
	

	public override void shoot()
	{
		if(ammoCount>0)
		{
			Instantiate (shotB, shotSpawn.position, shotSpawn.rotation);
			ammoCount--;
		}
	}
	
}
