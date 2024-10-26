using UnityEngine;

public class VirtualCamFollow : MonoBehaviour
{
    public bool isShopping = false;
    public bool isCutscene = false;
    
    [Space(1), Header("Camera Follow Targets")]
    [SerializeField] private Vector3 playerViewPoint;
    [SerializeField] private Transform houseViewPoint;
    [SerializeField] private Transform cutsceneViewPoint;

    private Vector3 targetPosition;
    private float lerpTime = 10f;

    void Update()
    {
        if (!isCutscene)
        {
            if (isShopping)
            {
                targetPosition = houseViewPoint.position;
            }
            else
            {
                targetPosition = playerViewPoint;
            }
        }
        else
        {
            targetPosition = cutsceneViewPoint.position;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpTime * Time.deltaTime);
    }
}
