using System.Collections.Generic;
using UnityEngine;

public class ScanInteractables : MonoBehaviour
{
    public GameObject interactionUIprefab;
    public List<GameObject> interactablesInRange = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            interactablesInRange.Add(other.gameObject);
            InstantiateAndEnableUI(other.gameObject);
        }
    }

    void InstantiateAndEnableUI(GameObject interactable)
    {
        GameObject uiInstance = Instantiate(interactionUIprefab, interactable.transform);
        uiInstance.transform.position = interactable.transform.position + new Vector3(0, 1.5f, 0);
        uiInstance.transform.rotation = interactable.transform.rotation;
        uiInstance.SetActive(true);
    }

    void DisableAndDestroyUI(GameObject interactable)
    {
        Transform uiTransform = interactable.transform.Find(interactionUIprefab.name + "(Clone)");
        Debug.Log("Disabling and destroying UI for " + interactionUIprefab.name);
        if (uiTransform != null)
        {
            GameObject uiInstance = uiTransform.gameObject;
            uiInstance.SetActive(false);
            Destroy(uiInstance);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            interactablesInRange.Remove(other.gameObject);
            DisableAndDestroyUI(other.gameObject);
            Debug.Log(other.name + " removed from list");
        }
    }
}
