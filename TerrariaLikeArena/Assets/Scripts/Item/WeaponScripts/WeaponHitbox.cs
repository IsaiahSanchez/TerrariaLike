using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitbox : MonoBehaviour
{
    Weapon myWeapon;

    public void init(Weapon self)
    {
        myWeapon = self;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //get weapon info when doing damage to others
        collision.GetComponentInParent<Health>().Damage(myWeapon.damage);
        //apply status effects if applicable.
    }
}
