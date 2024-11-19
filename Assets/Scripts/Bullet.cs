using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player player;

    public float bulletDamage;

    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        GameObject go = collider.gameObject;

        if (go.GetComponent<Zombie>() != null)
        {
            player.GetCoins(15);

            go.GetComponent<Zombie>().TakeDamage(bulletDamage);
        }

        if (go.GetComponent<Bullet>() != null)
        {
            return;
        }

        Destroy(gameObject);
    }
}
