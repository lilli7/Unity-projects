//gesick
//proj 2 complete - proj 3 start

using UnityEngine;
using System.Collections;

public abstract class WeaponBase : MonoBehaviour {

	public int rateOfFire;
	public int ammoCount;
	public bool active;
	public WeaponBase()
	{

	}
    public abstract void shoot();
	

	public int RateOfFire
	{
		get{ return rateOfFire;}
	}
	public  void reload(int x)
	{
		ammoCount+=x;
	}
}
