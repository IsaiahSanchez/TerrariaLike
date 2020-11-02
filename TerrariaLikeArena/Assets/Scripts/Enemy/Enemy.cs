using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyAI Intelligence;

    public Rigidbody2D enemyBody;
    public Transform targetLocation;

    public float DirectionToMove = 1f;

    public float timer = 0;

    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();

        //initialize intelligence
        Intelligence.init(this);
    }

    void Update()
    {
        targetLocation = GameObject.FindObjectOfType<PlayerMovement>().transform;
        //run main loop
        Intelligence.AILoop(this);
    }
}
