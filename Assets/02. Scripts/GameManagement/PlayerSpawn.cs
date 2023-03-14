using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    private Transform[] _spawnPositions;
    [SerializeField]
    private GameObject[] _characterPrefabs;

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Instantiate(_characterPrefabs[playerInput.playerIndex], playerInput.transform);
        playerInput.gameObject.GetComponent<PlayerStartingPosition>().SetStartingPosition(_spawnPositions[playerInput.playerIndex].position);
    }
}
