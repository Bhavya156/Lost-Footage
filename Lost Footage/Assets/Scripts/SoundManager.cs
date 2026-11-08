using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Mixer")]
    public AudioMixer master;
    private bool isMuted = false;
    private float currentMusicVolume = 1f;
    private float currentSFXVolume = 1f;
    private float currentUISFXVolume = 1f;
    public float GetMusicVolume() => currentMusicVolume;
    public float GetSFXVolume() => currentSFXVolume;
    public float GetUISFXVolume() => currentUISFXVolume;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void LoadPreferences()
    {
        currentMusicVolume = PlayerPrefs.GetFloat(StringContainer.PrefsMusic, 1f);
        currentSFXVolume = PlayerPrefs.GetFloat(StringContainer.PrefsSFX, 1f);
        currentUISFXVolume = PlayerPrefs.GetFloat(StringContainer.PrefsSFX, 1f);
    }

    void SavePreferences()
    {
        PlayerPrefs.SetFloat(StringContainer.PrefsMusic, currentMusicVolume);
        PlayerPrefs.SetFloat(StringContainer.PrefsSFX, currentSFXVolume);
        PlayerPrefs.SetFloat(StringContainer.PresUISFX, currentUISFXVolume);
        PlayerPrefs.Save();
    }

    // Convert slider(0-1) to Mixer dB
    float SliderToDb(float value)
    {
        return Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
    }

    public void OnMusicVolumeChanged(float value)
    {
        currentMusicVolume = Mathf.Clamp01(value);

        // // If user moves slider while muted → unmute
        // if (isMuted)
        // {
        //     isMuted = false;
        // }

        ApplyVolumeToMixer();
        SavePreferences();
    }

    public void OnSFXVolumeChanged(float value)
    {
        currentSFXVolume = Mathf.Clamp01(value);

        // if (isMuted)
        // {
        //     isMuted = false;
        // }

        ApplyVolumeToMixer();
        SavePreferences();
    }

    public void OnUISFXVolumeChanged(float value)
    {
        currentSFXVolume = Mathf.Clamp01(value);

        // if (isMuted)
        // {
        //     isMuted = false;
        // }

        ApplyVolumeToMixer();
        SavePreferences();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        ApplyVolumeToMixer();
        SavePreferences();
    }

    public void ApplyVolumeToMixer()
    {
        if (isMuted)
        {
            master.SetFloat("Music", -80f);
            master.SetFloat("SFX", -80f);
            master.SetFloat("UISFX", -80f);
            return;
        }

        master.SetFloat("Music", SliderToDb(currentMusicVolume));
        master.SetFloat("SFX", SliderToDb(currentSFXVolume));
        master.SetFloat("UISFX", SliderToDb(currentUISFXVolume));
    }

    // public void OnMutePressed(bool _)
    // {
    //     ToggleMute();
    // }

    public void SetMusicSliderValue(Slider musicSlider, float value)
    {
        musicSlider.SetValueWithoutNotify(value);
    }

    public void SetSFXSliderValue(Slider sfxSlider, float value)
    {
        sfxSlider.SetValueWithoutNotify(value);
    }

    public void SetUISFXSliderValue(Slider uiSfxSlider, float value)
    {
        uiSfxSlider.SetValueWithoutNotify(value);
    }

    public void SetVolumePreferences(Slider musicSlider, Slider sfxSlider, Slider uiSfxSlider)
    {
        // Set slider values without triggering callbacks
        musicSlider.SetValueWithoutNotify(GetMusicVolume());
        sfxSlider.SetValueWithoutNotify(GetSFXVolume());
        uiSfxSlider.SetValueWithoutNotify(GetUISFXVolume());
        // muteBtn.SetIsOnWithoutNotify(IsMuted());

        // Add listeners
        musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
        uiSfxSlider.onValueChanged.AddListener(OnUISFXVolumeChanged);
        // muteBtn.onValueChanged.AddListener(OnMutePressed);
    }

    public void RemoveSliderListeners(Slider musicSlider, Slider sfxSlider, Slider uiSfxSlider)
    {
        if (musicSlider != null) musicSlider.onValueChanged.RemoveListener(OnMusicVolumeChanged);
        if (sfxSlider != null) sfxSlider.onValueChanged.RemoveListener(OnSFXVolumeChanged);
        if (uiSfxSlider != null) sfxSlider.onValueChanged.RemoveListener(OnSFXVolumeChanged);
        // if (muteBtn != null) muteBtn.onValueChanged.RemoveListener(OnMutePressed);
    }
}
