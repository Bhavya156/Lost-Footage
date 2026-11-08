using UnityEngine;
using System.Collections;

public class ScreenshotDisplay : MonoBehaviour
{

    [SerializeField] RenderTexture cameraRenderTexture;
    [SerializeField] RenderTexture screenshot;
    [SerializeField] Material screenshotMat;
    private void Start()
    {
        screenshot = new RenderTexture(Screen.width, Screen.height, 24);
        GameManager.Instance.cameraRenderTexture = cameraRenderTexture;
        //screenshotMat.mainTexture = screenshot;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(TakeScreenshotAndShow());
        }
    }

    private IEnumerator TakeScreenshotAndShow()
    {
        yield return new WaitForEndOfFrame();

        Graphics.Blit(cameraRenderTexture, screenshot);

        //ScreenCapture.
        //ScreenCapture.CaptureScreenshotIntoRenderTexture(screenshot);
    }

}
