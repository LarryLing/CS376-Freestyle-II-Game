using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public Player player;
    public Transform firePoint;
    public Transform gunHandle;
    public Transform playerWeaponHand;
    public Transform gunStand;
    public GameObject bulletPrefab;

    public int cost;

    private float equipRadius = 6f;

    private float bulletForce = 20f;

    public float maxAttackTime;

    public float currentAttackTime;

    public float maxReloadTime;

    public float currentReloadTime;

    public bool canAttack;

    public bool isEquippedByPlayer;

    public bool isAutomatic;

    public bool hasInfiniteMagazine;

    public int magazineSize;

    public int bulletsRemainingInMagazine;

    void Start()
    {
        gameObject.SetActive(true);

        canAttack = false;

        isEquippedByPlayer = false;
    }

    void Update()
    {
        if (canAttack && isEquippedByPlayer)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();

                currentAttackTime = 0.0f;
                canAttack = false;
            }
        }
        else
        {
            if (currentAttackTime < maxAttackTime)
            {
                currentAttackTime += Time.deltaTime;
            }
            else
            {
                canAttack = true;
            }
        }
    }

    void OnMouseDown()
    {
        if (!isEquippedByPlayer && PlayerIsInRange())
        {
            Equip();
        }
    }

    public void Equip()
    {
        if (player.coins >= cost)
        {
            if (player.weaponInHand == null)
            {
                player.weaponInHand = this.gameObject;
            }
            if (player.weaponInHand != this.gameObject)
            {
                player.weaponInHand.GetComponent<RangedWeapon>().Dequip();

                player.weaponInHand = this.gameObject;
            }

            player.SpendCoins(cost);

            transform.SetParent(player.transform, false);

            isEquippedByPlayer = true;

            currentAttackTime = maxAttackTime;

            gunHandle.position = playerWeaponHand.position;
        }
    }

    public void Dequip()
    {
        transform.SetParent(null, false);

        isEquippedByPlayer = false;

        currentAttackTime = 0;

        gunHandle.position = new Vector2(0, 0);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    private bool PlayerIsInRange()
    {
        return equipRadius >= Vector2.Distance(transform.position, player.transform.position);
    }
}
