using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;
    [HideInInspector]public Vector2 movementAimDirection = new Vector2();
    private bool canJump = false;
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float jumpForce = 1f;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - .3f), Vector2.down, .25f, 1<<22);
            //Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - .3f), Vector2.down, Color.cyan,.25f,true);
            if (hit)
            {  
                canJump = true;
            }
        }

        handleMovement();
    }

    public void setMovementVector(Vector2 directionToAim)
    {
        movementAimDirection = directionToAim;
    }

    public void tryJump()
    {
        if (canJump)
        {
            jump();
        }
    }

    public void jump()
    {
        myBody.AddForce(new Vector2(0, jumpForce),ForceMode2D.Impulse);
        canJump = false;
    }

    private void handleMovement()
    {
        
        myBody.velocity = new Vector2(movementAimDirection.x * movementSpeed, myBody.velocity.y);
    }
}

