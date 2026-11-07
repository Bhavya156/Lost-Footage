using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TypewriterEffect typewriter;
    [SerializeField] private SceneChanger sceneChanger;
    [SerializeField] private AudioSource typewriterAudio;

    public GameObject loadingUI;
    string[] testLines = { "This is the boss talking, SUPER MR PENGUIN THE GREAT GOD OF JUSTICE", "You have to bring your footage AND BRING ME MORE MEIN KAMPTFS", "Otherwise you are FIRED! AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" };
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
        loadingUI.SetActive(false);
    }

}
