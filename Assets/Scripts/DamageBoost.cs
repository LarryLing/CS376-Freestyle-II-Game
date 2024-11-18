using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DamageBoost : MonoBehaviour
{
    public Player player;

    public UIController uiController;

    public float baseDamageBoost;

    public int cost;

    public int currentLevel = 0;

    public int maxLevel = 3;

    void Start() {
        baseDamageBoost = player.damageBoost;

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

    public void IncreasePlayerDamageBoost()
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

            player.damageBoost = 0.2f * currentLevel;

            cost += 150;

            player.DecrementUpgradesAvailable();

            uiController.UpdateText(this.gameObject.name, cost, currentLevel);
        }
    }

    public void DecreasePlayerDamageBoost()
    {
        if (currentLevel <= 0)
        {
            uiController.DisplayWarningText("Cannot downgrade further!");
        }
        else
        {
            currentLevel -= 1;

            player.damageBoost = 0.2f * currentLevel;

            cost -= 150;

            player.IncrementUpgradesAvailable();

            uiController.UpdateText(this.gameObject.name, cost, currentLevel);
        }
    }
}
