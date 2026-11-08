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

        pictureDisplayStartPos = pictureDisplay.rectTransform.localPosition;
        pictureDisplayStartRot = pictureDisplay.rectTransform.eulerAngles;
        articleTFStart = ArticleTF.localPosition;
    }
    int index = 0;

    [SerializeField] private TypewriterEffect typewriterEffect;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject audioPanel;

    public RawImage pictureDisplay;
    public Vector3 pictureDisplayStartPos;
    public Vector3 pictureDisplayStartRot;
    public RectTransform pictureDisplayTargetPos;
    bool displayingImage;
    float displayingImageTimer;

    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider uiSfxSlider;

    public RectTransform ArticleTF;
    Vector3 articleTFStart;

    string[] gamedialogues = { "Oh no! I lost all the footage from the past few days.", "I have to to somehow get it back!", "Recreate the events displayed on top of the screen and then take a picture.", "Press [C] to have the camera online" };

    private void clickToNext(string[] lines)
    {
        if (index < lines.Length)
        {
            typewriterEffect.ShowText(gamedialogues[index]);
        }
    }

    public void DisplayImage(RenderTexture picture)
    {
        pictureDisplay.texture = picture;
        pictureDisplay.gameObject.SetActive(true);
        displayingImage = true;
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

        if (displayingImage)
        {
            AnimateImage();
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

    public void OpenAudioPanel()
    {
        // AudioManager.Instance.OnBtnClickAudio();
        optionsPanel.SetActive(false);
        audioPanel.SetActive(true);
    }

    public void CloseAudioPanel()
    {
        // AudioManager.Instance.OnBtnClickAudio();
        audioPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void MainMenuBtn()
    {
        // AudioManager.Instance.OnBtnClickAudio();
        Time.timeScale = 1f;
        CursorLockState(0);
        SceneChanger.Instance.LoadGameScene(0);
    }

    public void AnimateImage()
    {
        displayingImageTimer += Time.deltaTime;

        //pictures flies in
        if(displayingImageTimer > 1f && displayingImageTimer < 3f)
        {
            pictureDisplay.rectTransform.localPosition = pictureDisplayStartPos - (pictureDisplayStartPos * ((displayingImageTimer - 1f) / 2f));

            pictureDisplay.rectTransform.eulerAngles = pictureDisplayStartRot + (pictureDisplayTargetPos.eulerAngles - pictureDisplayStartRot) * ((displayingImageTimer - 1f) / 2f);

            pictureDisplay.rectTransform.localScale = (Vector3.one * 2.5f) - Vector3.one * (((displayingImageTimer - 1) / 2) * 1.5f);
        }
        //article disappears
        else if (displayingImageTimer > 4f && displayingImageTimer < 5f)
        {
            ArticleTF.localPosition = articleTFStart - new Vector3(400 * (displayingImageTimer - 4f), 0, 0);
        }
        //article reappears
        else if(displayingImageTimer > 5f && displayingImageTimer < 6f)
        {
            ArticleTF.localPosition = articleTFStart - new Vector3(400, 0, 0) + new Vector3(400 * (displayingImageTimer - 5f), 0, 0);
        }
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
