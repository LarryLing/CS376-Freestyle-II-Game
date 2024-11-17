using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject weaponInHand;

    public GameController gameController;

    public float currentHealth = 20f;

    public float maxHealth = 20f;

    public float movementSpeed = 5f;

    public float resistance = 0f;

    public float damageBoost = 0f;

    public int coins = 0;

    public int upgradePoints = 6;

    public Rigidbody2D rb;

    public Camera mainCamera;

    Vector2 movementVector;

    Vector2 mousePosition;

    public TMP_Text coinsText;

    public TMP_Text upgradesAvailableText;

    public RectTransform currentHealthBar;

    void Start()
    {
        coinsText.text = "Coins: " + coins;

        upgradesAvailableText.text = "Upgrades Available: " + upgradePoints;

        currentHealthBar.localScale = new Vector3(currentHealth / maxHealth, currentHealthBar.localScale.y, currentHealthBar.localScale.z);
    }

    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementVector * movementSpeed * Time.fixedDeltaTime);

        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;

        Transform cameraTransform = mainCamera.GetComponent<Transform>();
        cameraTransform.position = new Vector3(transform.position.x, transform.position.y, cameraTransform.position.z);
    }

    public void GetCoins(int coinValue)
    {
        coins += coinValue;
        coinsText.text = "Coins: " + coins;
    }

    public void SpendCoins(int coinValue)
    {
        coins -= coinValue;
        coinsText.text = "Coins: " + coins;
    }

    public void IncrementUpgradesAvailable()
    {
        if (upgradePoints < 6)
        {
            upgradePoints += 1;
            upgradesAvailableText.text = "Upgrades Available: " + upgradePoints;
        }
    }

    public void DecrementUpgradesAvailable()
    {
        if (upgradePoints > 0)
        {
            upgradePoints -= 1;
            upgradesAvailableText.text = "Upgrades Available: " + upgradePoints;
        }
    }

    private void TakeDamage(int rawDamage)
    {
        currentHealth -= rawDamage * (1f - resistance);
        currentHealthBar.localScale = new Vector3(currentHealth / maxHealth, currentHealthBar.localScale.y, currentHealthBar.localScale.z);
    }

    private void Heal(int amountHealed)
    {

    }
}
