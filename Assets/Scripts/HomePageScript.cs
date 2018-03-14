using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePageScript : MonoBehaviour {

    public UnityEngine.Video.VideoPlayer videoLordBahubali;

    public GameObject HomeSphere;
    public GameObject MainVideoPlane;
  // public GvrReticlePointer gvrReticlePointer;
  // public GvrEditorEmulator gvrEditorEmulator;

    public UnityEngine.Video.VideoPlayer videoMahamastabhisheka;
    public GameObject MahamastabhishekaPlane;
    public GameObject LordBahubaliPlane;
    bool isLordBahubaliVideo;
    bool isMahamastabhishekaVideo;
    MahamastabhishekaScript script1;
    BahubaliScript script2;
    EventTriggerLordBahubali script3;
    EventTriggerMahamastabhishekaScript script4;

    private bool isLookedAtBahubali = false;
    private bool isLookedAtMahamastabhisheka = false;




    // Use this for initialization
    void Start()
    {
       // Camera.main.GetComponent<Transform>().localRotation = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye);
        StartCoroutine(HideMainVideoPlane());
        // StartCoroutine(HidePlayButton());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isLordBahubaliVideo)
            {
                StopLordBahubaliVideo();
            }

            else
            {
                StopMahamastabhishekaVideo();
            }
        }

        if(ToggleVR1.IsVRMode)
        {
            //script1 = MahamastabhishekaPlane.AddComponent<MahamastabhishekaScript>();
            //script2 = LordBahubaliPlane.AddComponent<BahubaliScript>();
            //script3 = LordBahubaliPlane.AddComponent<EventTriggerLordBahubali>();
            //script4 = MahamastabhishekaPlane.AddComponent<EventTriggerMahamastabhishekaScript>();
           // gvrEditorEmulator.enabled = true;
          //  gvrReticlePointer.enabled = true;
        }

        else
        {
          //  gvrEditorEmulator.enabled = false;
           // gvrReticlePointer.enabled = false;
            if (isLordBahubaliVideo || isMahamastabhishekaVideo)
            {


                if (!SystemInfo.supportsGyroscope)
                {
                    Debug.Log("WARNING: Gyro not supported");
                    if (Application.platform != RuntimePlatform.IPhonePlayer ||
                      Application.platform != RuntimePlatform.Android)
                    {
                        Debug.Log("WARNING: Gyro only works on phone");
                    }
                }

                Input.gyro.enabled = true;
                RotateCamera();
            } 
        }


        // GazeDelay();
    }

    public void btnPlayLordBahubaliVideo_OnClick()
    {
        Debug.Log("Play Bahubali");
        PlayLordBahubaliVideo();
    }

    public void btnPlayMahamastabhishekaVideo_OnClick()
    {
        Debug.Log("Play Mahamastabhisheka");
        PlayMahamastabhishekaVideo();
    }

    public void PlayLordBahubaliVideo()
    {
        isLordBahubaliVideo = true;
        videoLordBahubali.Play();
        Debug.Log("Play Bahubali1");
        StartCoroutine(HideRoomComponents());
        StartCoroutine(ShowMainVideoPlane());
    }

    public void StopLordBahubaliVideo()
    {
        isLordBahubaliVideo = false;
        videoLordBahubali.Stop();
        StartCoroutine(ShowRoomComponents());
        StartCoroutine(HideMainVideoPlane());
        ResetCamera();
    }

    public void PlayMahamastabhishekaVideo()
    {
        Debug.Log("Play Mahamastabhisheka1");
        isMahamastabhishekaVideo = true;
        videoMahamastabhisheka.Play();

        StartCoroutine(HideRoomComponents());
        StartCoroutine(ShowMainVideoPlane());
    }

    public void StopMahamastabhishekaVideo()
    {
        isMahamastabhishekaVideo = false;
        videoMahamastabhisheka.Stop();
        StartCoroutine(ShowRoomComponents());
        StartCoroutine(HideMainVideoPlane());
        ResetCamera();
    }

    public IEnumerator HideRoomComponents()
    {
        HomeSphere.SetActive(false);
        MahamastabhishekaPlane.SetActive(false);
        LordBahubaliPlane.SetActive(false);
        yield return new WaitForEndOfFrame();
    }

    public IEnumerator ShowRoomComponents()
    {
        HomeSphere.SetActive(true);
        MahamastabhishekaPlane.SetActive(true);
        LordBahubaliPlane.SetActive(true);

        yield return new WaitForEndOfFrame();
    }

    public IEnumerator HideMainVideoPlane()
    {
       // PlayButton.SetActive(false);

        MainVideoPlane.SetActive(false);
        yield return new WaitForEndOfFrame();
    }
    public IEnumerator ShowMainVideoPlane()
    {
        Debug.Log(("Show main video plane"));
        MainVideoPlane.SetActive(true);
        yield return new WaitForEndOfFrame();
    }

    void RotateCamera()
    {
        Quaternion transQuat = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y,
                                         -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        gameObject.transform.rotation = Quaternion.Euler(90, 0, 0) * transQuat;
    }

    void ResetCamera()
    {
        Input.gyro.enabled = false;
        gameObject.transform.Rotate(0.0f, -265.594f, 0.0f);
        Vector3 vector3 = new Vector3(0f, 0f, 0f);
        gameObject.transform.position = vector3;
        var newRotation = gameObject.transform.rotation.eulerAngles;
        newRotation.z = 0;
        gameObject.transform.rotation = Quaternion.Euler(newRotation);
    }

    //public IEnumerator HidePlayButton()
    //{
    //    PlayButton.SetActive(false);
    //    PauseButton.SetActive(true);
    //    yield return new WaitForEndOfFrame();
    //}
    //public IEnumerator ShowPlayButton()
    //{
    //    PlayButton.SetActive(true);
    //    PauseButton.SetActive(false);
    //    yield return new WaitForEndOfFrame();
    //}

    //public void PlayButtonClick()
    //{
    //    StartCoroutine(HidePlayButton());
    //    if(isNandiVideo)
    //    {
    //        videoNandi.Play();
    //    }

    //    else
    //    {
    //        videoMahamastabhisheka.Play();
    //    }
    //}

    //public void PauseButtonClick()
    //{
    //    StartCoroutine(ShowPlayButton());
    //    if (isNandiVideo)
    //    {
    //        videoNandi.Pause();
    //    }

    //    else
    //    {
    //        videoMahamastabhisheka.Pause();
    //    }
    //}

    //public void BackButtonClick()
    //{
    //    if (isNandiVideo)
    //    {
    //        StopNandiVideo();
    //    }

    //    else
    //    {
    //        StopMahamastabhishekaVideo();
    //    }
    //}

}
