using UnityEngine;

public class CandyBehaviour : MonoBehaviour
{
    [SerializeField] private float moveForce;
    [SerializeField] private Rigidbody2D rb;

    private Camera cam;

    private PlayerAttack playerAttack;
    private Vector2 throwDirection;
    private Vector2 mousePos;

    void Awake()
    {
        playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();

        // Getting Position in Terms of Vectors
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        throwDirection = mousePos - new Vector2(playerAttack.transform.position.x, playerAttack.transform.position.y);

        // Calculating angle of the Resultant Vector
        float throwAngle = Mathf.Atan2(throwDirection.y, throwDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = throwAngle;

        // Destroying the Gameobject
        Invoke("SelfDestruct", 2f);
    }

    void Update()
    {
        Vector2 movement = new Vector2(transform.forward.x, transform.forward.y);
        rb.AddForce(transform.up * moveForce, ForceMode2D.Impulse);
    }

    void SelfDestruct()
    {
        Destroy(this.gameObject);
    }
}
