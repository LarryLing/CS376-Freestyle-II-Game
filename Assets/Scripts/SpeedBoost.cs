using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public Player player;

    public GameController gameController;

    public float baseMovementSpeed;

    public int cost;

    public int currentLevel = 0;

    public int maxLevel = 3;

    void Start() {
        baseMovementSpeed = player.movementSpeed;
    }

    void OnMouseDown()
    {
        gameController.OpenPrompt(this.gameObject.name, cost, currentLevel);
    }

    public void IncreasePlayerMovementSpeed()
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

            player.movementSpeed = baseMovementSpeed * (1.0f + (0.2f * currentLevel));

            cost += 150;

            player.DecrementUpgradesAvailable();

            gameController.UpdateText(this.gameObject.name, cost, currentLevel);
        }
    }

    public void DecreasePlayerMovementSpeed()
    {
        if (currentLevel <= 0)
        {
            gameController.DisplayWarningText("Already at the minimum level!");
        }
        else
        {
            currentLevel -= 1;

            player.movementSpeed = baseMovementSpeed * (1.0f * (0.2f * currentLevel));

            cost -= 150;

            player.IncrementUpgradesAvailable();

            gameController.ClosePrompt(this.gameObject.name);

            gameController.UpdateText(this.gameObject.name, cost, currentLevel);
        }
    }
}