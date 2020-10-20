using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    public Item equippedItem;

    private void Start()
    {
        equippedItem.startScript(GetComponentInParent<Transform>());
    }


    public void LeftClick()
    {
        if (equippedItem != null)
        {
            equippedItem.LeftUse();
        }
    }

    public void RightClick()
    {
        if (equippedItem != null)
        {
            equippedItem.RightUse();
        }
    }

    public void changeSelectedItem(Item itemToChangeTo)
    {

    }

    private void FixedUpdate()
    {
        
    }

    void Update()
    {
        if (equippedItem != null)
        {
            equippedItem.ItemUpdate(Time.deltaTime);
        }
    }

}
