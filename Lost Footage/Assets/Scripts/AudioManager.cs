using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // SoundManager.Instance.LoadPreferences();
        // SoundManager.Instance.ApplyVolumeToMixer();
    }

    void Start()
    {
        // Sync UI if UIManager exists
        if (UiManager.Instance != null)
        {
            var ui = UiManager.Instance;
            SoundManager.Instance.SetMusicSliderValue(ui.musicSlider, currentMusicVolume);
            SoundManager.Instance.SetSFXSliderValue(ui.sfxSlider, currentSFXVolume);
            SoundManager.Instance.SetUISFXSliderValue(ui.uiSfxSlider, currentUISFXVolume);
        }
    }

    [Header("Audio Mixer")]
    public AudioMixer master;

    public AudioSource bgmSource;
    public AudioSource sfxSource;
    public AudioSource uiSfxSource;

    public AudioClip typewriterClip;
    public AudioClip uiSFXClip;
    public AudioClip btnHoverClip;
    public AudioClip cat_angry;
    public AudioClip cat_meow;
    public AudioClip footsteps;
    public AudioClip explosion;
    public AudioClip fireEffect;
    public AudioClip pickup;
    public AudioClip cameraClick;
    public AudioClip wrongBuzz;

    private float currentMusicVolume = 1f;
    private float currentSFXVolume = 1f;
    private float currentUISFXVolume = 1f;

    public float GetMusicVolume() => currentMusicVolume;
    public float GetSFXVolume() => currentSFXVolume;
    public float GetUISFXVolume() => currentUISFXVolume;

    public void PlayTypeWriterAudio()
    {
        sfxSource.clip = typewriterClip;
        sfxSource.Play();
    }

    public void StopAudio(AudioSource src)
    {
        src.Stop();
    }

    public void ChangeVolume(AudioSource src, float val)
    {
        src.volume = val;
    }

    public void OnBtnClickAudio()
    {
        uiSfxSource.PlayOneShot(uiSFXClip);
    }

    public void OnBtnHoverAudio()
    {
        uiSfxSource.PlayOneShot(btnHoverClip);
    }

    public void PlayBGM(AudioClip clip)
    {
        bgmSource.clip = clip;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null) sfxSource.PlayOneShot(clip);
        else Debug.Log("clip nooot found");
    }

    public void PlaySound(AudioSource src, AudioClip clip)
    {
        src.PlayOneShot(clip);
    }
}
