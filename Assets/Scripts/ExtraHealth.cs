using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraHealth : MonoBehaviour
{
    public Player player;

    public float baseMaxHealth;

    public float healthRatio;

    public int cost;

    public int currentLevel = 0;

    public int maxLevel = 3;

    void Start()
    {
        baseMaxHealth = player.maxHealth;

        healthRatio = player.currentHealth / player.maxHealth;
    }

    void OnMouseDown()
    {
        if ((player.coins > cost) && (player.upgradePoints > 0))
        {
            IncreasePlayerMaxHealth();
        }
    }

    private void IncreasePlayerMaxHealth()
    {
        if (currentLevel < maxLevel)
        {
            player.SpendCoins(cost);

            currentLevel += 1;

            player.maxHealth = baseMaxHealth * (1.0f + (0.2f * currentLevel));

            player.currentHealth = player.maxHealth * healthRatio;

            cost += 150;

            player.upgradePoints -= 1;
        }
    }

    private void DecreasePlayerMaxHealth()
    {
        if (currentLevel > 0)
        {
            player.SpendCoins(cost);

            currentLevel -= 1;

            player.maxHealth = baseMaxHealth * (1.0f * (0.2f * currentLevel));

            if (player.currentHealth > player.maxHealth)
            {
                player.currentHealth = player.maxHealth;
            }

            cost -= 150;

            player.upgradePoints += 1;
        }
    }
}
