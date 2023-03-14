using UnityEngine;

public class Fall : MonoBehaviour
{
    [SerializeField]
    private CharacterController _characterController;
    [SerializeField]
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
