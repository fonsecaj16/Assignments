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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * projectileSpeed);
        Destroy(bullet, 2);

    }
}
