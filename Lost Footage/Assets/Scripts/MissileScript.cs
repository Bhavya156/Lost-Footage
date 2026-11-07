using UnityEngine;

public class MissileScript : MonoBehaviour
{

    public ParticleSystem jetEngine;
    public GameObject explosionPrefab;

    public bool isRunning;
    public float engineForce;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            rb.AddForce(rb.transform.right * engineForce);
        }
    }

    void FixedUpdate()
    {
        Vector3 fwd = transform.right;

        if (Physics.Raycast(transform.position, fwd, 3))
        {
            Instantiate(explosionPrefab);
            Destroy(gameObject);
        }
            
    }

    public void FireMissile()
    {
        jetEngine.Play();
        isRunning = true;
    }
}
