using UnityEngine;
using TMPro;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The text object that shows the score of the player")]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    [Tooltip("The text object that shows the battery count of the player")]
    private TextMeshProUGUI _batteryText;

    // To activate the UI, activate the UI game object and subscribe to the coin and battery obtain
    public void Activate(GameObject playerObject)
    {
        gameObject.SetActive(true);

        CoinObtainer coinObtainer = playerObject.GetComponent<CoinObtainer>();
        if (coinObtainer != null)
        {
            coinObtainer.OnCoinObtained += OnCoinObtained;
        }

        BatteryObtainer batteryObtainer = playerObject.GetComponent<BatteryObtainer>();
        if (batteryObtainer != null)
        {
            batteryObtainer.OnBatteryObtained += OnBatteryObtained;
        }
    }

    // When you obtain a coin, show how many coins you have now
    private void OnCoinObtained(int coins)
    {
        _scoreText.text = coins.ToString();
    }

    // When you obtain a battery, show how many batteries you have now
    private void OnBatteryObtained(int batteries)
    {
        _batteryText.text = batteries.ToString();
    }
}
