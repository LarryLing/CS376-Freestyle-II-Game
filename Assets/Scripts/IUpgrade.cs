using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgrade
{
    int cost {  get; }
    float traitMultiplierValue { get; }

    bool AddToUpgradesList();
    void IncreasePlayerTraitValue();
    void ResetPlayerTraitValue();
}
