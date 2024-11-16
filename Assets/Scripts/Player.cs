using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMovingEntity
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

    int coins;

    List<IUpgrade> upgrades;

    void Start()
    {

    }

    void Update()
    {

    }

    void IMovingEntity.Attack()
    {

    }

    private void TakeDamage(int damageTaken)
    {

    }

    private void Heal(int amountHealed)
    {

    }
}
