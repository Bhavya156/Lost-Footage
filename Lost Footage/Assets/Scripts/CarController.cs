using UnityEngine;

public class CarController : MonoBehaviour
{

    public Transform target;
    public Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(4000 * (target.position - transform.position) * Time.deltaTime);
        rb.AddForce(-rb.linearVelocity * 0.5f);
    }
}
