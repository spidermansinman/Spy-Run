using System.Collections;
using UnityEngine;

public class PlayerHitReceiver : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Time in which the player won't be able to move")]
    private float _stunTime;

    private Rigidbody _rb;
    private Movement _movement;
    private Animator _animator;

    private bool _stunned = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _movement = GetComponent<Movement>();
        _animator = GetComponentInChildren<Animator>();

        UpdateStunStatus(false);
    }

    public void ReceiveHit(Vector3 sourcePosition, float force)
    {
        if (_stunned) return;
        Debug.Log("Hit Received!");
        UpdateStunStatus(true);
        var groundedPosition = transform.position;
        groundedPosition.y = 0f;
        var groundedSourcePosition = sourcePosition;
        groundedSourcePosition.y = 0f;
        var dir = (groundedPosition - groundedSourcePosition).normalized;
        dir += Vector3.up;
        dir.Normalize();
        _rb.AddForce(dir * force);
        StartCoroutine(RecoverStunCoroutine());
    }

    private void UpdateStunStatus(bool stunned)
    {
        _stunned = stunned;
        _movement.IsStunned = stunned;
        _animator.SetBool("Stun", stunned);
    }

    private IEnumerator RecoverStunCoroutine()
    {
        yield return new WaitForSeconds(_stunTime);
        UpdateStunStatus(false);
    }
}
