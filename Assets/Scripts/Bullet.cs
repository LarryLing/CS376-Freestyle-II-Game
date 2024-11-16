using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collider)
    {
        GameObject go = collider.gameObject;

        if (go.GetComponent<Zombie>() != null)
        {
            gameObject.SendMessage("GetCoins", go.GetComponent<Zombie>().coinValue);
        }

        Destroy(gameObject);
    }
}
