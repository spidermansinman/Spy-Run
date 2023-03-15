using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class GameTimer : MonoBehaviour
{
    public static GameTimer instance;

    [SerializeField]
    private float _gameDuration = 60f;

    public static Action OnTimerEnded;

    public float Timer => _timer;
    public bool GameRunning => _running;

    private float _timer = 0f;
    private bool _running = false;

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
        _timer = _gameDuration;
    }

    private void OnEnable()
    {
        PlayerJoinNotifier.OnPlayerJoins += OnPlayerJoins;
    }

    private void OnDisable()
    {
        PlayerJoinNotifier.OnPlayerJoins -= OnPlayerJoins;
    }

    private void OnPlayerJoins(PlayerInput input)
    {
        if (!_running)
        {
            _running = true;
        }
    }

    void Update()
    {
        if (_running)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0f)
            {
                _timer = 0f;
                _running = false;
                OnTimerEnded?.Invoke();
            }
        }
    }
}
