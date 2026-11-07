using UnityEngine;

public class GameplayCamera : MonoBehaviour
{

    bool inPlay;
    MeshRenderer mr;
    Rigidbody rb;
    [SerializeField] Transform cameraDeployer;
    [SerializeField] CameraMover cameraMover;

    bool thrown;
    float timer;
    [SerializeField] float timeToDespawn;
    [SerializeField] float throwingForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();

        inPlay = false;
        mr.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!thrown)
            {
                if (!inPlay)
                {
                    mr.enabled = true;
                    cameraMover.enabled = true;
                    inPlay = true;
                    transform.position = cameraDeployer.position + Vector3.down;
                    rb.linearVelocity = Vector3.zero;
                }
                else
                {
                    thrown = true;
                    rb.AddForce(new Vector3(0, 0.8f, Random.Range(-2f, 2f)) * throwingForce);
                    cameraMover.enabled = false;
                }
            }
        }

        if (thrown)
        {

            timer += Time.deltaTime;

            if(timer > timeToDespawn)
            {
                mr.enabled = false;
                timer = 0;
                thrown = false;
                inPlay = false;
            }
        }
    }
}
