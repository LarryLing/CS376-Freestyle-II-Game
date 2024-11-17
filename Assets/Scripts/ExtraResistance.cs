using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraResistance : MonoBehaviour
{
    public Player player;

    public float baseResistance;

    public int cost;

    public int currentLevel = 0;

    public int maxLevel = 3;

    void Start()
    {
        baseResistance = player.resistance;
    }

    void OnMouseDown()
    {
        if ((player.coins > cost) && (player.upgradePoints > 0))
        {
            IncreasePlayerResistance();
        }
    }

    private void IncreasePlayerResistance()
    {
        if (currentLevel < maxLevel)
        {
            player.SpendCoins(cost);

            currentLevel += 1;

            player.resistance = 0.2f * currentLevel;

            cost += 150;

            player.upgradePoints -= 1;
        }
    }

    private void DecreasePlayerResistance()
    {
        if (currentLevel > 0)
        {
            currentLevel -= 1;

            player.resistance = 0.2f * currentLevel;

            cost -= 150;

            player.upgradePoints += 1;
        }
    }
}
