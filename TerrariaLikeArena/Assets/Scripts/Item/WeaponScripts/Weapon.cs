using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    [SerializeField] private GameObject weaponPrefab;

    [SerializeField] public float damage = 1f;
    [SerializeField] public float knockBackAmount = 30f;


    public override void UseItem(PlayerHands hands)
    {
        startAttacking(hands.gameObject.transform, hands);
    }

    public override void AlternateUseItem(PlayerHands playerHands)
    {
        //right click use or thing

    }

    public override bool UsingUpdate(PlayerHands hands)
    {
        return true;
        //if (totalTimeUsing > useSpeed)
        //{
        //    return false;
        //}
        //return true;
    }


    public virtual void startAttacking(Transform playerTransform , PlayerHands hands)
    {
        //spawn weapon at location
        GameObject currentlySpawnedWeapon = Instantiate(weaponPrefab, playerTransform);
        currentlySpawnedWeapon.AddComponent<SpriteRenderer>();
        currentlySpawnedWeapon.GetComponent<SpriteRenderer>().sprite = itemGraphic;
        currentlySpawnedWeapon.AddComponent<PolygonCollider2D>();
        WeaponHitbox hitbox = currentlySpawnedWeapon.AddComponent<WeaponHitbox>();
        hitbox.init(this);
        currentlySpawnedWeapon.layer = 8;

        hands.spawnedItem = currentlySpawnedWeapon;
    }

}
