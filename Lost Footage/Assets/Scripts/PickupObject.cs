using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public GameObject player;
    public Transform holdPoint;

    [SerializeField] private GameObject target;
    private Rigidbody targetRB;
    private bool isInside;

    [SerializeField] private GameObject grabbedObject;
    private Rigidbody grabbedRB;
    private bool isSnapping;

    [SerializeField] float throwForce;
    [SerializeField] float snapForce;
    [SerializeField] float grabbedObjectDamping;

    [SerializeField] private ScanInteractables scanInteractables;
    [SerializeField] private Animator playerAnimator;

    // void Start()
    // {
    //     if (grabbedObject != null) grabbedObject = null;
    //     isSnapping = false;
    // }

    private void Update()
    {
        if (isInside && Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {


            if (target != null)// && target.transform.parent != holdPoint)
            {
                playerAnimator.SetBool("Grab", true);
                //target.transform.SetParent(holdPoint);
                //target.transform.localPosition = Vector3.zero;
                //target.GetComponent<Rigidbody>().isKinematic = true;
                isSnapping = true;
                grabbedObject = target;
                grabbedRB = targetRB;

                // Disable UI

                // Transform uiTransform = grabbedObject.transform.Find("UI(Clone)");
                // if (uiTransform != null)
                // {
                //     GameObject uiInstance = uiTransform.gameObject;
                //     uiInstance.SetActive(false);
                //     Destroy(uiInstance);
                // }
                scanInteractables.DisableUI(grabbedObject);

                //if(grabbedObject.GetComponentInChildren<ParticleSystem>() != null)
                //{
                //    grabbedObject.GetComponentInChildren<ParticleSystem>().Play();
                //}
                
            }
        }
        else if (Input.GetMouseButtonDown(1) && grabbedObject != null)// && target != null && target.transform.parent == holdPoint)
        {

            //Rigidbody rb = target.GetComponent<Rigidbody>();
            //rb.isKinematic = false;
            //if (grabbedObject.GetComponentInChildren<ParticleSystem>() != null)
            //{
            //    grabbedObject.GetComponentInChildren<ParticleSystem>().Stop();
            //}

            if (grabbedObject.gameObject.name == "jetMissile") grabbedObject.GetComponent<MissileScript>().FireMissile();

            isSnapping = false;
            grabbedRB.AddForce(transform.forward * throwForce, ForceMode.Impulse);
            grabbedObject = null;
            grabbedRB = null;

            playerAnimator.SetBool("Grab", false);
            //target.transform.SetParent(null);
        }

    }

    private void FixedUpdate()
    {
        if (isSnapping && grabbedObject != null)
        {
            grabbedRB.AddForce(snapForce * (holdPoint.position - grabbedObject.transform.position).normalized);
            grabbedRB.AddForce(-grabbedRB.linearVelocity * grabbedObjectDamping);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable") || other.CompareTag("Cat"))
        {
            isInside = true;
            target = other.gameObject;
            targetRB = target.GetComponent<Rigidbody>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable") || other.CompareTag("Cat"))
        {
            isInside = false;
            if (target == other.gameObject) { target = null; targetRB = null; }
        }
    }
}
