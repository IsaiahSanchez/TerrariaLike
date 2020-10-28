using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyAI Intelligence;

    public Rigidbody2D enemyBody;
    


    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        //initialize intelligence
    }

    void Update()
    {
        //run main loop
        
    }
}
