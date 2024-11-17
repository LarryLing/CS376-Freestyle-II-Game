using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    static int zombieCount;

    public GameObject currentWeapon;

    public float currentHealth;

    public float maxHealth;

    public float movementSpeed;

    public int resistanceLevel = 0;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {

    }

    static void IncreaseZombieCount(int increaseCount)
    {
        zombieCount += increaseCount;
    }
    static void DecreaseZombieCount(int decreaseCount)
    {
        zombieCount -= decreaseCount;
    }

    void Attack()
    {

    }

    void TakeDamage(float baseDamage)
    {
        currentHealth -= (1 - (resistanceLevel * 0.2f)) * baseDamage;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
