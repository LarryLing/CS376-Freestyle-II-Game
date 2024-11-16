using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour, IWeapon
{
    public float baseAttackSpeed 
    { 
        get
        {
            return baseAttackSpeed;
        }
    }
    public float baseDamage
    {
        get
        {
            return baseDamage;
        }
    }

    public bool hasInfiniteMagazine;
    public int magazineSize;
    public float timeToReload;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void IWeapon.EquipWeapon()
    {

    }

    void IWeapon.DequipWeapon()
    {

    }

    void ReloadWeapon()
    {

    }
}
