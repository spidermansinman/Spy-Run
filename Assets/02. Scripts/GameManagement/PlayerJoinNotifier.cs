using UnityEngine;
using System;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerJoinNotifier : MonoBehaviour
{

    public static Action<PlayerInput> OnPlayerJoins;

    public static List<GameObject> List = new List<GameObject>();

    private void Awake()
    {
        List.Clear();
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        OnPlayerJoins?.Invoke(playerInput);
        List.Add(playerInput.gameObject);
    }
}
