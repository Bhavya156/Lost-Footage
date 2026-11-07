using UnityEngine;

public class ActualCarController : MonoBehaviour
{

    public bool playerDriving;

    public GameObject character;
    public Collider playerCollider;
    public Transform seat;
    public Rigidbody rb;

    public float drivingForce;
    public float steeringForce;
    public Transform steeringPoint;

    public float sidewaysFriction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDriving)
        {
            playerCollider.enabled = false;
            character.transform.position = seat.position;

            if (Input.GetKey(KeyCode.W)) rb.AddForce(rb.transform.forward * drivingForce);
            if (Input.GetKey(KeyCode.S)) rb.AddForce(-rb.transform.forward * drivingForce);
            if (Input.GetKey(KeyCode.A)) rb.AddForceAtPosition(-rb.transform.right * steeringForce, steeringPoint.position);
            if (Input.GetKey(KeyCode.D)) rb.AddForceAtPosition(rb.transform.right * steeringForce, steeringPoint.position);

            rb.AddForce(-rb.transform.right * Vector3.Dot(rb.linearVelocity, rb.transform.right) * sidewaysFriction);
            //character.transform.rotation += rb.angularVelocity
        }
    }
}
