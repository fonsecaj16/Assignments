
using UnityEngine;

public interface IWeapon
{
    int projectileSpeed { get; }
    Transform firePoint { get; set; }
    GameObject bulletPrefab { get; }
    bool fireable { get; set; }
    void Shoot();
    void ReadyText();
}

