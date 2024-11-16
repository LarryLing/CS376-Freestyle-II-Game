using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    float baseAttackSpeed { get; }
    float baseDamage { get; }

    void EquipWeapon();
    void DequipWeapon();
}
