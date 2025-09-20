using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class Pickup : MonoBehaviour
{
    bool isholding = false;

    [SerializeField]
    float throwForce = 600f;
    [SerializeField]
    float maxDistance = 3f;
    float distance;

    TempParent tempParent;
    Rigidbody rb;

    Vector3 objectPos;
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
        if (tempParent != null)
        {
            isholding = true;
            rb.useGravity = false;
            rb.detectCollisions = false;

            this.transform.SetParent(tempParent.transform);
        }
        else
        {
            Debug.Log("Uh oh");
        }
    }

    private void OnMouseUp()
    {
        //drop
    }

    private void OnMouseExit()
    {
        //drop
    }

    private void Hold()
    {

    }
}
