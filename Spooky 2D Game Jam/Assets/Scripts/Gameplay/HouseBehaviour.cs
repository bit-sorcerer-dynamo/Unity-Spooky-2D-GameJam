using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HouseBehaviour : MonoBehaviour
{
    [SerializeField] private VirtualCamFollow virtualCam;

    [SerializeField] private GameObject UIHolder;

    [SerializeField] private Button healthPurchaseButton;
    private TMP_Text healthPurchaseText;
    private int healthCost;
    private float health;

    [SerializeField] private Button candyPurchaseButton;
    private TMP_Text candyPurchaseText;
    private int candyCost;
    private int candies;

    [SerializeField] private Transform player;
    private const string PLAYER_TAG = "Player";

    private void Start()
    {
        healthPurchaseText = healthPurchaseButton.GetComponentInChildren<TMP_Text>();
        candyPurchaseText = candyPurchaseButton.GetComponentInChildren<TMP_Text>();

        RandomizeItems();
    }

    private void Update()
    {
        healthPurchaseText.text = $"{health} health \nfor ${healthCost}";
        candyPurchaseText.text = $"{candies} candies \nfor ${candyCost}";
    }

    void RandomizeItems()
    {
        #region health
        healthCost = Random.Range(10, 35);
        health = Random.Range(5, 40);
        #endregion

        #region candies
        candyCost = Random.Range(25, 51);
        candies = Random.Range(1, 25);

        #endregion
    }

    public void PurchaseHealth()
    {
        player.GetComponent<PlayerCurrency>().ReduceCurrencyValue(healthCost);
        if (player.GetComponent<PlayerCurrency>().paymentSuccess)
        {
            player.GetComponent<Health>().Heal(health);
        }
    }

    public void PurchaseCandies()
    {
        player.GetComponent<PlayerCurrency>().ReduceCurrencyValue(candyCost);
        if (player.GetComponent<PlayerCurrency>().paymentSuccess)
        {
            player.GetComponent<PlayerAttack>().AddCandies(candies);
        }
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
