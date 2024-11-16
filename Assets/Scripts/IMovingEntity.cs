using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovingEntity
{
    IWeapon currentWeapon {  get; }
    float currentHealth { get; }
    float maxHealth { get; }
    float movementSpeed { get; }
    float resistance { get; }
    float attackSpeed { get; }

    void Attack();
}
