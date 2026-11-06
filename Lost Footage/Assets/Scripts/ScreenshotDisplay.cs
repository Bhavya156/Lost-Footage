using UnityEngine;
using System.Collections;

public class ScreenshotDisplay : MonoBehaviour
{


    [SerializeField] RenderTexture screenshot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            screenshot.height = Screen.height;
            screenshot.width = Screen.width;
            StartCoroutine(TakeScreenshotAndShow());
        }
    }

    private IEnumerator TakeScreenshotAndShow()
    {
        yield return new WaitForEndOfFrame();

        ScreenCapture.CaptureScreenshotIntoRenderTexture(screenshot);
    }

}
