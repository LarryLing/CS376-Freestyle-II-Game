using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class RangedWeapon : MonoBehaviour
{
    public Player player;
    public Transform firePoint;
    public Transform gunHandle;
    public Transform playerWeaponHand;
    public Transform gunStand;
    public GameObject bulletPrefab;

    public int cost;

    public int magazineSize;

    public int bulletsLeft;

    private float equipRadius = 6f;

    private float bulletForce = 20f;

    public float maxAttackTime;

    public float currentAttackTime;

    public float maxReloadTime;

    public float currentReloadTime;

    public float damage;

    public bool canFire;

    public bool isEquippedByPlayer;

    public bool isAutomatic;

    public bool purchasedByPlayer;

    public TMP_Text magazineText;

    void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener((data) => { OnPointerUpDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    void Update()
    {
        if (canFire && isEquippedByPlayer)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Shoot();

                currentAttackTime = 0.0f;
                canFire = false;
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
                canFire = true;
            }
        }
    }

    public void OnPointerUpDelegate(PointerEventData data)
    {
        if (!isEquippedByPlayer && PlayerIsInRange() && (data.button == PointerEventData.InputButton.Left))
        {
            Equip();
        }
    }

    public void Equip()
    {
        if (purchasedByPlayer || player.coins >= cost)
        {
            if (player.weaponInHand == null)
            {
                player.weaponInHand = this.gameObject;
            }
            else if (player.weaponInHand != this.gameObject)
            {
                player.weaponInHand.GetComponent<RangedWeapon>().Dequip();

                player.weaponInHand = this.gameObject;
            }

            if (!purchasedByPlayer)
            {
                player.SpendCoins(cost);

                purchasedByPlayer = true;
            }

            magazineText.text = bulletsLeft + " / " + magazineSize;

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

        gunHandle.position = player.GetComponent<Transform>().position;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        bulletsLeft -= 1;

        magazineText.text = bulletsLeft + " / " + magazineSize;

        if (bulletsLeft == 0)
        {
            canFire = false;
        }
    }

    private bool PlayerIsInRange()
    {
        return equipRadius >= Vector2.Distance(transform.position, player.transform.position);
    }
}
