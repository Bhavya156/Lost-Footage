using TMPro;
using UnityEngine;


public class ScanInteractables : MonoBehaviour
{
    public GameObject interactionUIprefab;

    public SpawnManager spawnManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable") || other.CompareTag("Cat"))
        {
            EnableUI(other.gameObject);
        }
    }

    GameObject uiInstance;
    public void EnableUI(GameObject interactable)
    {
        //Find the interactable in the list and enable its UI
        if (interactable.transform.Find("UI") != null)
        {
            interactable.transform.Find("UI").gameObject.SetActive(true);
        }
    }

    void Update()
    {
        foreach (Interactable interactableInList in spawnManager.interactablesInRange)
        {
            if (interactableInList.interactionUIgameObject != null &&
                interactableInList.interactionUIgameObject.activeInHierarchy)
            {
                interactableInList.interactionUIgameObject.transform.position =
                    interactableInList.interactableObject.transform.position
                    + new Vector3(0, 1.5f, 0);
            }
        }
    }

    public void ChangeDialogueText(GameObject interactable)
    {
       for (int i = 0; i < spawnManager.interactablesInRange.Count; i++)
        {
            if (interactable.name.Contains(spawnManager.interactablesInRange[i].id.ToString()))
            {
                spawnManager.interactablesInRange[i].dialogueField.text =
                    spawnManager.interactablesInRange[i].snappedText;
            }
        }
    }


    public void DisableUI(GameObject interactable)
    {
        if (interactable.transform.Find("UI") != null)
        {
            interactable.transform.Find("UI").gameObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable") || other.CompareTag("Cat"))
        {
            DisableUI(other.gameObject);
        }
    }
}
