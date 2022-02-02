//gesick
//proj 2 complete - proj 3 start

using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 

	{
		public Transform target;            
		public float smoothing = 5f;        
		
		Vector3 offset;                     
		void Start ()
		{
			
			offset = transform.position - target.position;
		}
		
		void FixedUpdate ()
		{
            if (target == null) return;  //keeps the system from crashing if player goes off screen
			
			Vector3 targetCamPos = target.position + offset;
			
		
			transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
		}
	}
