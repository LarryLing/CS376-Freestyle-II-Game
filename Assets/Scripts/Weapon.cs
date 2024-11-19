using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour
{
    public Player player;

    public Transform firePoint;

    public Transform gunHandle;

    public Transform playerWeaponHand;

    public GameObject bulletPrefab;

    public AudioSource audioSource;

    public AudioClip fireSoundEffect;

    public AudioClip reloadSoundEffect;

    public UIController uiController;

    public int cost;

    public int magazineSize;

    public int bulletsLeft;

    private float equipRadius = 10f;

    public float bulletForce;

    public float delayBetweenShots;

    public float lastFireTime;

    public float reloadDuration;

    public float lastReloadTime;

    public float damagePerBullet;

    public float burstDelay = 0.1f;

    public bool isEquippedByPlayer;

    public bool isReloading;

    public bool isBurst;

    public bool isShotgun;

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
        if (isEquippedByPlayer && Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        if (isReloading)
        {
            float timeSinceLastReload = Time.time - lastReloadTime;

            if (timeSinceLastReload >= reloadDuration)
            {
                bulletsLeft = magazineSize;

                isReloading = false;

                magazineText.text = bulletsLeft + " / " + magazineSize;
            }
        }
        else
        {
            if (Input.GetMouseButton(1) && isEquippedByPlayer)
            {
                float timeSinceLastFire = Time.time - lastFireTime;

                if (timeSinceLastFire >= delayBetweenShots)
                {
                    FireBullet();

                    lastFireTime = Time.time;
                }
            }
        }
    }

    public void OnPointerUpDelegate(PointerEventData data)
    {
        if (!isEquippedByPlayer && PlayerCanPickUpWeapon() && (data.button == PointerEventData.InputButton.Left))
        {
            Equip();
        }
    }

    public void Equip()
    {
        if (player.coins < cost)
        {
            uiController.DisplayWarningText("You need " + (cost - player.coins) + " more coins!");

            return;
        }

        if (purchasedByPlayer || player.coins >= cost)
        {
            if (player.weaponInHand == null)
            {
                player.weaponInHand = this.gameObject;
            }
            else if (player.weaponInHand != this.gameObject)
            {
                player.weaponInHand.GetComponent<Weapon>().Dequip();

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

            gunHandle.position = playerWeaponHand.position;
        }
    }

    public void Dequip()
    {
        transform.SetParent(null, false);

        isEquippedByPlayer = false;

        gunHandle.position = player.GetComponent<Transform>().position;
    }
    void FireBullet()
    {
        if (isBurst)
        {
            StartCoroutine(FireBurst());
            StopCoroutine(FireBurst());

            return;
        }
        else if (isShotgun)
        {
            FireShell();
        }
        else
        {
            FireSingle(firePoint.rotation);
        }

        if (bulletsLeft == 0)
        {
            Reload();
        }
    }

    void FireSingle(Quaternion firePointRotation)
    {
        audioSource.PlayOneShot(fireSoundEffect);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePointRotation);

        bullet.GetComponent<Bullet>().bulletDamage = damagePerBullet * (1f + player.damageBoost);

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(bullet.transform.up * bulletForce, ForceMode2D.Impulse);

        bulletsLeft -= 1;

        magazineText.text = bulletsLeft + " / " + magazineSize;
    }

    IEnumerator FireBurst()
    {
        for (int i = 0; i < 3; i++)
        {
            FireSingle(firePoint.rotation);

            yield return new WaitForSeconds(burstDelay);

            if (bulletsLeft == 0)
            {
                Reload();
            }
        }
    }
    void FireShell()
    {
        FireSingle(firePoint.rotation);
        FireSingle(firePoint.rotation * Quaternion.AngleAxis(15f, firePoint.forward));
        FireSingle(firePoint.rotation * Quaternion.AngleAxis(-15f, firePoint.forward));
    }

    void Reload()
    {
        magazineText.text = "Reloading...";

        isReloading = true;

        lastReloadTime = Time.time;

        audioSource.PlayOneShot(reloadSoundEffect);
    }

    private bool PlayerCanPickUpWeapon()
    {
        return equipRadius >= Vector2.Distance(transform.position, player.transform.position);
    }
}
