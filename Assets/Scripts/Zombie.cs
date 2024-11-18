using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Zombie : MonoBehaviour
{
    public GameObject currentWeapon;

    public AudioSource audioSource;

    public SpriteRenderer spriteRenderer;

    public GameController gameController;

    public Rigidbody2D rb;

    public CircleCollider2D circleCollider;

    private Transform playerTransform;

    public float currentHealth;

    public float maxHealth;

    public float movementSpeed;

    private float rotationSpeed;

    public float attackDamage;

    private float awarenessRadius;

    public int resistanceLevel;

    private bool chasingPlayer;

    public Vector2 directionToPlayer;

    public Vector2 targetDirection;

    void Awake()
    {
        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();

        gameController = FindObjectOfType<GameController>().GetComponent<GameController>();

        awarenessRadius = 30f;

        rotationSpeed = 400f;
    }

    void Start()
    {
        currentHealth = maxHealth;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector2 distanceFromPlayer = playerTransform.position - transform.position;
        directionToPlayer = distanceFromPlayer.normalized;

        chasingPlayer = distanceFromPlayer.magnitude <= awarenessRadius;
    }

    void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.GetComponent<Player>())
        {
            Player player = collider.gameObject.GetComponent<Player>();

            player.TakeDamage(attackDamage);
        }
    }

    private void UpdateTargetDirection()
    {
        if (chasingPlayer)
        {
            targetDirection = directionToPlayer;
        }
        else
        {
            targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        if (targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        rb.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        if (targetDirection == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = transform.up * movementSpeed;
        }
    }

    public void TakeDamage(float baseattackDamage)
    {
        audioSource.Play();

        currentHealth -= (1 - (resistanceLevel * 0.2f)) * baseattackDamage;

        rb.AddForce(transform.forward * -25f);

        if (currentHealth <= 0)
        {
            spriteRenderer.enabled = false;

            circleCollider.enabled = false;

            Destroy(this.gameObject, 0.5f);

            gameController.zombiesKilled += 1;
        }
    }
}
