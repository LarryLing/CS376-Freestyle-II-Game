using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public Player player;

    public GameObject speedBoostCanvas;
    public GameObject extraResistanceCanvas;
    public GameObject extraHealthCanvas;
    public GameObject damageBoostCanvas;

    public TMP_Text speedBoostCost;
    public TMP_Text extraResistanceCost;
    public TMP_Text extraHealthCost;
    public TMP_Text damageBoostCost;

    public TMP_Text speedBoostCurrentLevel;
    public TMP_Text extraResistanceCurrentLevel;
    public TMP_Text extraHealthCurrentLevel;
    public TMP_Text damageBoostCurrentLevel;

    public GameObject warningTextObject;
    public TMP_Text warningText;

    public float warningDuration = 2f;

    public float timeUntilWarningClose;

    void Update()
    {
        if (Time.time >= timeUntilWarningClose)
        {
            warningTextObject.SetActive(false);
        }
    }

    public void OpenPrompt(string name, int cost, int currentLevel)
    {
        if (name == "SpeedBoost")
        {
            speedBoostCost.text = "Cost: " + cost;

            speedBoostCurrentLevel.text = "Current Level: " + currentLevel;

            speedBoostCanvas.SetActive(true);
        }
        else if (name == "ExtraResistance")
        {
            extraResistanceCost.text = "Cost: " + cost;

            extraResistanceCurrentLevel.text = "Current Level: " + currentLevel;

            extraResistanceCanvas.SetActive(true);
        }
        else if (name == "ExtraHealth")
        {
            extraHealthCost.text = "Cost: " + cost;

            extraHealthCurrentLevel.text = "Current Level: " + currentLevel;

            extraHealthCanvas.SetActive(true);
        }
        else if (name == "DamageBoost")
        {
            damageBoostCost.text = "Cost: " + cost;

            damageBoostCurrentLevel.text = "Current Level: " + currentLevel;

            damageBoostCanvas.SetActive(true);
        }
    }

    public void ClosePrompt(string name)
    {
        if (name == "SpeedBoost")
        {
            speedBoostCanvas.SetActive(false);
        }
        else if (name == "ExtraResistance")
        {
            extraResistanceCanvas.SetActive(false);
        }
        else if (name == "ExtraHealth")
        {
            extraHealthCanvas.SetActive(false);
        }
        else if (name == "DamageBoost")
        {
            damageBoostCanvas.SetActive(false);
        }
    }

    public void DisplayWarningText(string message)
    {
        if (!warningTextObject.activeInHierarchy)
        {
            warningTextObject.SetActive(true);
        }

        timeUntilWarningClose = Time.time + warningDuration;

        warningText.text = message;
    }

    public void UpdateText(string name, int newCost, int newLevel)
    {
        if (name == "SpeedBoost")
        {
            speedBoostCost.text = "Cost: " + newCost;

            speedBoostCurrentLevel.text = "Current Level: " + newLevel;
        }
        else if (name == "ExtraResistance")
        {
            extraResistanceCost.text = "Cost: " + newCost;

            extraResistanceCurrentLevel.text = "Current Level: " + newLevel;
        }
        else if (name == "ExtraHealth")
        {
            extraHealthCost.text = "Cost: " + newCost;

            extraHealthCurrentLevel.text = "Current Level: " + newLevel;
        }
        else if (name == "DamageBoost")
        {
            damageBoostCost.text = "Cost: " + newCost;

            damageBoostCurrentLevel.text = "Current Level: " + newLevel;
        }
    }
}
