using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    private Health myHealth;

    private void Start()
    {
        myHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myHealth != null)
        {
            if (myHealth.isDead)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
