using System.Collections;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float moveSpeed = 5f;
  

    private bool atPointA = true;
    public bool isMoving = false;

  

    public void StartMoving()
    {
        
        if (!isMoving)
        {
            StartCoroutine(MovePlatform());
        }
    }

    private IEnumerator MovePlatform()
    {
        isMoving = true;

        Vector3 target;


        if (atPointA)
        {
            target = pointB.position;
        }
        else
        {
            target = pointA.position;
        }

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
        atPointA = !atPointA;
        isMoving = false;
    }

}
