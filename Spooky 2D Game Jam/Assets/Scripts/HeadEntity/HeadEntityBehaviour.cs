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

        float repeatRate = Random.Range(50, 60);
        InvokeRepeating("PerformChangeEffect", 8, repeatRate);
        InvokeRepeating("RevertChangeEffect", 12, repeatRate);
    }

    void ChangeHouseValues()
    {
        foreach (GameObject houseBehaviour in houseBehaviours)
        {
            houseBehaviour.GetComponent<HouseBehaviour>().RandomizeItems();
        }
    }

    void PerformChangeEffect()
    {
        virtualCamFollow.isHeadEntityTweeking = true;
        virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 4f;
        virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 4f;

        ChangeHouseValues();
    }

    void RevertChangeEffect()
    {
        virtualCamFollow.isHeadEntityTweeking = false;
        virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 1.5f;
        virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1f;
    }
    
}
