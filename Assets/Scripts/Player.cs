using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject weaponInHand;

    public UIController uiController;

    public Rigidbody2D rb;

    public Camera mainCamera;

    public TMP_Text coinsText;

    public TMP_Text upgradesAvailableText;

    public RectTransform currentHealthBar;

    public UnityEvent OnDied;

    public UnityEvent OnDamaged;

    public float currentHealth = 20f;

    public float maxHealth = 20f;

    public float movementSpeed = 5f;

    public float resistance = 0f;

    public float damageBoost = 0f;

    public int coins = 0;

    public int upgradePoints = 6;

    public bool isInvincible;

    private Vector2 movementVector;

    private Vector2 mousePosition;

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
        if (!uiController.isUIOpen)
        {
            rb.MovePosition(rb.position + movementVector * movementSpeed * Time.fixedDeltaTime);

            Vector2 lookDirection = mousePosition - rb.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

            rb.rotation = angle;

            Transform cameraTransform = mainCamera.GetComponent<Transform>();
            cameraTransform.position = new Vector3(transform.position.x, transform.position.y, cameraTransform.position.z);
        }
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

    public void TakeDamage(float rawDamage)
    {
        if (currentHealth == 0)
        {
            return;
        }

        if (isInvincible)
        {
            return;
        }

        currentHealth -= rawDamage * (1f - resistance);

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateHealthBar();

        if (currentHealth == 0)
        {
            OnDied.Invoke();
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void UpdateHealthBar()
    {
        currentHealthBar.localScale = new Vector3(currentHealth / maxHealth, currentHealthBar.localScale.y, currentHealthBar.localScale.z);
    }

    public void StartInvincibility(float duration)
    {
        StartCoroutine(InvincibilityCoroutine(duration));
    }

    private IEnumerator InvincibilityCoroutine(float duration)
    {
        isInvincible = true;

        yield return new WaitForSeconds(duration);

        isInvincible = false;
    }
}
