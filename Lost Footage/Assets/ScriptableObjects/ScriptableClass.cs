using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableClass", menuName = "Scriptable Objects/ScriptableClass")]
public class ScriptableClass : ScriptableObject
{
    public GameObject interactableObject;
    public Vector3 spawnPosition;
    public int countToSpawn;
    public string interactableName;
    public string interactableDialogue;
    // public Sprite gifImage;
}
