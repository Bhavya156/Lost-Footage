using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TypewriterEffect typewriter;

    string[] testLines = { "This is the boss talking", "You have to bring your footage", "Otherwise you are FIRED!" };
    int index = 0;
    private void clickToNext(string[] lines)
    {
        if (index < testLines.Length)
        {
            typewriter.ShowText(testLines[index]);
        }
    }

    private void Update()
    {
        //StartDialogue(testLines);
        if (Input.GetMouseButtonDown(0))
        {
            clickToNext(testLines);
            index++;
        }

    }


}