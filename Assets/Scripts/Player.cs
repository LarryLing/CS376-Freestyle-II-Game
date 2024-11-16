using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject weaponInHand;

    public float currentHealth = 20f;

    public float maxHealth = 20f;

    public float movementSpeed = 5f;

    public float resistance = 0f;

    public int coins = 0;

    public List<IUpgrade> upgrades;

    public Rigidbody2D rb;

    Vector2 movementVector;

    public Camera camera;

    Vector2 mousePosition;

    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementVector * movementSpeed * Time.fixedDeltaTime);

        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;

        Transform cameraTransform = camera.GetComponent<Transform>();
        cameraTransform.position = new Vector3(transform.position.x, transform.position.y, cameraTransform.position.z);
    }

    public void GetCoins(int coinValue)
    {
        coins += coinValue;
    }

    public void SpendCoins(int coinValue)
    {
        coins -= coinValue;
    }

    private void TakeDamage(int damageTaken)
    {

    }

    private void Heal(int amountHealed)
    {

    }
}
