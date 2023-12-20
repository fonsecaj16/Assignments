using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class ReloadableWeaponBase : MonoBehaviour, IWeapon
{
    [SerializeField] private int initialAmmunition;
    private int _ammunition;
    public TMP_Text ammoText;
    [SerializeField]
    private int _bulletSpeed;
    public Transform firePoint { get; set; }
    public bool fireable { get; set; }
    [SerializeField]
    private GameObject _bulletPrefab;

    public GameObject bulletPrefab { get => _bulletPrefab; }
 

    public int projectileSpeed{ get => _bulletSpeed; }


    private void Awake()
    {
        Reload();
        firePoint = transform.Find("material/FirePoint");
    }
    public void Update()
    {
        if(fireable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();

            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }
        

    }
    public void Shoot()
    {
        if (_ammunition == 0) return;
        wasteAmmo(1);
        ShootInternal();
        ReadyText();
    }
    public void wasteAmmo(int ammount)
    {
        _ammunition -= ammount;
    }
    public void Reload()
    {
        _ammunition = initialAmmunition;
        ReadyText();
    }

    public void ReadyText()
    {
        ammoText.text = _ammunition + "/" + initialAmmunition;
    }
    protected abstract void ShootInternal();
}