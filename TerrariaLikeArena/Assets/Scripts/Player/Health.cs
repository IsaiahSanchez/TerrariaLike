using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float MaxHealth;
    private float currentHealth;

    public bool isDead = false;

    private void Start()
    {
        currentHealth = MaxHealth;
    }

    public void setHealth(float amount)
    {
        currentHealth = Mathf.Clamp(amount, 0, MaxHealth);
        checkDeath();
    }

    public void Heal(float amount)
    {
        //check if health is 0 or less
        //if isnt then heal
        //if is then die and do nothing in heal section
        if (checkDeath() == false)
        {
            if (amount > 0)
            {
                currentHealth += amount;
                if (currentHealth > MaxHealth)
                {
                    currentHealth = MaxHealth;
                }
            }
        }
    }

    public void Damage(float amount)
    {
        if (amount > 0)
        {
            currentHealth -= amount;
            Debug.Log(currentHealth);
            checkDeath();
        }
    }

    private bool checkDeath()
    {
        if (currentHealth <= 0)
        {
            Die();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Die()
    {
        //die stuff
        isDead = true;
    }
}
