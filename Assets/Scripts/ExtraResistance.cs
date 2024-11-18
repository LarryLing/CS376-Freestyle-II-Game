using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExtraResistance : MonoBehaviour
{
    public Player player;

    public UIController uiController;

    public float baseResistance;

    public int cost;

    public int currentLevel = 0;

    public int maxLevel = 3;

    void Start()
    {
        baseResistance = player.resistance;

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

    public void IncreasePlayerResistance()
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
            uiController.DisplayWarningText("Cannot downgrade further!");
        }
        else
        {
            player.SpendCoins(cost);

            currentLevel += 1;

            player.resistance = 0.2f * currentLevel;

            cost += 150;

            player.DecrementUpgradesAvailable();

            uiController.UpdateText(this.gameObject.name, cost, currentLevel);
        }
    }

    public void DecreasePlayerResistance()
    {
        if (currentLevel <= 0)
        {
            uiController.DisplayWarningText("Already at the minimum level!");
        }
        else
        {
            player.resistance = 0.2f * currentLevel;

            cost -= 150;

            player.IncrementUpgradesAvailable();

            uiController.UpdateText(this.gameObject.name, cost, currentLevel);
        }
    }
}
