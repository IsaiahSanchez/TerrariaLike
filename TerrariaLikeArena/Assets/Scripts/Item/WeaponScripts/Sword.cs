using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sword")]
public class Sword : Weapon
{

    public override void ItemUpdate(float timeSinceLastFrame)
    {
        if (isAttacking == true)
        {
            currentTime += timeSinceLastFrame;
            if (!(currentTime > attackSpeed))
            {

                float percentage = currentTime / attackSpeed;
                float angle = Mathf.LerpAngle(-45f, 110f, percentage);
                currentlySpawnedWeapon.transform.localEulerAngles = new Vector3(0, 0, angle);
                Debug.Log(angle);
            }
            else
            {
                stopAttacking();
            }
        }
    }

    public override void startAttacking()
    {
        base.startAttacking();
        currentlySpawnedWeapon.transform.position = new Vector3(currentlySpawnedWeapon.transform.position.x, currentlySpawnedWeapon.transform.position.y - .3f, currentlySpawnedWeapon.transform.position.z);
    }


}
