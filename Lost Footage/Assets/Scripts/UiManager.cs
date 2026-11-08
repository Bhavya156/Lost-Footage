using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        typewriterEffect.ShowText(gamedialogues[0]);
        AudioManager.Instance.PlayTypeWriterAudio();
        index++;
    }
    int index = 0;

    [SerializeField] private TypewriterEffect typewriterEffect;
    [SerializeField] private GameObject dialogueBox;

    string[] gamedialogues = { "Oh no! I lost all the footage from the past few days.", "I have to to somehow get it back!", "Recreate the events displayed on top of the screen and then take a picture.", "Press [C] to have the camera online" };

    private void clickToNext(string[] lines)
    {
        if (index < lines.Length)
        {
            typewriterEffect.ShowText(gamedialogues[index]);
        }
    }

    bool isPaused;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.Instance.PlayTypeWriterAudio();
            clickToNext(gamedialogues);
            index++;
        }

        if (index > gamedialogues.Length)
        {
            dialogueBox.SetActive(false);
            AudioManager.Instance.StopAudio(AudioManager.Instance.sfxSource);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            SettingsBtn();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            ResumeBtn();
        }
    }

    public void SettingsBtn()
    {
        AudioManager.Instance.OnBtnClickAudio();
        Time.timeScale = 0f;
        isPaused = true;
        // pausePanel.SetActive(true);
    }
    public void ResumeBtn()
    {
        AudioManager.Instance.OnBtnClickAudio();
        Time.timeScale = 1f;
        isPaused = false;
        // pausePanel.SetActive(false);
    }

    public void RestartBtn()
    {
        AudioManager.Instance.OnBtnClickAudio();
        Time.timeScale = 1f;
        // SceneLoader.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuBtn()
    {
        AudioManager.Instance.OnBtnClickAudio();
        Time.timeScale = 1f;
        // SceneLoader.Instance.LoadScene(0);
    }
}
