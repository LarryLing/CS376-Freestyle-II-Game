using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraResistance : MonoBehaviour, IUpgrade
{
    public int cost
    {
        get
        {
            return cost;
        }
    }
    public float traitMultiplierValue
    {
        get
        {
            return traitMultiplierValue;
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }

    bool IUpgrade.AddToUpgradesList()
    {
        return false;
    }
    void IUpgrade.IncreasePlayerTraitValue()
    {
        return;
    }
    void IUpgrade.ResetPlayerTraitValue()
    {
        return;
    }
}
