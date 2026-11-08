using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField] private GameObject pausePanel;

    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider uiSfxSlider;

    string[] gamedialogues = { "Oh no! I lost all the footage from the past few days.", "I have to to somehow get it back!", "Recreate the events displayed on top of the screen and then take a picture.", "Press [C] to have the camera online" };

    private void clickToNext(string[] lines)
    {
        if (index < lines.Length)
        {
            typewriterEffect.ShowText(gamedialogues[index]);
        }
    }

    public bool isPaused;

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

        if (isPaused && Cursor.lockState != CursorLockMode.None)
        {
            CursorLockState(1);
        }
    }

    public void SettingsBtn()
    {
        // AudioManager.Instance.OnBtnClickAudio();
        Time.timeScale = 0f;
        isPaused = true;
        pausePanel.SetActive(true);
    }
    public void ResumeBtn()
    {
        // AudioManager.Instance.OnBtnClickAudio();
        Time.timeScale = 1f;
        isPaused = false;
        pausePanel.SetActive(false);
        CursorLockState(0);
    }

    public void RestartBtn()
    {
        // AudioManager.Instance.OnBtnClickAudio();
        Time.timeScale = 1f;
        CursorLockState(0);
        SceneChanger.Instance.LoadGameScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuBtn()
    {
        // AudioManager.Instance.OnBtnClickAudio();
        Time.timeScale = 1f;
        CursorLockState(0);
        SceneChanger.Instance.LoadGameScene(0);
    }

    void CursorLockState(int state)
    {
        switch (state)
        {
            case 0:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
            case 1:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            default:
                break;
        }
    }
}
