using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    private float currentHealth = 100;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void SetHealth(float amount)
    {
        currentHealth = amount;
    }

    public void SetMaxHealth(float amount)
    {
        maxHealth = amount;
    }

    public int GetHealth()
    {
        return Mathf.CeilToInt(currentHealth);
    }

    public void Die()
    {
        OnDeath.Invoke();
    }

    [SerializeField] private UnityEvent OnDeath;
}
