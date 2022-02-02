//gesick
//proj 2 complete - proj 3 start
using UnityEngine;
using System.Collections;

public class BoundaryDestroy : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
	}
}
