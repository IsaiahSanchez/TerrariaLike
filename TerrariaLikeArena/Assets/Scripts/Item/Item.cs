using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Item")]
public class Item : ScriptableObject
{
    [SerializeField] protected float useSpeed;
    [SerializeField] protected Sprite itemGraphic;
    [SerializeField] protected int itemId;

    public virtual GameObject UseItem(GameObject User)
    {
        return null;
    }

    public virtual GameObject AlternateUseItem(GameObject User)
    {
        return null;
    }

    public virtual bool UsingUpdate(float totalTimeUsing)
    {
        return true;
    }

    public virtual bool UsingAlternateUpdate(float totalTimeUsingAlternate)
    {
        return true; 
    }

    public virtual void UpdateTick()
    {

    }

    public virtual void StopUsing()
    {

    }

    public virtual void StopUsingAlternate()
    {

    }

}
