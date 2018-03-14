using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeInput : MonoBehaviour {

    public UnityEngine.Video.VideoPlayer videoNandi;

    public GameObject FrontWall;
    public GameObject LeftWall;
    public GameObject RightWall;
    public GameObject Floor;
    public GameObject Ceiling;
    public GameObject MainVideoPlane;
    public GameObject PlayButton;
    public GameObject PauseButton;

    public UnityEngine.Video.VideoPlayer videoMahamastabhisheka;
    public GameObject MahamastabhishekaPlane;
    public GameObject NandiPlane;
    bool isNandiVideo;
    bool isMahamastabhishekaVideo;

    private bool isLookedAtBahubali = false;
    private bool isLookedAtMahamastabhisheka = false;

    // How long the user can gaze at this before the button is clicked.
    public float timerDuration = 3f;

    // Count time the player has been gazing at the button.
    private float lookTimer = 0f;



	// Use this for initialization
	void Start () {
        Debug.Log(("Anurag!!!"));
        Camera.main.GetComponent<Transform>().localRotation = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye);
        StartCoroutine(HideMainVideoPlane());

       // StartCoroutine(HidePlayButton());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isNandiVideo)
            {
                StopNandiVideo();
            }

            else{
                StopMahamastabhishekaVideo();
            }
        }

       // GazeDelay();
	}

    //void GazeDelay()
    //{
    //    if (isLookedAtBahubali)
    //    {

    //        // Increment the gaze timer.
    //        lookTimer += Time.deltaTime;

    //        // Modify graphic progress indicator to show remaining time. E.g. set the alpha layer value
    //        // cutoff on a PNG so the part showing is proportional to remaining time.
    //        gazeTimer1.GetComponent<Renderer>().material.SetFloat("_Cutoff", lookTimer / timerDuration);

    //        // Gaze time exceeded limit - button is considered clicked.
    //        if (lookTimer > timerDuration)
    //        {
    //            lookTimer = 0f;

    //            PlayNandiVideo();
    //        }
    //    }

    //    else if (isLookedAtBahubali)
    //    {

    //        // Increment the gaze timer.
    //        lookTimer += Time.deltaTime;

    //        // Modify graphic progress indicator to show remaining time. E.g. set the alpha layer value
    //        // cutoff on a PNG so the part showing is proportional to remaining time.
    //        gazeTimer2.GetComponent<Renderer>().material.SetFloat("_Cutoff", lookTimer / timerDuration);

    //        // Gaze time exceeded limit - button is considered clicked.
    //        if (lookTimer > timerDuration)
    //        {
    //            lookTimer = 0f;

    //            PlayMahamastabhishekaVideo();
    //        }
    //    }

    //    // Not gazing at this anymore, reset everything.
    //    else
    //    {
    //        lookTimer = 0f;
    //        // Reset progress indicator.
    //        gazeTimer1.GetComponent<Renderer>().material.SetFloat("_Cutoff", 0f);
    //        gazeTimer2.GetComponent<Renderer>().material.SetFloat("_Cutoff", 0f);
    //    }
    //}


   

    //// Record whether Google Cardboard user is gazing at the button.
    //// gazedAt: Set it to the value passed from event trigger.
    //public void SetGazedAtBahubali(bool gazedAt)
    //{
    //    isLookedAtBahubali = gazedAt;
    //}

    //public void SetGazedAtMahamastabhisheka(bool gazedAt)
    //{
    //    isLookedAtMahamastabhisheka = gazedAt;
    //}

    //public void PlayNandiVideo()
    //{
    //    isNandiVideo = true;
    //    videoNandi.Play();
    //    StartCoroutine(HideRoomComponents());
    //    StartCoroutine(ShowMainVideoPlane());
    //}

    public void StopNandiVideo()
    {
        isNandiVideo = false;
        videoNandi.Stop();
        StartCoroutine(ShowRoomComponents());
        StartCoroutine(HideMainVideoPlane());
    }

    //public void PlayMahamastabhishekaVideo()
    //{
    //    isMahamastabhishekaVideo = true;
    //    videoMahamastabhisheka.Play();
    //    StartCoroutine(HideRoomComponents());
    //    StartCoroutine(ShowMainVideoPlane());
    //}

    public void StopMahamastabhishekaVideo()
    {
        isMahamastabhishekaVideo = false;
        videoMahamastabhisheka.Stop();
        StartCoroutine(ShowRoomComponents());
        StartCoroutine(HideMainVideoPlane());
    }

    public IEnumerator HideRoomComponents()
    {
        FrontWall.SetActive(false);
        LeftWall.SetActive(false);
        RightWall.SetActive(false);
        Floor.SetActive(false);
        Ceiling.SetActive(false);

        yield return new WaitForEndOfFrame();
    }

    public IEnumerator ShowRoomComponents()
    {
        FrontWall.SetActive(true);
        LeftWall.SetActive(true);
        RightWall.SetActive(true);
        Floor.SetActive(true);
        Ceiling.SetActive(true);

        yield return new WaitForEndOfFrame();
    }

    public IEnumerator HideMainVideoPlane()
    {PlayButton.SetActive(false);

        MainVideoPlane.SetActive(false);
        yield return new WaitForEndOfFrame();
    }
    public IEnumerator ShowMainVideoPlane()
    {
        MainVideoPlane.SetActive(true);
        yield return new WaitForEndOfFrame();
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
