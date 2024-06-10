using System.Collections;
using UnityEngine;

public class MobileDoor : MonoBehaviour
{
    [SerializeField]
    private Transform[] _travelPoints;
    [SerializeField]
    [Tooltip("How much time (in seconds) will take to go from a point to another?")]
    private float _travelTime;
    [SerializeField]
    [Tooltip("How much time (in seconds) will take for an object to move again after arriving to a travel point?")]
    private float _waitTime;
    [SerializeField]
    private Renderer _renderer;
    [SerializeField]
    private Material _material1;
    [SerializeField]
    private Material _material2;

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
            if (_currentTravelPoint == 0)
            {
                _renderer.material = _material1;
            } else
            {
                _renderer.material = _material2;
            }
        }
    }
}
