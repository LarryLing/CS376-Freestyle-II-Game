using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Upgrade : MonoBehaviour
{
    public Player player;

    public UIController uiController;

    public AudioSource audioSource;

    public AudioClip upgradeSoundEffect;

    public AudioClip downgradeSoundEffect;

    public float basePlayerStat;

    public int cost;

    public int currentLevel = 0;

    public int maxLevel = 3;

    void Start() {
        if (name == "SpeedBoost")
        {
            basePlayerStat = player.movementSpeed;
        }
        else if (name == "ExtraResistance")
        {
            basePlayerStat = player.resistance;
        }
        else if (name == "ExtraHealth")
        {
            basePlayerStat = player.maxHealth;
        }
        else if (name == "DamageBoost")
        {
            basePlayerStat = player.damageBoost;
        }

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

    public void IncreasePlayerStats()
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
            audioSource.PlayOneShot(upgradeSoundEffect);

            player.SpendCoins(cost);

            currentLevel += 1;

            if (name == "SpeedBoost")
            {
                player.movementSpeed = basePlayerStat * (1.0f + (0.2f * currentLevel));
            }
            else if (name == "ExtraResistance")
            {
                player.resistance = 0.2f * currentLevel;
            }
            else if (name == "ExtraHealth")
            {
                player.maxHealth = basePlayerStat * (1.0f + (0.2f * currentLevel));
            }
            else if (name == "DamageBoost")
            {
                player.damageBoost = 0.2f * currentLevel;
            }

            cost += 150;

            player.DecrementUpgradesAvailable();

            uiController.UpdateText(this.gameObject.name, cost, currentLevel);
        }
    }

    public void DecreasePlayerStats()
    {
        if (currentLevel <= 0)
        {
            uiController.DisplayWarningText("Cannot downgrade further!");
        }
        else
        {
            audioSource.PlayOneShot(downgradeSoundEffect);

            currentLevel -= 1;

            if (name == "SpeedBoost")
            {
                player.movementSpeed = basePlayerStat * (1.0f + (0.2f * currentLevel));
            }
            else if (name == "ExtraResistance")
            {
                player.resistance = 0.2f * currentLevel;
            }
            else if (name == "ExtraHealth")
            {
                player.maxHealth = basePlayerStat * (1.0f + (0.2f * currentLevel));
            }
            else if (name == "DamageBoost")
            {
                player.damageBoost = 0.2f * currentLevel;
            }

            cost -= 150;

            player.IncrementUpgradesAvailable();

            uiController.UpdateText(this.gameObject.name, cost, currentLevel);
        }
    }
}