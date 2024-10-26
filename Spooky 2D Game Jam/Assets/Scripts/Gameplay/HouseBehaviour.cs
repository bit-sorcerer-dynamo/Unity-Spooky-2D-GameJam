using UnityEngine;

public class HouseBehaviour : MonoBehaviour
{
    [SerializeField] private VirtualCamFollow virtualCam;
    [SerializeField] private GameObject UIHolder;

    private const string PLAYER_TAG = "Player";

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG))
        {
            virtualCam.isShopping = true;
            UIHolder.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG))
        {
            virtualCam.isShopping = false;
            UIHolder.SetActive(false);
        }
    }
}
