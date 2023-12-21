using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Direction
{
    up = 0,
    left = 1,
    down = 2,
    right = 3
}
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
        spawnBullet(0);
        spawnBullet(1);
        spawnBullet(2);
        spawnBullet(3);        
    }
    private void spawnBullet(int direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Vector3 shootDirection = Vector3.forward;
        switch (direction)
        {
            case 0:
                shootDirection = Quaternion.Euler(45, 0, 0) * transform.forward;
                break;
            case 1:
                shootDirection = Quaternion.Euler(-45, 0, 0) * transform.forward;
                break;
            case 2:
                shootDirection = Quaternion.Euler(0, 45, 0) * transform.forward;
                break;
            case 3:
                shootDirection = Quaternion.Euler(0, -45, 0) * transform.forward;
                break;

        }
        bullet.GetComponent<Rigidbody>().AddForce(shootDirection * projectileSpeed);
        Destroy(bullet, 1);
    }
}
