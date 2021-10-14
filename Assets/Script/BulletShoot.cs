using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public GameObject bulletPrefabs;
    private GameObject prefabInstance;
    public Transform canon;
    public Transform projectileGroup;
    public float bulletSpeed = 1f;
    public float reloadingAmount;
    public int munitionAmount;
    public int munitionMax;

    public TextMeshProUGUI munitionText;
    

    void Update()
    {
        //tir
        if (Input.GetMouseButtonDown(0) && munitionAmount > 0)
        {
            InstantiateBullet();
            
        }
    
        //reload
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(Reloading());
        }
        
        //les munitions ne peuvent pas être en dessous de 0
        if (munitionAmount < 0)
        {
            munitionAmount = 0;
        }


        munitionText.text = munitionAmount + "/" + munitionMax;
    }

    void InstantiateBullet()
    {
        //la bullet apparait
        prefabInstance = Instantiate(bulletPrefabs, canon.position, canon.rotation, projectileGroup);
        prefabInstance.GetComponent<Rigidbody>().AddForce(canon.forward * bulletSpeed);

        munitionAmount -= 1;
        
        Destroy(prefabInstance, 5);

        //la bullet part dans la direction que l'on veut

    }

    IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reloadingAmount);
        munitionAmount = munitionMax;
    }
}
