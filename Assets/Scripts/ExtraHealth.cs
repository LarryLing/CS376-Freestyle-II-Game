using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraHealth : MonoBehaviour
{
    public Player player;

    public GameController gameController;

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
        gameController.OpenPrompt(this.gameObject.name, cost, currentLevel);
    }

    public void IncreasePlayerMaxHealth()
    {
        if (currentLevel >= maxLevel)
        {
            gameController.DisplayWarningText("Max level reached!");
        }
        else if (player.coins < cost)
        {
            gameController.DisplayWarningText("Not enough coins!");
        }
        else if (player.upgradePoints < 0)
        {
            gameController.DisplayWarningText("Not enough upgrade points!");
        }
        else
        {
            player.SpendCoins(cost);

            currentLevel += 1;

            player.maxHealth = baseMaxHealth * (1.0f + (0.2f * currentLevel));

            player.currentHealth = player.maxHealth * healthRatio;

            cost += 150;

            player.DecrementUpgradesAvailable();

            gameController.UpdateText(this.gameObject.name, cost, currentLevel);
        }
    }

    public void DecreasePlayerMaxHealth()
    {
        if (currentLevel <= 0)
        {
            gameController.DisplayWarningText("Already at the minimum level!");
        }
        else
        {
            currentLevel -= 1;

            player.maxHealth = baseMaxHealth * (1.0f * (0.2f * currentLevel));

            if (player.currentHealth > player.maxHealth)
            {
                player.currentHealth = player.maxHealth;
            }

            cost -= 150;

            player.IncrementUpgradesAvailable();

            gameController.UpdateText(this.gameObject.name, cost, currentLevel);
        }
    }
}
