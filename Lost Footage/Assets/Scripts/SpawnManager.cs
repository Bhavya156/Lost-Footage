using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public ScriptableClass scriptableObject;
    public List<Interactable> interactablesInRange = new List<Interactable>();

    public viewChecker viewChecker;

    void Start()
    {
        for (int i = 0; i < scriptableObject.countToSpawn; i++)
        {
            SpawnInteractable(scriptableObject);
        }
    }

    int index = 0;

    void SpawnInteractable(ScriptableClass scriptableObject)
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(scriptableObject.spawnPosition.x - 5f, scriptableObject.spawnPosition.x + 3f), // X position range
            scriptableObject.spawnPosition.y, // Y position from ScriptableObject
            Random.Range(-scriptableObject.spawnPosition.z - 5f, scriptableObject.spawnPosition.z + 3f) // Z position range
        );
        GameObject spawnedInteractable = Instantiate(scriptableObject.interactableObject, spawnPosition, Quaternion.identity);
        spawnedInteractable.name = scriptableObject.interactableName + "_" + index;
        Targets newTarget = viewChecker.targetsToCheck.Find(x => x.articleNo == 1);

        if (newTarget != null)
        {
            newTarget.targetObjects.Add(spawnedInteractable);
        }
        interactablesInRange.Add(new Interactable
        {
            id = index,
            interactableName = scriptableObject.interactableName + "_" + index,
            interactableObject = spawnedInteractable,
            interactionUIgameObject = spawnedInteractable.transform.Find("UI").gameObject,
            dialogueField = spawnedInteractable.transform.Find("UI/Background/DialogueText").GetComponent<TextMeshProUGUI>(),
            snappedText = scriptableObject.interactableDialogue,
        });
        index++;
    }
}


[Serializable]
public class Interactable
{
    public int id;
    public string interactableName;
    public GameObject interactableObject;
    public GameObject interactionUIgameObject;
    public TextMeshProUGUI dialogueField;
    public string snappedText;
}