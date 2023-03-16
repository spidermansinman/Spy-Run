using System.Collections;
using UnityEngine;

public class PlayerStartingPosition : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The character controller component, which moves the player")]
    private CharacterController _characterController;

    Vector3 _startingPosition;

    void Start()
    {
        _characterController.enabled = false;
        transform.position = _startingPosition;
        _characterController.enabled = true;
        transform.LookAt(Vector3.zero);
    }


    public void SetStartingPosition(Vector3 position)
    {
        _startingPosition = position;
    }
}
