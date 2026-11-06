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

    private void Update()
    {
        if (isInside && Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {


            if (target != null)// && target.transform.parent != holdPoint)
            {
                //target.transform.SetParent(holdPoint);
                //target.transform.localPosition = Vector3.zero;
                //target.GetComponent<Rigidbody>().isKinematic = true;

                Debug.Log("YEAH!");
                isSnapping = true;
                grabbedObject = target;
                grabbedRB = targetRB;
            }
        }
        else if (Input.GetMouseButtonDown(1))// && target != null && target.transform.parent == holdPoint)
        {
            
            //Rigidbody rb = target.GetComponent<Rigidbody>();
            //rb.isKinematic = false;
            isSnapping = false;
            grabbedRB.AddForce(transform.forward * throwForce, ForceMode.Impulse);
            //target.transform.SetParent(null);
        }

        if (isSnapping)
        {
            grabbedRB.AddForce(snapForce * (holdPoint.position - grabbedObject.transform.position).normalized);
            //grabbedRB.AddForce(-grabbedRB.linearVelocity / grabbedObjectDamping);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            isInside = true;
            target = other.gameObject;
            targetRB = target.GetComponent<Rigidbody>();

            Debug.Log(other.name);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            isInside = false;
            if (target == other.gameObject) { target = null; targetRB = null; }
        }
    }
}
