using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sword")]
public class Sword : Weapon
{

    public override bool UsingUpdate(PlayerHands hands)
    {
        if (hands != null)
        {
            float totalTimeUsing = hands.timePassedUsing;
            if (!(totalTimeUsing > useSpeed))
            {

                float percentage = totalTimeUsing / useSpeed;
                float angle = Mathf.Lerp(-65f, 145f, percentage);
                
                hands.spawnedItem.transform.localEulerAngles = new Vector3(0, 0, angle);
                return false;
            }
            else
            {
                hands.stopUsing();
                return true;
            }
        }
        else
        {
            return true;
        }
    }

    public override void startAttacking(Transform playerTransform, PlayerHands hands)
    {
        base.startAttacking(playerTransform, hands);
        hands.spawnedItem.transform.position = new Vector3(hands.spawnedItem.transform.position.x, hands.spawnedItem.transform.position.y - .3f, hands.spawnedItem.transform.position.z);
    }


}
