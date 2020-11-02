using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Walking Enemy")]
public class WalkingEnemy : EnemyAI
{
    [SerializeField]private float AiRefreshSpeed = .35f;
    [SerializeField] private float movementSpeed = 1f;
    


    public override void init(Enemy thisEnemy)
    {
        
    }

    public override void AILoop(Enemy thisEnemy)
    {
        if (thisEnemy.timer > 0)
        {

            thisEnemy.enemyBody.velocity = new Vector2(movementSpeed * thisEnemy.DirectionToMove, thisEnemy.enemyBody.velocity.y);
        }
        else
        {
            if (thisEnemy.targetLocation.position.x > thisEnemy.transform.position.x)
            {
                thisEnemy.DirectionToMove = 1f;
            }
            else
            {
                thisEnemy.DirectionToMove = -1f;
            }
            thisEnemy.timer = AiRefreshSpeed;
        }
        thisEnemy.timer -= Time.deltaTime;

    }
}
