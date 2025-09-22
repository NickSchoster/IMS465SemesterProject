using System.Collections;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    [SerializeField] private GameObject movingPlatform;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float moveTime = 3f;

    public bool isMoving = false;

    public Pickup pickup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnCollisionEnter(Collision collision)
    {
        if (!isMoving)
        {
            if (collision.gameObject.CompareTag("BlueBlock") && !isMoving)
            {
                Debug.Log("BlueIsBlocking");
                StartCoroutine(MovePlatform());

            }
        }
       
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!isMoving)
        {

            if (collision.gameObject.CompareTag("BlueBlock") && !isMoving)
            {
                Debug.Log("BlueIsBlocking");
                StartCoroutine(ReverseMovePlatform());

            }
        }
    }

    private System.Collections.IEnumerator MovePlatform()
    {
        isMoving = true;
        float elapsed = 0.0f;

        Vector3 direction = Vector3.right;

        while (elapsed < moveTime)
        {
            movingPlatform.transform.Translate(direction*moveSpeed*Time.deltaTime);
            elapsed += Time.deltaTime;
            yield return null;
        }
        isMoving = false;
    }

    private System.Collections.IEnumerator ReverseMovePlatform()
    {
        isMoving = true;
        float elapsed = 0.0f;

        Vector3 direction = Vector3.left;

        while (elapsed < moveTime)
        {
            movingPlatform.transform.Translate(direction * moveSpeed * Time.deltaTime);
            elapsed += Time.deltaTime;
            yield return null;
        }
        isMoving = false;
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
