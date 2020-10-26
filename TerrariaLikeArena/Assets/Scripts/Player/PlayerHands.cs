using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    public Item equippedItem;

    private bool isUsing = false;
    private bool isAlternateUsing = false;
    private float timePassedUsing = 0f;
    private float timePassedAlternateUsing = 0f;

    private PlayerDirectionHandler directionHandler;
    private GameObject spawnedItem;

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
                spawnedItem = equippedItem.UseItem(this.gameObject);
                isUsing = true;
                directionHandler.canTurn = false;
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
                spawnedItem = equippedItem.AlternateUseItem(this.gameObject);
                isAlternateUsing = true;
                directionHandler.canTurn = false;
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
        }
    }


    

    private void handleUseUpdate(float timePassed)
    {
        if (isUsing)
        {
            bool isFinished = equippedItem.UsingUpdate(timePassedUsing);
            timePassedUsing += timePassed;

            if (isFinished)
            {
                isUsing = false;
                directionHandler.canTurn = false;
                stopUsing();
            }
        }
    }

    private void handleAlternateUseUpdate(float timePassed)
    {
        if (isAlternateUsing)
        {
            bool isFinished = equippedItem.UsingAlternateUpdate(timePassedAlternateUsing);
            timePassedAlternateUsing += timePassed;
            if (isFinished)
            {
                isAlternateUsing = false;
                directionHandler.canTurn = true;
                stopUsing();
            }
        }
    }

    private void handleUpdateTick()
    {
        equippedItem.UpdateTick();
    }

    private void stopUsing()
    {
        spawnedItem = null;
    }

}
