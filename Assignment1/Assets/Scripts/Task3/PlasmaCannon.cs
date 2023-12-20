using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlasmaCannon : MonoBehaviour, IWeapon
{
    [SerializeField]
    private int _projectileSpeed;
    public int projectileSpeed { get => _projectileSpeed; }
    [SerializeField]
    private GameObject _bulletPrefab;
    public int time;
    public TMP_Text coolDownText;
    private int remainingTime = 0;
    public Transform firePoint { get; set; }

    public GameObject bulletPrefab { get => _bulletPrefab; }
    private bool isOnCoolDown=false;
    public bool fireable { get; set; }

    private void Awake()
    {
        coolDownText.text = "Ready";
    }
    public void Shoot()
    {
        if(fireable)
        {
            if (!isOnCoolDown)
            {
                Debug.Log("Shooting Cannon");
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * projectileSpeed);
                Destroy(bullet, 10);
                StartCoroutine(CoolDown(time));
            }
        }
        
        

    }

    IEnumerator CoolDown(int time)
    {
        remainingTime = time;
        isOnCoolDown = true;

        while (remainingTime > 0)
        {
            ReadyText();
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }

        ReadyText();
        isOnCoolDown = false;
    }

    public void ReadyText()
    {
        if(fireable)
        {
            if (remainingTime == 0) coolDownText.text = "Ready";
            else coolDownText.text = remainingTime + "s";
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform.Find("material/FirePoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();

        }
    }
}
