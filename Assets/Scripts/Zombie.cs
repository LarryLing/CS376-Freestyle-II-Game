using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    static int zombieCount;

    public IWeapon currentWeapon;

    public float currentHealth;

    public float maxHealth;

    public float movementSpeed;

    public float resistance;

    public float attackSpeed;

    public int coinValue;

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

    void Die()
    {

    }
}
