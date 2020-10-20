using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    [SerializeField] private GameObject weaponPrefab;

    [SerializeField] protected float attackSpeed = 1f;
    [SerializeField] protected float damage = 1f;
    
    protected bool isAttacking = false;
    protected float currentTime = 0f;

    protected GameObject currentlySpawnedWeapon;

    private void OnEnable()
    {
        stopAttacking();
    }

    public override void LeftUse()
    {
        if (isAttacking == false)
        {
            startAttacking();
        }
    }

    public override void RightUse()
    {

    }

    public override void ItemUpdate(float timeSinceLastFrame)
    {
        if (isAttacking)
        {
            currentTime += timeSinceLastFrame;
            if (currentTime > attackSpeed)
            {

                stopAttacking();
            }
        }
    }


    public virtual void startAttacking()
    {
        //spawn weapon at location
        currentlySpawnedWeapon = Instantiate(weaponPrefab, PlayerTransform);
        WeaponHitbox hitbox = currentlySpawnedWeapon.AddComponent<WeaponHitbox>();
        hitbox.init(this);
        isAttacking = true;
    }

    public virtual void stopAttacking()
    {
        if (currentlySpawnedWeapon != null)
        {
            Destroy(currentlySpawnedWeapon);
        }
        isAttacking = false;
        currentTime = 0;
    }
}
