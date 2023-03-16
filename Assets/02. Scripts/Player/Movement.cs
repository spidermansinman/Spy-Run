using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The character controller component, which moves the player")]
    private CharacterController _characterController = default;
    [SerializeField]
    [Tooltip("The speed (in m/s) at which the players will move")]
    private float _speed = 1f;

    private Animator _animator;

    Vector2 _direction;

    public void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    // When you press WASD or move the left joystick, save the direction you are pointing to
    public void Move(InputAction.CallbackContext ctx)
    {
        if (GameTimer.instance.GameRunning)
        {
            if (ctx.started || ctx.performed)
            {
                _direction = ctx.ReadValue<Vector2>();
            }
            else if (ctx.canceled)
            {
                _direction = default;
            }
        } else
        {
            _direction = default;
        }
    }

    private void OnEnable()
    {
        GameTimer.OnTimerEnded += OnTimerEnded;
    }

    private void OnDisable()
    {
        GameTimer.OnTimerEnded -= OnTimerEnded;
    }

    private void OnTimerEnded()
    {
        _direction = default;
        var lookat = transform.position + Vector3.back;
        transform.LookAt(lookat);
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
        if (_animator != null)
        {
            _animator.SetFloat("Speed", _direction.magnitude);
            _animator.SetFloat("SpeedY", _characterController.velocity.y);
            _animator.SetBool("Grounded", _characterController.isGrounded);
        }
    }
}
