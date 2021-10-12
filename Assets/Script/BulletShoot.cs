using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public GameObject bulletPrefabs;

    public Transform bulletPoint;

    public float bulletSpeed = 1f;
    private Vector3 bulletDir;

    public float bulletDamage;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            InstantiateBullet();
        }
    }

    void InstantiateBullet()
    {
        //la bullet apparait
        GameObject bullet = Instantiate(bulletPrefabs, bulletPoint);
        bullet.GetComponent<Rigidbody>().AddForce(0, 0, transform.forward.z * bulletSpeed);
        //la bullet part dans la direction que l'on veut
        
    }
}
