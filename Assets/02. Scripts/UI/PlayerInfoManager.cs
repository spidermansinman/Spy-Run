using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInfoManager : MonoBehaviour
{
    [SerializeField]
    private PlayerInfo[] _playerInfoPanels;

    // When a player joins, we activate the UI
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log($"Joined player with index {playerInput.playerIndex}");
        _playerInfoPanels[playerInput.playerIndex].Activate(playerInput.gameObject);
    }
}
