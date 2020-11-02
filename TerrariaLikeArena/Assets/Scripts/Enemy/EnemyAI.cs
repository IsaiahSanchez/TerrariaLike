using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : ScriptableObject
{
    public float touchDamageAmount = 2f;
    public float KnockBackAmount = 2f;

    // Start is called before the first frame update
    public virtual void init(Enemy thisEnemy)
    {
        
    }

    // Update is called once per frame
    public virtual void AILoop(Enemy thisEnemy)
    {
        
    }
}
