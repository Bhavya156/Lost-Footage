using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class Interactable
{
    public int id;
    public GameObject interactableObject;
    public GameObject interactionUI;
}
public class ScanInteractables : MonoBehaviour
{
    public GameObject interactionUIprefab;
    public List<Interactable> interactablesInRange = new List<Interactable>();

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            // interactablesInRange.Add(other.gameObject);
            // InstantiateAndEnableUI(other.gameObject);

        }
    }

    void InstantiateAndEnableUI(GameObject interactable)
    {
        GameObject uiInstance;
        if (interactable.transform.Find(interactionUIprefab.name + "(Clone)") != null)
        {
            uiInstance = interactable.transform.Find(interactionUIprefab.name + "(Clone)").gameObject;
            Debug.Log("UI already exists for " + interactable.name);
            uiInstance.SetActive(true);
        }
        else
        {
            uiInstance = Instantiate(interactionUIprefab); //, interactable.transform);
            uiInstance.transform.position = interactable.transform.position + new Vector3(0, 1.5f, 0);
            uiInstance.transform.rotation = interactable.transform.rotation;
            uiInstance.SetActive(true);
        }
    }

    void DisableAndDestroyUI(GameObject interactable)
    {
        Transform uiTransform = interactable.transform.Find(interactionUIprefab.name + "(Clone)");
        Debug.Log("Disabling and destroying UI for " + interactionUIprefab.name);
        if (uiTransform != null)
        {
            GameObject uiInstance = uiTransform.gameObject;
            uiInstance.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            // interactablesInRange.Remove(other.gameObject);
            DisableAndDestroyUI(other.gameObject);
            Debug.Log(other.name + " removed from list");
        }
    }
}
