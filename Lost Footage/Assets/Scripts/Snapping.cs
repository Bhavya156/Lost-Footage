using UnityEngine;

public class Snapping : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            if (other.GetComponent<Rigidbody>() != null)
            {
                other.transform.SetParent(transform);
                // other.transform.localPosition = Vector3.zero;
                other.GetComponent<Rigidbody>().isKinematic = true;
                Debug.Log("Snapped Object");
            }
        }
    }
}
