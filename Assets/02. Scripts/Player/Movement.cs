using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private CharacterController _characterController = default;
    [SerializeField]
    private float _speed = 1f;

    Vector2 _direction;

    // When you press WASD or move the left joystick, save the direction you are pointing to
    public void Move(InputAction.CallbackContext ctx)
    {
        if (ctx.started || ctx.performed)
        {
            _direction = ctx.ReadValue<Vector2>();
        } else if (ctx.canceled)
        {
            _direction = default;
        }
    }

    // Each frame, move a little on the desired direction. Simple move also applies gravity.
    private void Update()
    {
        _characterController.SimpleMove(_speed * new Vector3(_direction.x, 0f, _direction.y));
    }
}
