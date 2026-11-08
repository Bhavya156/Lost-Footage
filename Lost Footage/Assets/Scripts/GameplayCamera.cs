using UnityEngine;

public class GameplayCamera : MonoBehaviour
{

    bool inPlay;
    MeshRenderer mr;
    Rigidbody rb;
    [SerializeField] Transform cameraDeployer;
    [SerializeField] CameraMover cameraMover;
    [SerializeField] Camera handicam;
    [SerializeField] private Animator playerAnim;

    bool thrown;
    float timer;
    [SerializeField] float timeToDespawn;
    [SerializeField] float throwingForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();

        handicam.gameObject.SetActive(false);

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
                    playerAnim.SetBool("Grab", true);
                    handicam.gameObject.SetActive(true);
                    mr.enabled = true;
                    cameraMover.enabled = true;
                    inPlay = true;
                    transform.position = cameraDeployer.position + Vector3.down;
                    rb.linearVelocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
                else
                {
                    thrown = true;
                    rb.AddForce(new Vector3(0, 0.8f, Random.Range(-2f, 2f)) * throwingForce);
                    cameraMover.enabled = false;
                    playerAnim.SetBool("Grab", false);
                    handicam.gameObject.SetActive(false);
                }
            }
        }

        if (thrown)
        {

            timer += Time.deltaTime;

            if (timer > timeToDespawn)
            {
                mr.enabled = false;
                timer = 0;
                thrown = false;
                inPlay = false;
            }
        }

        if (inPlay && !thrown && Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameManager.Instance.TakenPhoto(handicam);
        }
    }
}
