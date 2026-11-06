using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public GameObject player;
    public Transform holdPoint;

    private GameObject target;
    private bool isInside;

    private void Update()
    {
        if (isInside && Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            if (target != null && target.transform.parent != holdPoint)
            {
                target.transform.SetParent(holdPoint);
                target.transform.localPosition = Vector3.zero;
                target.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        else if (Input.GetMouseButtonDown(1) && target != null && target.transform.parent == holdPoint)
        {
            
            Rigidbody rb = target.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
            target.transform.SetParent(null);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            isInside = true;
            target = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            isInside = false;
            if (target == other.gameObject) target = null;
        }
    }
}
