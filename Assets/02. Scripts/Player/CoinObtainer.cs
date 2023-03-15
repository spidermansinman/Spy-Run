using System;
using UnityEngine;

public class CoinObtainer : MonoBehaviour
{
    public Action<int> OnCoinObtained;
    private int _coins = 0;

    public int Coins => _coins;

    // When the player collides with a trigger
    private void OnTriggerEnter(Collider other)
    {
        // If the trigger is of type coin
        if (other.gameObject.CompareTag("Coin"))
        {
            // Add a coin and call everyone who listens to the coin being obtained
            _coins++;
            OnCoinObtained?.Invoke(_coins);
            // Then return the coin to the pool
            CoinBehaviour coinBehaviour = other.GetComponent<CoinBehaviour>();
            coinBehaviour.CoinGot();
        }
    }
}
