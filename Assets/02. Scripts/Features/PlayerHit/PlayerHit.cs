using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHit : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Max angle to hit another player")]
    private float _maxAngle;

    [SerializeField]
    [Tooltip("Max distance to hit another player")]
    private float _maxDistance;

    [SerializeField]
    [Tooltip("Time in seconds between hits")]
    private float _timeDelay;

    [SerializeField]
    [Tooltip("How much force (for the impulse) will the character have")]
    private float _hitForce;

    private float _lastTimeHitPerformed = 0f;
    private Animator _animator;

    public void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void Hit(InputAction.CallbackContext ctx)
    {
        if (ctx.started && GameTimer.instance.GameRunning && _lastTimeHitPerformed + _timeDelay < Time.time)
        {
            _animator.SetTrigger("Hit");
            foreach (var player in PlayerJoinNotifier.List)
            {
                if (player != gameObject)
                {
                    var vectorToEnemy = player.transform.position - transform.position;
                    if (Vector3.Angle(transform.forward, vectorToEnemy.normalized) < _maxAngle && vectorToEnemy.magnitude < _maxDistance)
                    {
                        PlayerHitReceiver hitReceiver = player.GetComponent<PlayerHitReceiver>();
                        if (hitReceiver != null)
                        {
                            hitReceiver.ReceiveHit(transform.position, _hitForce);
                        }
                    }
                }
            }
            _lastTimeHitPerformed = Time.time;
        }
    }
}
