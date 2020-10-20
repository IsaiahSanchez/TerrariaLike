using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Item")]
public class Item : ScriptableObject
{
    [SerializeField] protected Sprite graphic;
    protected int ItemId = -1;
    protected Transform PlayerTransform;

    public void startScript(Transform myPlayerTransform)
    {
        PlayerTransform = myPlayerTransform;
    }

    public virtual void LeftUse()
    {

    }

    public virtual void RightUse()
    {

    }

    float time =5f;
    public virtual void ItemUpdate(float timeSinceLastFrame)
    {
        time -= timeSinceLastFrame;
        if (time < 0)
        {

        }
    }
}
