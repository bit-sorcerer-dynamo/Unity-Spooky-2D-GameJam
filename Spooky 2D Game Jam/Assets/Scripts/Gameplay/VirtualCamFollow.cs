using UnityEngine;

public class VirtualCamFollow : MonoBehaviour
{
    public bool isShopping = false;
    public bool isCutscene = false;
    
    [Space(1), Header("Camera Follow Targets")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform houseViewPoint;
    [SerializeField] private Transform cutsceneViewPoint;

    private Vector3 targetPosition;
    private float lerpTime = 10f;

    void Update()
    {
        if (!isCutscene)
        {
            if (isShopping) targetPosition = houseViewPoint.position;
            else
            {
                if (!player.GetComponent<PlayerMovement>().isPlayerDead)
                {
                    targetPosition = player.position;
                }
                else
                {
                    targetPosition = cutsceneViewPoint.position;
                }
            }
        }
        else
        {
            targetPosition = cutsceneViewPoint.position;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpTime * Time.deltaTime);
    }
}
