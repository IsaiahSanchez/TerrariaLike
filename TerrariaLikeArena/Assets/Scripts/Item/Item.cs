using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Item")]
public class Item : ScriptableObject
{
    [SerializeField] protected float useSpeed;
    [SerializeField] protected Sprite itemGraphic;
    [SerializeField] protected int itemId;

    public virtual void UseItem(PlayerHands hands)
    {
        
    }

    public virtual void AlternateUseItem(PlayerHands hands)
    {
        
    }

    public virtual bool UsingUpdate(PlayerHands hands)
    {
        return true;
    }

    public virtual bool UsingAlternateUpdate(PlayerHands hands)
    {
        return true;
    }

    public virtual void UpdateTick(PlayerHands hands)
    {

    }

    public virtual void StopUsing(PlayerHands hands)
    {

    }

    public virtual void StopUsingAlternate(PlayerHands hands)
    {

    }

}
