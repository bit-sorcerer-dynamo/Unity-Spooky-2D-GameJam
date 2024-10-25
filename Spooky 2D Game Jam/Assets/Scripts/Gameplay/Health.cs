using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;

    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;    
    }

    void TakeDamage(float damage)
    {
        if (currentHealth - damage > 0) currentHealth -= damage;
        else currentHealth = 0;
    }
}
