using TMPro;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TypewriterEffect : MonoBehaviour
{
    [Tooltip("Characters revealed per second")]
    [SerializeField] private float charactersPerSecond = 20f;

    [SerializeField] private AudioSource typewriterSound;
    [SerializeField] private AudioSource backgroundSound;

    private TextMeshProUGUI _textComponent;
    private Coroutine _typingCoroutine;

    private void Awake()
    {
        _textComponent = GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Reveals the given text with a typewriter effect.
    /// Call this to start a new line of dialogue.
    /// </summary>
    public void ShowText(string text)
    {
        // Stop any existing typing before starting a new one
        if (_typingCoroutine != null)
            StopCoroutine(_typingCoroutine);

        // set the entire text once, but make it hidden
        _textComponent.text = text;
        _textComponent.maxVisibleCharacters = 0;

        // Force TMP to parse the text and compute character count
        _textComponent.ForceMeshUpdate(); // might not be necessary in all cases

        _typingCoroutine = StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        int totalCharacters = _textComponent.textInfo.characterCount;
        float delay = 1f / charactersPerSecond;

        backgroundSound.volume = 0.1f;

        for (int i = 0; i < totalCharacters; i++)
        {
            _textComponent.maxVisibleCharacters = i + 1;
            yield return new WaitForSeconds(delay);
        }

        // Ensure everything is visible at the end
        _textComponent.maxVisibleCharacters = totalCharacters;
        _typingCoroutine = null;
        typewriterSound.Stop();
        backgroundSound.volume = 0.5f;
    }

    /// <summary>
    /// Immediately shows all text (useful for a "skip" input).
    /// </summary>
    public void SkipToEnd()
    {
        if (_typingCoroutine != null)
        {
            StopCoroutine(_typingCoroutine);
            _typingCoroutine = null;
        }
        _textComponent.ForceMeshUpdate();
        _textComponent.maxVisibleCharacters = _textComponent.textInfo.characterCount;
    }

    public bool IsTyping => _typingCoroutine != null;
}

