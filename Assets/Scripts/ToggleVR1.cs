using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class ToggleVR1 : MonoBehaviour
{
    public static bool IsVRMode;
    public GameObject SwitchVrButton;

    private void Start()
    {
       // XRSettings.enabled = false;
    }

    void Update()
    {

    }

    public void SwitchMode()
    {
        // SceneManager.LoadScene("VRVideoPlayback");
        IsVRMode = true;
        StartCoroutine(SwitchToVR());
    }

    // Call via `StartCoroutine(SwitchToVR())` from your code. Or, use
    // `yield SwitchToVR()` if calling from inside another coroutine.
    IEnumerator SwitchToVR()
    {
        // Device names are lowercase, as returned by `XRSettings.supportedDevices`.
        string desiredDevice = "cardboard";

        XRSettings.LoadDeviceByName(desiredDevice);

        // Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
        yield return null;

        // Now it's ok to enable VR mode.
        XRSettings.enabled = true;
    }

    IEnumerator LoadDevice(string newDevice)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return new WaitForEndOfFrame();
        if (!XRSettings.loadedDeviceName.Equals(newDevice))
        {
            yield return null;
        }

        XRSettings.enabled = true;
    }
}
