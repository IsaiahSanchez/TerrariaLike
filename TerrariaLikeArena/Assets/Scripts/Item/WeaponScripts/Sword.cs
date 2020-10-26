using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sword")]
public class Sword : Weapon
{

    public override bool UsingUpdate(float totalTimeUsing)
    {
            if (!(totalTimeUsing > useSpeed))
            {

                float percentage = totalTimeUsing / useSpeed;
                float angle = Mathf.LerpAngle(-45f, 110f, percentage);
                currentlySpawnedWeapon.transform.localEulerAngles = new Vector3(0, 0, angle);
                return false;
            }
            else
            {
                stopAttacking();
                return true;
            }
    }

    public override void startAttacking(Transform playerTransform)
    {
        base.startAttacking(playerTransform);
        currentlySpawnedWeapon.transform.position = new Vector3(currentlySpawnedWeapon.transform.position.x, currentlySpawnedWeapon.transform.position.y - .3f, currentlySpawnedWeapon.transform.position.z);
    }


}
