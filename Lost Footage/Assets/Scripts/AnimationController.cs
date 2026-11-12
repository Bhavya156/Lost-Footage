using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static AnimationController Instance;

    [Header("Animators")]
    public Animator playerAnimator;
    public float grabAnimationDuration = 0.5f;
    public AnimationClip grabAnimClip;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void PlayPlayerAnim(float speed)
    {
        playerAnimator.SetFloat("Speed", speed);
    }

    public void PlayGrabAnim()
    {
        playerAnimator.SetTrigger("Grab");
    }

    public void PlayThrowAnim()
    {
        playerAnimator.SetTrigger("Throw");
    }

    public void PlayHoldingAnim(bool setState)
    {
        playerAnimator.SetBool("Holding", setState);
    }
}
