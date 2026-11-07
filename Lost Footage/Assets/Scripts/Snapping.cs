using UnityEngine;

public class Snapping : MonoBehaviour
{

    Rigidbody otherRB;
    bool isSnapped;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            if (other.GetComponent<Rigidbody>() != null)
            {

                otherRB = other.GetComponent<Rigidbody>();
                isSnapped = true;

                //other.transform.SetParent(transform);
                // other.transform.localPosition = Vector3.zero;
                //other.GetComponent<Rigidbody>().isKinematic = true;
                Debug.Log("Snapped Object");
            }
        }
    }

    void Update()
    {
        if (isSnapped)
        {
            otherRB.AddForce(1500 * (transform.position - otherRB.position) * Time.deltaTime);
            otherRB.AddForce(-otherRB.linearVelocity * 0.5f);
        }
    }
}
