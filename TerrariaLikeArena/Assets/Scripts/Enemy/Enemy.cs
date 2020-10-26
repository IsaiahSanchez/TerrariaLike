using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ScriptableObject
{

    public Transform currentTarget = null;
    public bool shouldMove = false;


    public virtual void Activate()
    {
        
    }

    public virtual void UpdateAI()
    {

    }

    public virtual void setTarget()
    {

    }

    private void OnDisable()
    {
        currentTarget = null;
        shouldMove = false;
    }
}
