using UnityEngine;
using Cinemachine;

public class HeadEntityBehaviour : MonoBehaviour
{
    public enum PossibleTweeks
    {
        playerMovementSpeed,
        enemyMovementSpeed,
        candySpeed,
        zombieAttackDamage,
        houseValues
    }

    private PossibleTweeks chosenTweek;

    [Header("Tweeking Sources")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform candyPrefab;
    [SerializeField] private GameObject[] houseBehaviours;
    [SerializeField] private GameObject[] zombies;

    [Space(10)]
    [SerializeField] private VirtualCamFollow virtualCamFollow;
    [SerializeField] private CinemachineVirtualCamera virtualCam;

    private void Start()
    {
        houseBehaviours = GameObject.FindGameObjectsWithTag("House");
        zombies = GameObject.FindGameObjectsWithTag("House");
        
        // FIXME :: Setup the Timings for Invoke Repeating
        InvokeRepeating("PerformChangeEffect", 6, 8);
        InvokeRepeating("RevertChangeEffect", 0, 8);
    }

    void PerformTweek(PossibleTweeks tweek)
    {
        switch (tweek)
        {
            case PossibleTweeks.playerMovementSpeed:
                player.GetComponent<PlayerMovement>().moveSpeed = Random.Range(5f, 15f);
                break;

            case PossibleTweeks.enemyMovementSpeed:
                
                foreach (GameObject zombie in zombies)
                {
                    zombie.GetComponent<ZombieMovement>().moveSpeed = Random.Range(0f, 2f);
                }
                break;

            case PossibleTweeks.candySpeed:

                candyPrefab.GetComponent<CandyBehaviour>().moveForce = Random.Range(0f, 1f);
                break;

            case PossibleTweeks.zombieAttackDamage:

                foreach (GameObject zombie in zombies)
                {
                    zombie.GetComponent<ZombieAttack>().minDamage = Random.Range(5f, 20f);
                    zombie.GetComponent<ZombieAttack>().maxDamage = Random.Range(20f, 40f);
                }
                break;

            case PossibleTweeks.houseValues:

                foreach (GameObject houseBehaviour in houseBehaviours)
                {
                    houseBehaviour.GetComponent<HouseBehaviour>().RandomizeItems();
                }
                break;
        }
    }

    void PerformChangeEffect()
    {
        virtualCamFollow.isCutscene = true;
        virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 4f;
        virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 4f;

        chosenTweek = (PossibleTweeks) Random.Range(0, 4);
        Debug.Log(chosenTweek);
        PerformTweek(chosenTweek);
    }

    void RevertChangeEffect()
    {
        virtualCamFollow.isCutscene = false;
        virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 1.5f;
        virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1f;
    }
    
}
