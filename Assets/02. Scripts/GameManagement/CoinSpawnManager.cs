using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnManager : MonoBehaviour
{
    [SerializeField]
    private int _startingCoins = 10;
    [SerializeField]
    private int _parallelSpawns = 1;
    [SerializeField]
    private float _timeBetweenSpawns = 3f;

    private List<Transform> _coinSpawnPositions;
    private List<Transform> _tempSpawnPositions;

    private void Awake()
    {
        _coinSpawnPositions = new List<Transform>();
        _tempSpawnPositions = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            _coinSpawnPositions.Add(transform.GetChild(i));
        }
    }

    private Vector3 GetSpawnPosition()
    {
        if (_tempSpawnPositions.Count > 0)
        {
            int index = Random.Range(0, _tempSpawnPositions.Count);
            var pos = _tempSpawnPositions[index].position;
            _tempSpawnPositions.RemoveAt(index);
            return pos;
        } else
        {
            _tempSpawnPositions = new List<Transform>(_coinSpawnPositions);
            return GetSpawnPosition();
        }
    }

    private void Start()
    {
        for(int i = 0; i < _startingCoins; ++i)
        {
            SpawnCoin();
        }
        for(int i = 0; i < _parallelSpawns; i++)
        {
            StartCoroutine(SpawnThread());
        }
    }

    private IEnumerator SpawnThread()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeBetweenSpawns);
            SpawnCoin();
        }
    }

    private void SpawnCoin()
    {
        CoinSpawnPool.Instance.SpawnCoin(GetSpawnPosition());
    }
}
