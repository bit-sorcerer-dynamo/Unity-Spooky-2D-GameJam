using UnityEngine;
using Cinemachine;

public class HeadEntityBehaviour : MonoBehaviour
{
    private GameObject[] houseBehaviours;

    [Space(10)]
    [SerializeField] private VirtualCamFollow virtualCamFollow;
    [SerializeField] private CinemachineVirtualCamera virtualCam;

    private void Start()
    {
        houseBehaviours = GameObject.FindGameObjectsWithTag("House");

        float repeatRate = Random.Range(10, 40);
        InvokeRepeating("PerformChangeEffect", 2, repeatRate);
        InvokeRepeating("RevertChangeEffect", 8, repeatRate);
    }

    void ChangeHouseValues()
    {
        
    }

    void PerformChangeEffect()
    {
        virtualCamFollow.isCutscene = true;
        virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 4f;
        virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 4f;

    }

    void RevertChangeEffect()
    {
        virtualCamFollow.isCutscene = false;
        virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 1.5f;
        virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1f;
    }
    
}
