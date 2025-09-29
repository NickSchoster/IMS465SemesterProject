using System.Collections;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float moveSpeed = 20f;


    private Coroutine moveRoutine;

    private void Start()
    {
        // Snap platform to pointA on start (optional)
        if (pointA != null)
        {
            transform.position = pointA.position;
        }
    }

    public void MoveToPointA()
    {
        if (pointA == null)
        {
            Debug.LogError("PointA not assigned on " + gameObject.name);
            return;
        }
        StartMove(pointA.position);
    }

    public void MoveToPointB()
    {
        if (pointB == null)
        {
            Debug.LogError("PointB not assigned on " + gameObject.name);
            return;
        }
        StartMove(pointB.position);
    }

    private void StartMove(Vector3 target)
    {
        if (moveRoutine != null) StopCoroutine(moveRoutine);
        moveRoutine = StartCoroutine(MovePlatform(target));
    }

    private IEnumerator MovePlatform(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                moveSpeed * Time.deltaTime
            );
            yield return null;
        }
        transform.position = target;
        moveRoutine = null;
    }

}
