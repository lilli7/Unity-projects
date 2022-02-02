//gesick
//proj 2 complete - proj 3 start

using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// inventory class
/// </summary>
public class Inventory  {

    public List<WeaponBase> weps;
    private int wepSel;

    public Inventory()
    {
        weps = new List<WeaponBase>();
        wepSel = -1;
    }
    /// <summary>
    /// adds a weapon to inventory after disabling renderer and collider
    /// </summary>
    /// <param name="w"></param>
    public void AddToInventory(WeaponBase w)
    {
        w.GetComponent<Renderer>().enabled = false;
        w.GetComponent<Collider>().enabled = false;
        w.active = false;
        weps.Add(w);
              
    }
    /// <summary>
    /// returns the next active weapon after deactivating the current weapon
    /// </summary>
    /// <returns></returns>
    public WeaponBase SelectWep()
    {
        if (weps.Count > 0)
        {
            if (wepSel != -1)
            {
                weps[wepSel].active = false;
                weps[wepSel].GetComponent<Renderer>().enabled = false;
             }

            wepSel++;
            if (wepSel >= weps.Count)
                wepSel = 0;

            weps[wepSel].active = true;
            weps[wepSel].GetComponent<Renderer>().enabled = true;
            return weps[wepSel];
        }
        else
            return null;
           }
    /// <summary>
    /// updates the positions of the active and inactive weapons
    /// </summary>
    /// <param name="t"></param>
    public void Positioning(Transform t)
    {
        for (int q = 0; q < weps.Count; q++)
        {
            weps[q].transform.position = t.position;
            weps[q].transform.rotation = t.rotation;
        }
           }
    /// <summary>
    /// adds ammo for each collected weapon
    /// </summary>
    public void PowerUp()
    {
        foreach (WeaponBase wb in weps)
        {
            wb.ammoCount += 20;
         }
    }
    
}
