using UnityEngine;

public class Snapping : MonoBehaviour
{

    Rigidbody otherRB;
    bool isSnapped;
    public ScanInteractables scanInteractables;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            if (other.GetComponent<Rigidbody>() != null)
            {

                otherRB = other.GetComponent<Rigidbody>();
                isSnapped = true;
            }
        }
    }

    bool isUIEnabled = false;

    void Update()
    {
        if (isSnapped)
        {
            otherRB.AddForce(1500 * (transform.position - otherRB.position) * Time.deltaTime);
            otherRB.AddForce(-otherRB.linearVelocity * 0.5f);
            if (!isUIEnabled)
            {
                scanInteractables.EnableUI(otherRB.gameObject);
                scanInteractables.ChangeDialogueText(otherRB.gameObject);
                isUIEnabled = true;
            }
        }
    }
}
