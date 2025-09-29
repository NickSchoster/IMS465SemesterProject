using System.Collections;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private float moveDistance = 0.1f;
    [SerializeField] private float moveTIme = 0.2f;
    private Vector3 initalPosition;

    private void Awake()
    {
        initalPosition = transform.position;
    }

    public void PressDown()
    {
        //StopAllCoroutines();
        StartCoroutine(MovePlate(initalPosition + Vector3.down * moveDistance));
    }
    public void Release()
    {
        //StopAllCoroutines();
        StartCoroutine(MovePlate(initalPosition));
    }

    private IEnumerator MovePlate(Vector3 targetPos)
    {
        Vector3 start = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < moveTIme)
        {
            transform.localPosition = Vector3.Lerp(start, targetPos, elapsed / moveTIme);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = targetPos;
    }
}
