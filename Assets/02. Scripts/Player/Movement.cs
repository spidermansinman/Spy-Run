using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private CharacterController _characterController = default;
    [SerializeField]
    private float _speed = 1f;

    private Animator _animator;

    Vector2 _direction;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

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
    // Then rotate to the direction
    // Then send the data to the animator
    private void Update()
    {
        Vector3 v3Direction = new Vector3(_direction.x, 0f, _direction.y);
        _characterController.SimpleMove(_speed * v3Direction);
        var lookat = transform.position + v3Direction;
        transform.LookAt(lookat);
        _animator.SetFloat("Speed", _direction.magnitude);
        _animator.SetFloat("SpeedY", _characterController.velocity.y);
    }
}
