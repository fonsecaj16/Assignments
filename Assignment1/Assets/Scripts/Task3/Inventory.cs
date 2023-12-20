using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject> weapons = new List<GameObject>();
    public int currentWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform childTransform in transform)
        {
            // Add the child game object to the list
            weapons.Add(childTransform.gameObject);
        }
        weapons[currentWeapon].transform.Find("material").gameObject.SetActive(true);
        IWeapon weapon = weapons[currentWeapon].GetComponent<IWeapon>();
        weapon.fireable = true;
        weapon.ReadyText();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentWeapon += 1;
            if (currentWeapon >= weapons.Count)
            {
                currentWeapon = 0;

            }
            changeWeapon(currentWeapon);
        }

        for (int i = 1; i <= 9; i++)
        {
            KeyCode key = KeyCode.Alpha0 + i;

            CheckWeaponSwitch(key, i - 1);

        }
    }

        void CheckWeaponSwitch(KeyCode key, int weaponIndex)
    {
        if (Input.GetKeyDown(key))
        {
            currentWeapon = weaponIndex;
            if (currentWeapon >= weapons.Count) currentWeapon = 2;
                
            changeWeapon(currentWeapon);
        }
    }

    void changeWeapon(int weaponChange)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (i == currentWeapon)
            {
                weapons[currentWeapon].transform.Find("material").gameObject.SetActive(true);
                IWeapon weapon = weapons[currentWeapon].GetComponent<IWeapon>();
                weapon.fireable=true;
                weapon.ReadyText();


            }
            else {
                weapons[i].transform.Find("material").gameObject.SetActive(false);
                IWeapon weapon = weapons[i].GetComponent<IWeapon>();
                weapon.fireable = false ;
            }

        }
        
    }
}
