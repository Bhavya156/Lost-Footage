using UnityEngine;

public class CameraMover : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    [SerializeField] Transform holdPoint;
    [SerializeField] float snapForce;
    [SerializeField] float moveDamping;
    [SerializeField] Camera attachedCamera;

    void Start()
    {
        if(rb == null) rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(snapForce * (holdPoint.position - transform.position) * Time.deltaTime);
        rb.AddForce(-rb.linearVelocity * moveDamping);

        rb.rotation = holdPoint.rotation;
    }
}
