using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : ReloadableWeaponBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    override
    protected void ShootInternal()
    {
        Debug.Log("Shooting Shotgun");
        wasteAmmo(3);
        Vector3 shootDirection = Quaternion.Euler(45, 0, 0) * transform.forward;
        Vector3 shootDirection2 = Quaternion.Euler(-45, 0, 0) * transform.forward;
        Vector3 shootDirection3 = Quaternion.Euler(0, 45, 0) * transform.forward;
        Vector4 shootDirection4 = Quaternion.Euler(0, -45, 0) * transform.forward;
        GameObject bullet1 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
        GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject bullet3 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject bullet4 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet1.GetComponent<Rigidbody>().AddForce(shootDirection * projectileSpeed);
        bullet2.GetComponent<Rigidbody>().AddForce(shootDirection2 * projectileSpeed);
        bullet3.GetComponent<Rigidbody>().AddForce(shootDirection3* projectileSpeed);
        bullet4.GetComponent<Rigidbody>().AddForce(shootDirection4 * projectileSpeed);
        Destroy(bullet1, 1);
        Destroy(bullet2, 1);
        Destroy(bullet3, 1);
        Destroy(bullet4, 1);
        
    }
}
