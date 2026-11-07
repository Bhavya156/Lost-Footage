using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TypewriterEffect typewriter;
    [SerializeField] private SceneChanger sceneChanger;
    [SerializeField] private AudioSource typewriterAudio;

    public GameObject loadingUI;
    string[] testLines = { "Where is the footage you were supposed to bring for the next online report?", "I trust that you have kept it safe.", "You’re lucky I even give you the time of day!", "You have one hour to get it on my desk!", "or else, YOU'RE FIRED!" };
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
            typewriterAudio.Play();
            clickToNext(testLines);
            index++;
            if (index > testLines.Length)
            {
                loadingUI.SetActive(true);
                StartCoroutine(sceneChanger.LoadNextLevel());
            }
        }
    }

    private void Start()
    {

        typewriter.ShowText(testLines[0]);
        typewriterAudio.Play();
        index++;
        loadingUI.SetActive(false);
    }

}
