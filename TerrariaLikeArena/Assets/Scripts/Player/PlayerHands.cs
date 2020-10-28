using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    public Item equippedItem;

    private bool isUsing = false;
    private bool isAlternateUsing = false;
    public float timePassedUsing = 0f;
    public float timePassedAlternateUsing = 0f;

    private PlayerDirectionHandler directionHandler;
    public GameObject spawnedItem;

    private void Start()
    {
        directionHandler = GetComponentInParent<PlayerDirectionHandler>();
    }


    public void LeftClick()
    {
        if (equippedItem != null)
        {
            if (isUsing == false && isAlternateUsing == false)
            {
                timePassedUsing = 0;
                equippedItem.UseItem(this);
                isUsing = true;
            }
        }
    }

    public void RightClick()
    {
        if (equippedItem != null)
        {
            if (isAlternateUsing == false && isUsing == false)
            {
                timePassedAlternateUsing = 0;
                equippedItem.AlternateUseItem(this);
                isAlternateUsing = true;
            }
        }
    }

    public void changeSelectedItem(Item itemToChangeTo)
    {
        isUsing = false;
        isAlternateUsing = false;
        timePassedUsing = 0;
        timePassedAlternateUsing = 0;
    }

    void Update()
    {
        if (equippedItem != null)
        {
            handleUseUpdate(Time.deltaTime);
            handleAlternateUseUpdate(Time.deltaTime);
            handleUpdateTick();
            if (isAlternateUsing == false && isUsing == false)
            {
                if (directionHandler != null)
                {
                    directionHandler.canTurn = true;
                }
            }
            else
            {
                directionHandler.canTurn = false;
            }
        }
    }


    

    private void handleUseUpdate(float timePassed)
    {
        if (isUsing)
        {
            bool isFinished = equippedItem.UsingUpdate(this);
            timePassedUsing += timePassed;

            if (isFinished)
            {
                isUsing = false;
                equippedItem.StopUsing(this);
            }
        }
    }

    private void handleAlternateUseUpdate(float timePassed)
    {
        if (isAlternateUsing)
        {
            bool isFinished = equippedItem.UsingAlternateUpdate(this);
            timePassedAlternateUsing += timePassed;
            if (isFinished)
            {
                isAlternateUsing = false;
                equippedItem.StopUsingAlternate(this);
            }
        }
    }

    private void handleUpdateTick()
    {
        equippedItem.UpdateTick(this);
    }

    public void stopUsing()
    {
        Destroy(spawnedItem);
        spawnedItem = null;
    }

}
