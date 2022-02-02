//gesick
//proj 2 complete - proj 3 start

using UnityEngine;
using System.Collections;

public class WepPickUp : MonoBehaviour
{
    public playerControl p;
    public WeaponBase myNewWep;
    private bool a1;
    void Start()
    {
        a1 = false;
      
    }

   
    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") && (this.tag == "rifle" || this.tag == "rpg" || this.tag == "multiLaunch"))
        {
         
            if (tag == "rifle")
            {
                if (!a1)
                {
                    p.inv.AddToInventory(myNewWep);
                    a1 = true;
                }
            }
            if (tag == "rpg")
            {
                if (!a1)
                {
                    p.inv.AddToInventory(myNewWep);
                     a1 = true;
                }
            }
            if (tag == "multiLaunch")
            {
                if (!a1)
                {
                    p.inv.AddToInventory(myNewWep);
                    a1 = true;
                }
            }
        
        }

    }
}
