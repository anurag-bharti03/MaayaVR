using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MahamastabhishekaScript : MonoBehaviour {

    public UnityEngine.Video.VideoPlayer videoNandi;

    public GameObject VideoSphere; 

    public UnityEngine.Video.VideoPlayer videoMahamastabhisheka;
    public GameObject MahamastabhishekaPlane;
    public GameObject NandiPlane;
    bool isNandiVideo;
    bool isMahamastabhishekaVideo;
   // public Transform Progress;

    private static bool isLookedAtMahamastabhisheka = false;

    // How long the user can gaze at this before the button is clicked.
    public float timerDuration = 3f;

    // Count time the player has been gazing at the button.
    private float lookTimer = 0f;

    // Use this for initialization
    void Start()
    {
        MahamastabhishekaPlane = GameObject.FindGameObjectWithTag("MahamastkabhishekaPlane");
        VideoSphere = GameObject.FindGameObjectWithTag("VideoSphere");
       // videoMahamastabhisheka = HomePageScript.videoMahamastabhisheka;
    }

    // Update is called once per frame
    void Update()
    {
        GazeDelay();
    }

    void GazeDelay()
    {
        if (isLookedAtMahamastabhisheka)
        {
            lookTimer += Time.deltaTime;

            if (lookTimer > timerDuration)
            {
                lookTimer = 0f;
                PlayMahamastabhishekaVideo();
            }
        }

        else
        {
            lookTimer = 0f;
        }
    }

    public static void SetGazedAtMahamastabhisheka(bool gazedAt)
    {
        isLookedAtMahamastabhisheka = gazedAt;
    }

    public void PlayNandiVideo()
    {
        isNandiVideo = true;
        videoNandi.Play();
        StartCoroutine(ShowMainVideoPlane());
    }

    public void StopNandiVideo()
    {
        isNandiVideo = false;
        videoNandi.Stop();

        StartCoroutine(HideMainVideoPlane());
        videoMahamastabhisheka.Play();
    }

    public void PlayMahamastabhishekaVideo()
    {
        isMahamastabhishekaVideo = true;
        StartCoroutine(ShowMainVideoPlane());
    }

    public void StopMahamastabhishekaVideo()
    {
        isMahamastabhishekaVideo = false;
        videoMahamastabhisheka.Stop();
        StartCoroutine(HideMainVideoPlane());
    }

    public IEnumerator HideMainVideoPlane()
    {
        VideoSphere.SetActive(false);
        yield return new WaitForEndOfFrame();
    }
    public IEnumerator ShowMainVideoPlane()
    {
        VideoSphere.SetActive(true);
        yield return new WaitForEndOfFrame();
    }
}
