using UnityEngine;

public class Fall : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The character controller component, which moves the character")]
    private CharacterController _characterController;
    [SerializeField]
    [Tooltip("To which position will the player return when falling?")]
    private Vector3 _returnToPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fall"))
        {
            Debug.Log("Player fell");
            _characterController.enabled = false;
            transform.position = _returnToPosition;
            _characterController.enabled = true;
        }
    }
}
