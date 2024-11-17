using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public Player player;

    public float baseMovementSpeed;

    public int cost;

    public int currentLevel = 0;

    public int maxLevel = 3;

    void Start() {
        baseMovementSpeed = player.movementSpeed;
    }

    void OnMouseDown()
    {
        if ((player.coins > cost) && (player.upgradePoints > 0))
        {
            IncreasePlayerMovementSpeed();
        }
    }

    private void IncreasePlayerMovementSpeed()
    {
        if (currentLevel < maxLevel)
        {
            player.SpendCoins(cost);

            currentLevel += 1;

            player.movementSpeed = baseMovementSpeed * (1.0f + (0.2f * currentLevel));

            cost += 150;

            player.upgradePoints -= 1;
        }
    }

    private void DecreasePlayerMovementSpeed()
    {
        if (currentLevel > 0)
        {
            player.SpendCoins(cost);

            currentLevel -= 1;

            player.movementSpeed = baseMovementSpeed * (1.0f * (0.2f * currentLevel));

            cost -= 150;

            player.upgradePoints += 1;
        }
    }
}