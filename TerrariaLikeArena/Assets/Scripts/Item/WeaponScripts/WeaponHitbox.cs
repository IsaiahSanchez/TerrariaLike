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


        bool knockRight = true;
        if (transform.position.x > collision.transform.position.x)
        {
            knockRight = false;
        }
        collision.GetComponentInParent<Enemy>().KnockBack(myWeapon.knockBackAmount, knockRight);
        //apply status effects if applicable.
    }
}
