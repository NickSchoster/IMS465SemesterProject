using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class Pickup : MonoBehaviour
{
    public bool isholding = false;

    [SerializeField]
    float throwForce = 600f;
    [SerializeField]
    float maxDistance = 3f;
    float distance;

    TempParent tempParent;
    Rigidbody rb;

    Vector3 objectPos;

    public PlatformTrigger platformTrigger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tempParent = TempParent.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (isholding)
        {
            Hold();
        }
    }

    private void OnMouseDown()
    {
        //pickup
        if (platformTrigger != null && platformTrigger.isMoving == false)
        {
            if (tempParent != null)
            {
                distance = Vector3.Distance(this.transform.position, tempParent.transform.position);
                if (distance <= maxDistance)
                {

                    isholding = true;
                    rb.useGravity = false;
                    rb.detectCollisions = true;

                    this.transform.SetParent(tempParent.transform);
                }
            }
        }
        else
        {
            Debug.Log("Uh oh");
        }
    }

    private void OnMouseUp()
    {
        Drop();
    }

    private void OnMouseExit()
    {
        Drop();
    }

    private void Hold()
    {
        distance = Vector3.Distance(this.transform.position, tempParent.transform.position);
        if (distance >= maxDistance)
        {
            Drop();
        }

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

        if (Input.GetMouseButtonDown(1))
        {
            rb.AddForce(tempParent.transform.forward * throwForce);
            Drop();
        }
    }

    private void Drop()
    {
        if (isholding)
        {
            isholding = false;
            objectPos = this.transform.position;
            this.transform.position = objectPos;
            this.transform.SetParent(null);
            rb.useGravity = true;
        }
    }
}
