using System.Collections;
using UnityEngine;

public class PlayerStartingPosition : MonoBehaviour
{
    [SerializeField]
    private Movement _movement;

    Vector3 _startingPosition;

    IEnumerator Start()
    {
        transform.position = _startingPosition;
        transform.LookAt(Vector3.zero);
        yield return new WaitForSeconds(1f);
        _movement.enabled = true;
    }


    public void SetStartingPosition(Vector3 position)
    {
        _startingPosition = position;
    }
}
