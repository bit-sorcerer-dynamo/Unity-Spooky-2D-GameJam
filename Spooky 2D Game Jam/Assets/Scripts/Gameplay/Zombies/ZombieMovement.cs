using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rb;
    private Transform selectedTarget;
    private Health zombieHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        zombieHealth = GetComponent<Health>();
    }

    void Update()
    {
        // Setting the Default Target of Zombies
        if (selectedTarget == null)
            selectedTarget = player;

        if (zombieHealth.CurrentHealth > 0)
        {
            Vector2 moveDirection = selectedTarget.position - transform.position;
            rb.velocity = moveDirection.normalized * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    // Distract Enemy From Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Candy"))
        {
            selectedTarget = collision.gameObject.transform;
        }
    }

}
