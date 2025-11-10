using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlatformTrigger : MonoBehaviour
{
    [SerializeField] private GameObject movingPlatform;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float moveTime = 3f;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float othermoveTime = 0.75f;

    public bool isMoving = false;
    private bool atPointA = false;
    private bool placedWhileMoving = false;
    private bool stillColliding = false;

    public Pickup pickup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnCollisionEnter(Collision collision)
    {
        
        if (isMoving)
        {
            placedWhileMoving = true;
        }


        if (collision.gameObject.CompareTag("BlueBlock") && !isMoving)
        {
            
            
            Debug.Log("BlueIsBlocking");
            //StartCoroutine(MoveTrigger());
            StartCoroutine(MovePlatform());
            placedWhileMoving = false;
          

        }


    }

    private void OnCollisionStay(Collision collision)
    {
        stillColliding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!placedWhileMoving)
        {

            if (collision.gameObject.CompareTag("BlueBlock") && !isMoving)
            {
                Debug.Log("BlueIsBlocking");
                //  StartCoroutine(ReverseMovePlatform());
               // StartCoroutine(ReverseMoveTrigger());
                StartCoroutine(MovePlatform());
               

            }
        }
    }

   

    private System.Collections.IEnumerator MoveTrigger()
    {
        float elapsed = 0.0f;
        Vector3 otherDrection = Vector3.down;
        while (elapsed < othermoveTime)
        {
            this.transform.Translate(otherDrection * Time.deltaTime / 5);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    private System.Collections.IEnumerator ReverseMoveTrigger()
    {
        float elapsed = 0.0f;
        Vector3 otherDrection = Vector3.up;
        while (elapsed < othermoveTime)
        {
            this.transform.Translate(otherDrection * Time.deltaTime / 5);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
    private System.Collections.IEnumerator MovePlatform()
    {
        isMoving = true;
    

        //Vector3 direction = Vector3.right;
        Vector3 target;
        

        if (atPointA)
        {
            target = pointB.position;
        }
        else
        {
            target = pointA.position;
        }

       

        // while (elapsed < moveTime)
        {
            //  movingPlatform.transform.Translate(direction*moveSpeed*Time.deltaTime);
            // elapsed += Time.deltaTime;
            // yield return null;
            //}
            while (Vector3.Distance(movingPlatform.transform.position, target) > 0.01f)
            {
                movingPlatform.transform.position = Vector3.MoveTowards(
                    movingPlatform.transform.position,
                    target,
                    moveSpeed * Time.deltaTime
                );
                yield return null;
            }

            // Snap exactly to target (avoid float inaccuracy)
            movingPlatform.transform.position = target;

            // Toggle state
            atPointA = !atPointA;
            isMoving = false;
        }

        /* private System.Collections.IEnumerator ReverseMovePlatform()
         {
             isMoving = true;
             float elapsed = 0.0f;

             Vector3 direction = Vector3.left;
             Vector3 otherDrection = Vector3.up;

             while (elapsed < othermoveTime)
             {
                 this.transform.Translate(otherDrection * Time.deltaTime / 5);
                 elapsed += Time.deltaTime;
                 yield return null;
             }

             while (elapsed < moveTime)
             {
                 movingPlatform.transform.Translate(direction * moveSpeed * Time.deltaTime);
                 elapsed += Time.deltaTime;
                 yield return null;
             }
             isMoving = false;
         }*/
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
