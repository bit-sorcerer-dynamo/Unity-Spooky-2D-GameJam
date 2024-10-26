using UnityEngine;

public class VirtualCamFollow : MonoBehaviour
{
    public bool isShopping = false;
    public bool isCutscene = false;
    
    [Space(1), Header("Camera Follow Targets")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform houseViewPoint;
    [SerializeField] private Transform cutsceneViewPoint;
    
    private float lerpTime = 10f;

    void Update()
    {
        if (!isCutscene)
        {
            if (isShopping) transform.position = Vector3.Lerp(transform.position, houseViewPoint.position, lerpTime * Time.deltaTime);
            else transform.position = Vector3.Lerp(transform.position, player.position, lerpTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, cutsceneViewPoint.position, lerpTime * Time.deltaTime);
        }
    }
}
