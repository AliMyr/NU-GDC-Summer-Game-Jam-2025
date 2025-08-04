using UnityEngine;

public class PlayerHealth : IHealth
{
    private float currentHealth;
    private readonly float maxHealth;

    public PlayerHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
    }

    public float CurrentHealth => currentHealth;
    public bool IsAlive => currentHealth > 0;

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Max(currentHealth - amount, 0f);
    }
}
