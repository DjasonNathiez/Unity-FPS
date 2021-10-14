using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int currentHealth;
    public int damageTaken;

    public int maxHealth;
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(this.gameObject.name +" take damage");
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}
