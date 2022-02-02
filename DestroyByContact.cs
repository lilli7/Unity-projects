//gesick
//proj 2 complete - proj 3 start
using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	private playerControl p;
    public static bool dead;

	void Start () {
        dead = false;
		GameObject playerControllerObject = GameObject.FindWithTag ("Player");
        if(playerControllerObject !=null)
		p = playerControllerObject.GetComponent <playerControl> ();
	}
	
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="Enemies"&& this.tag=="bolt")
		{
            EnemyBase ot = other.GetComponent<EnemyBase>(); //******
           EnemyManagerScript.eList.Remove(ot);
		Destroy(other.gameObject);
		Destroy(this.gameObject);
      
		}
		if(other.tag=="Background")
			Destroy(this.gameObject);
		if (this.tag == "enemyShot" && other.tag == "Player") {
			p.health-=20;
			Destroy (this.gameObject);
            dead = true;

		}
		if (this.tag == "powerUp" && other.tag == "Player")
        {
            p.inv.PowerUp();
          
            p.health += 100;
            Destroy(this.gameObject);
        }
		
	}
  
}
