using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    static int zombieCount;

    public GameObject currentWeapon;

    public AudioSource audioSource;

    public SpriteRenderer spriteRenderer;

    public Rigidbody2D rb;

    public CircleCollider2D circleCollider;

    public float currentHealth;

    public float maxHealth;

    public float movementSpeed;

    public float damage;

    public float attackCooldown;

    public int resistanceLevel = 0;

    void Start()
    {
        currentHealth = maxHealth;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    static void IncreaseZombieCount(int increaseCount)
    {
        zombieCount += increaseCount;
    }
    static void DecreaseZombieCount(int decreaseCount)
    {
        zombieCount -= decreaseCount;
    }

    void Attack()
    {

    }

    public void TakeDamage(float baseDamage)
    {
        audioSource.Play();

        currentHealth -= (1 - (resistanceLevel * 0.2f)) * baseDamage;

        if (currentHealth <= 0)
        {
            spriteRenderer.enabled = false;

            circleCollider.enabled = false;

            Destroy(rb);

            Destroy(this.gameObject, 0.5f);
        }
    }
}
