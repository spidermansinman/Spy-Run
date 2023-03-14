using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class PlayerGroupAdd : MonoBehaviour
{
    [SerializeField]
    private CinemachineTargetGroup _targetGroup;
    // When a player joins, add it to the camera group
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        _targetGroup.AddMember(playerInput.transform, 1f, 1f);
    }
}
