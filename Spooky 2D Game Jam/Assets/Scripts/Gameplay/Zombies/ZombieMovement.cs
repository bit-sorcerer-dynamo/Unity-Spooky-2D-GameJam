using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private VirtualCamFollow virtualCamFollow;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject headEntity;
    [SerializeField] private float repusleForce = 7f;

    private bool isPlayerInContact = false;

    private Rigidbody2D rb;
    private Transform selectedTarget;
    private Health zombieHealth;

    public float moveSpeed = 1f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        headEntity = GameObject.FindGameObjectWithTag("Head");
        virtualCamFollow = GameObject.Find("VirtualCamFollow").GetComponent<VirtualCamFollow>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        zombieHealth = GetComponent<Health>();

        selectedTarget = player.transform;
        moveSpeed = 1f;
    }

    void Update()
    {
        if (!virtualCamFollow.isCutscene)
        {
            if (isPlayerInContact)
            {

                Vector2 repulseDir = transform.position - player.transform.position;
                rb.velocity = repulseDir.normalized * repusleForce;
            }
            else
            {
                if (selectedTarget == null && player != null) selectedTarget = player.transform;
                else if (selectedTarget == null && player == null) selectedTarget = headEntity.transform;

                if (zombieHealth.CurrentHealth > 0)
                {
                    Vector2 moveDirection = selectedTarget.position - transform.position;
                    rb.velocity = moveDirection.normalized * moveSpeed;
                }
                else
                {
                    rb.velocity = Vector2.zero;
                    Invoke("SelfDestruct", 1);
                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void SelfDestruct()
    {
        Destroy(this.gameObject);
    }

    // Distract Enemy From Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Candy"))
        {
            selectedTarget = collision.gameObject.transform;
        }

        if (collision.CompareTag("Zombie"))
        {
            player.GetComponent<PlayerCurrency>().AddCurrencyValue(Random.Range(1, 5));
        }

        if (collision.CompareTag("Player"))
        {
            isPlayerInContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInContact = false;
        }
    }

}
