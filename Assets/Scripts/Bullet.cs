using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player player;

    public SpriteRenderer spriteRenderer;

    public AudioSource audioSource;

    void Awake()
    {
        player = FindObjectOfType<Player>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        GameObject go = collider.gameObject;

        if (go.GetComponent<Zombie>() != null)
        {
            player.GetCoins(15);
            audioSource.Play();
            go.GetComponent<Zombie>().TakeDamage(5.0f);
        }

        spriteRenderer.enabled = false;

        Destroy(gameObject, 0.5f);
    }
}
