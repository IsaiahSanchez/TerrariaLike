using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageBox : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Overlaped");
        other.GetComponentInParent<Health>().Damage(GetComponentInParent<Enemy>().Intelligence.touchDamageAmount);

        bool knockRight = true;
        if (transform.position.x > other.transform.position.x)
        {
            knockRight = false;
        }
        other.GetComponentInParent<PlayerMovement>().KnockBack(GetComponentInParent<Enemy>().Intelligence.KnockBackAmount, knockRight);
    }
}
