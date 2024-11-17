using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoost : MonoBehaviour
{
    public Player player;

    public float baseDamageBoost;

    public int cost;

    public int currentLevel = 0;

    public int maxLevel = 3;

    void Start() {
        baseDamageBoost = player.damageBoost;
    }

    void OnMouseDown()
    {
        if ((player.coins > cost) && (player.upgradePoints > 0))
        {
            IncreasePlayerDamageBoost();
        }
    }

    private void IncreasePlayerDamageBoost()
    {
        if (currentLevel < maxLevel)
        {
            player.SpendCoins(cost);

            currentLevel += 1;

            player.damageBoost = 0.2f * currentLevel;

            cost += 150;

            player.upgradePoints -= 1;
        }
    }

    private void DecreasePlayerDamageBoost()
    {
        if (currentLevel > 0)
        {
            player.SpendCoins(cost);

            currentLevel -= 1;

            player.damageBoost = 0.2f * currentLevel;

            cost -= 150;

            player.upgradePoints += 1;
        }
    }
}
