using UnityEngine;

public class ScreenshotManager : MonoBehaviour
{
    public void TakeScreenshot()
    {
        ScreenCapture.CaptureScreenshot("AR_Screenshot.png");

        Debug.Log("Se tomo la foto");
    }
}
