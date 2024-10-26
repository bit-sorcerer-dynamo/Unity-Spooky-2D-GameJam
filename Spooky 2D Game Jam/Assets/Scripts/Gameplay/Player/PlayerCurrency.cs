using UnityEngine;
using TMPro;

public class PlayerCurrency : MonoBehaviour
{
    public int defaultCurrency = 100;
    public int Currency { get; private set; }

    [SerializeField] private TMP_Text currencyDisplayText;

    void Start()
    {
        Currency = defaultCurrency;
    }

    private void Update()
    {
        currencyDisplayText.text = $"{Currency}";
    }

    public void AddCurrencyValue(int value)
    {
        Currency += value;
    }

    public void ReduceCurrencyValue(int value)
    {
        if (Currency - value > 0) Currency -= value;
        else Currency = 0;
    }
}
