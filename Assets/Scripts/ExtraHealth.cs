using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExtraHealth : MonoBehaviour
{
    public Player player;

    public UIController uiController;

    public float baseMaxHealth;

    public float healthRatio;

    public int cost;

    public int currentLevel = 0;

    public int maxLevel = 3;

    void Start()
    {
        baseMaxHealth = player.maxHealth;

        healthRatio = player.currentHealth / player.maxHealth;

        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener((data) => { OnPointerUpDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    public void OnPointerUpDelegate(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Left)
        {
            uiController.OpenPrompt(this.gameObject.name, cost, currentLevel);
        }
    }

    public void IncreasePlayerMaxHealth()
    {
        if (currentLevel >= maxLevel)
        {
            uiController.DisplayWarningText("Max level reached!");
        }
        else if (player.coins < cost)
        {
            uiController.DisplayWarningText("Not enough coins!");
        }
        else if (player.upgradePoints < 0)
        {
            uiController.DisplayWarningText("Not enough upgrade points!");
        }
        else
        {
            player.SpendCoins(cost);

            currentLevel += 1;

            player.maxHealth = baseMaxHealth * (1.0f + (0.2f * currentLevel));

            player.currentHealth = player.maxHealth * healthRatio;

            cost += 150;

            player.DecrementUpgradesAvailable();

            uiController.UpdateText(this.gameObject.name, cost, currentLevel);
        }
    }

    public void DecreasePlayerMaxHealth()
    {
        if (currentLevel <= 0)
        {
            uiController.DisplayWarningText("Cannot downgrade further!");
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

            uiController.UpdateText(this.gameObject.name, cost, currentLevel);
        }
    }
}
