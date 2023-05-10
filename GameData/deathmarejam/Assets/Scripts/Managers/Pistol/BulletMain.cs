using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMain : MonoBehaviour
{
    public Transform firePoint;
    public GameObject capPrefab;
    public GameObject bulletPrefab;

    public static BulletMain Instance;

    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

    }

    public void ShootBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    
    public void DropCap()
    {
        Instantiate(capPrefab, firePoint.position, firePoint.rotation);
    }
}
