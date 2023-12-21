using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : ReloadableWeaponBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    override
    protected void ShootInternal()
    {
        Debug.Log("Shooting Sniper");
        SpawnBullet();

    }
}
