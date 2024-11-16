using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour, IMovingEntity
{
    public IWeapon currentWeapon
    {
        get
        {
            return currentWeapon;
        }
    }

    public float currentHealth
    {
        get
        {
            return currentHealth;
        }
    }

    public float maxHealth
    {
        get
        {
            return maxHealth;
        }
    }

    public float movementSpeed
    {
        get
        {
            return movementSpeed;
        }
    }

    public float resistance
    {
        get
        {
            return resistance;
        }
    }

    public float attackSpeed
    {
        get
        {
            return attackSpeed;
        }
    }

    static int zombieCount;

    int coinValue;

    void Start()
    {

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

    void IMovingEntity.Attack()
    {

    }

    void Die()
    {

    }
}
