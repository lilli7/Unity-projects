//gesick
//proj 2 complete - proj 3 start
 
using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	private float speed=20;
	public float factor=1;
	void Start () 
	{
		GetComponent<Rigidbody>().velocity=transform.forward*speed*factor;
	}
	
}
