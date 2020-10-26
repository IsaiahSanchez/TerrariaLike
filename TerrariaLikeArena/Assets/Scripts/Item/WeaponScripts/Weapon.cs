using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    [SerializeField] private GameObject weaponPrefab;

    [SerializeField] protected float damage = 1f;


    public override GameObject UseItem(GameObject User)
    {
        return startAttacking(User.transform);
    }

    public override GameObject AlternateUseItem(GameObject User)
    {
        //right click use or thing
        return null;
    }

    public override bool UsingUpdate(float totalTimeUsing)
    {
        if (totalTimeUsing > useSpeed)
        {
            return false;
        }
        return true;
    }


    public virtual GameObject startAttacking(Transform playerTransform)
    {
        //spawn weapon at location
        GameObject currentlySpawnedWeapon = Instantiate(weaponPrefab, playerTransform);
        WeaponHitbox hitbox = currentlySpawnedWeapon.AddComponent<WeaponHitbox>();
        hitbox.init(this);
        return currentlySpawnedWeapon;
    }

}
