using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;
    [HideInInspector]public Vector2 movementAimDirection = new Vector2();
    private bool canJump = false;
    private float jumpCheckDelay = .1f;
    private bool isBeingKnockedBack = false;
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

        if (isBeingKnockedBack == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - .3f), Vector2.down, .25f, 1 << 22);
            //Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - .3f), Vector2.down, Color.cyan,.25f,true);

            jumpCheckDelay -= Time.deltaTime;
            if (hit.transform != null && jumpCheckDelay <= 0)
            {
                canJump = true;
            }
            else
            {
                canJump = false;
            }

            handleMovement();
        }
    }

    public void setMovementVector(Vector2 directionToAim)
    {
        movementAimDirection = directionToAim;
    }

    public void tryJump()
    {
        if (canJump)
        {
            jumpCheckDelay = .1f;
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

    public void KnockBack(float knockBackAmount, bool isKnockingRight)
    {
        float direction = 0;
        if (isKnockingRight)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        myBody.AddForce(new Vector2(knockBackAmount * direction, knockBackAmount * .4f));
        isBeingKnockedBack = true;
        StartCoroutine(knockBackTimer());
    }

    private IEnumerator knockBackTimer()
    {
        yield return new WaitForSeconds(.25f);
        isBeingKnockedBack = false;
    }
}

