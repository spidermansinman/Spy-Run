using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnPool : MonoBehaviour
{
    public static CoinSpawnPool Instance;

    [SerializeField]
    private Transform _coinsParent;

    private List<GameObject> _coinsInPool = new List<GameObject>();


    private void Awake()
    {
        Instance = this;
        for(int i = 0; i < transform.childCount; i++)
        {
            _coinsInPool.Add(transform.GetChild(i).gameObject);
        }
    }

    public void ReturnToPool(GameObject coinObject)
    {
        coinObject.transform.SetParent(transform);
        coinObject.SetActive(false);
        _coinsInPool.Add(coinObject);
    }

    public void SpawnCoin(Vector3 position)
    {
        if (_coinsInPool.Count == 0) return;
        GameObject coin = _coinsInPool[0];
        _coinsInPool.RemoveAt(0);
        coin.transform.SetParent(_coinsParent);
        coin.transform.position = position;
        coin.SetActive(true);
    }
}
