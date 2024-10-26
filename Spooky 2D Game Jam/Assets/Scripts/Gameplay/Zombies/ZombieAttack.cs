using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public float minDamage;
    public float maxDamage;

    private Transform attackTarget;
    private 

    void Attack(Transform target)
    {
        Health targetHealth = target.GetComponent<Health>();
        float damage = UnityEngine.Random.Range(minDamage, maxDamage);

        targetHealth.TakeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Zombie"))
        {
            attackTarget = collision.gameObject.transform;
            Attack(attackTarget);
        }
    }
}
