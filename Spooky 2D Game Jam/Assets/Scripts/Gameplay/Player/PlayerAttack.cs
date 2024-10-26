using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject candyPrefab;
    [SerializeField] private VirtualCamFollow virtualCam;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)
            && !virtualCam.isShopping)
        {
            ThrowCandy();
        }
    }

    void ThrowCandy()
    {
        Instantiate(candyPrefab, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
    }
}
