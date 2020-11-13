using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyAI Intelligence;

    public Rigidbody2D enemyBody;
    public Vector2 targetLocation;

    public float DirectionToMove = 1f;
    public float timer = 0;

    private bool isKnockingBack = false;
    private Health myHealth;

    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        myHealth = GetComponent<Health>();

        //initialize intelligence
        Intelligence.init(this);
    }

    void Update()
    {
        if (GameObject.FindObjectOfType<PlayerMovement>() != null)
        {
            targetLocation = GameObject.FindObjectOfType<PlayerMovement>().transform.position;
        }
        //run main loop
        if (isKnockingBack == false)
        {
            Intelligence.AILoop(this);
            if (myHealth != null)
            {
                if (myHealth.isDead)
                {
                    //die
                    Die();
                }
            }
        }
    }

    public void KnockBack(float knockBackAmount, bool knockRight)
    {
        isKnockingBack = true;

        float direction = 0;
        if (knockRight)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        enemyBody.velocity = Vector2.zero;
        enemyBody.AddForce(new Vector2(knockBackAmount * direction, knockBackAmount * .3f), ForceMode2D.Impulse);
        StartCoroutine(knockBackTimer());
        
    }

    private IEnumerator knockBackTimer()
    {
        yield return new WaitForSeconds(.4f);
        isKnockingBack = false;
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
