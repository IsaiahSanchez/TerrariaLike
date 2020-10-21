using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerControls myControls;

    PlayerMovement myMovement;
    [SerializeField]PlayerHands myHands;


    private void OnEnable()
    {
        myMovement = GetComponent<PlayerMovement>();

        myControls = new PlayerControls();

        myControls.PlayerActions.Enable();
        myControls.PlayerActions.Movement.Enable();

        myControls.PlayerActions.LeftClick.performed += LeftClick;

        myControls.PlayerActions.RightClick.performed += RightClick;

        myControls.PlayerActions.Jump.performed += Jump;
    }


    private void LeftClick(InputAction.CallbackContext obj)
    {
        if (myHands != null)
        {
            myHands.LeftClick();
        }
    }

    private void RightClick(InputAction.CallbackContext obj)
    {
        if (myHands != null)
        {
            myHands.RightClick();
        }
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        myMovement.tryJump();
    }

    // Update is called once per frame
    void Update()
    {
        myMovement.setMovementVector(myControls.PlayerActions.Movement.ReadValue<Vector2>());
    }
}
