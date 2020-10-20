using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Vector2 movementAimDirection = new Vector2();
    [SerializeField] private float movementSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
    }

    public void setMovementVector(Vector2 directionToAim)
    {
        movementAimDirection = directionToAim;
    }

    private void handleMovement()
    {
        myBody.velocity = new Vector2(movementAimDirection.x * movementSpeed, myBody.velocity.y);
    }
}

