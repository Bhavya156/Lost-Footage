using NUnit.Framework;
using UnityEngine;

public class Snapping : MonoBehaviour
{

    Rigidbody otherRB;
    bool isSnapped;
    public ScanInteractables scanInteractables;

    private void Start()
    {
        if (scanInteractables == null)
        {
            scanInteractables = FindAnyObjectByType<ScanInteractables>();
        }
    }

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
        else if (other.CompareTag("Cat"))
        {
            if (other.GetComponent<Rigidbody>() != null)
            {

                otherRB = other.GetComponent<Rigidbody>();
                isSnapped = true;
            }

            GameManager.Instance.catInTree = true;
            GameManager.Instance.targetCat = otherRB.gameObject;
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
                scanInteractables.DisableUI2(otherRB.gameObject);
                scanInteractables.ChangeDialogueText(otherRB.gameObject);
                
                isUIEnabled = true;
            }
        }
    }
}
