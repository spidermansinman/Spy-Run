using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    [SerializeField]
    private AudioSource _musicSource;

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
        _musicSource.Play();
    }
}
