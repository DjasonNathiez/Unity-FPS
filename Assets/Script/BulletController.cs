using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject prefab;
    public int damage = 1;
    
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);

        Destroy(Instantiate(prefab, transform.position, transform.rotation));

        if (other.transform.GetComponent<Damageable>() != null)
        {
            other.transform.GetComponent<Damageable>().TakeDamage(damage);
        }
    }
}
