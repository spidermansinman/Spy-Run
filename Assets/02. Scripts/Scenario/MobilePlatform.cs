using System.Collections;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    [SerializeField]
    private Transform[] _travelPoints;
    [SerializeField]
    private float _travelTime;
    [SerializeField]
    private float _waitTime;

    private int _currentTravelPoint;

    void Start()
    {
        _currentTravelPoint = 0;
        StartCoroutine(Travel());
    }
    private void OnEnable()
    {
        GameTimer.OnTimerEnded += OnTimerEnded;
    }

    private void OnDisable()
    {
        GameTimer.OnTimerEnded -= OnTimerEnded;
    }

    private void OnTimerEnded()
    {
        StopAllCoroutines();
    }

    IEnumerator Travel()
    {
        while (true)
        {
            transform.position = _travelPoints[_currentTravelPoint].position;
            yield return new WaitForSeconds(_waitTime);
            float timer = 0f;
            int nextTravelPoint = (_currentTravelPoint + 1) % _travelPoints.Length;
            while(timer < _travelTime)
            {
                timer += Time.deltaTime;
                transform.position = Vector3.Lerp(_travelPoints[_currentTravelPoint].position, _travelPoints[nextTravelPoint].position, timer / _travelTime);
                yield return null;
            }
            _currentTravelPoint = nextTravelPoint;
        }
    }
}
