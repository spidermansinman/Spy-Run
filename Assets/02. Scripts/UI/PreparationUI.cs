using UnityEngine;
using TMPro;
using System;

public class PreparationUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timerText;

    private void OnEnable()
    {
        GameTimer.OnPreparationEnded += OnPreparationEnded;
    }

    private void OnDisable()
    {
        GameTimer.OnPreparationEnded -= OnPreparationEnded;
    }

    private void OnPreparationEnded()
    {
        _timerText.text = "";
    }

    private void Update()
    {
        if (GameTimer.instance.GamePreparing)
        {
            float timer = GameTimer.instance.Timer;
            _timerText.text = timer.ToString("N0");
        }
    }
}
