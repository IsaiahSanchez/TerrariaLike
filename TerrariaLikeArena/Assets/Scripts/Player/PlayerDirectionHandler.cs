using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionHandler : MonoBehaviour
{
    private int direction = -1;

    private PlayerMovement myMovement;

    private void Start()
    {
        myMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        //check if exists
        if (myMovement != null)
        {
            //check if the direction has changed
            if (myMovement.movementAimDirection.x != direction)
            {
                if (myMovement.movementAimDirection.x != 0)
                {
                    direction = (int)myMovement.movementAimDirection.x;

                    if (direction == 1)
                    {
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
                    }
                    
                }
            }
        }


    }
}
