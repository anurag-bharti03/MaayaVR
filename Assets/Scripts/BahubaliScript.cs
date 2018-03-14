using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BahubaliScript : MonoBehaviour {

    public UnityEngine.Video.VideoPlayer videoBahubali;
    public GameObject VideoSphere; 

    public UnityEngine.Video.VideoPlayer videoMahamastabhisheka;
    public GameObject MahamastabhishekaPlane;
    public GameObject LordBahubaliPlane;
    bool isLordBahubaliVideo;
    bool isMahamastabhishekaVideo;
    public Transform Progress;

    private static bool isLookedAtBahubali = false;

    // How long the user can gaze at this before the button is clicked.
    public float timerDuration = 3f;

    // Count time the player has been gazing at the button.
    private float lookTimer = 0f;

    // Use this for initialization
    void Start()
    {
        LordBahubaliPlane = GameObject.FindGameObjectWithTag("LordBahubaliPlane");
        VideoSphere = GameObject.FindGameObjectWithTag("VideoSphere");
       // videoBahubali = HomePageScript.videoLordBahubali;
    }

    // Update is called once per frame
    void Update()
    {
        GazeDelay();
    }

    void GazeDelay()
    {
        
        if (isLookedAtBahubali)
        {
            
            // Increment the gaze timer.
            lookTimer += Time.deltaTime;

            // Gaze time exceeded limit - button is considered clicked.
            if (lookTimer > timerDuration)
            {
                lookTimer = 0f;
                PlayNandiVideo();
            }
        }

        // Not gazing at this anymore, reset everything.
        else
        {
            lookTimer = 0f;
        }
    }




    // Record whether Google Cardboard user is gazing at the button.
    // gazedAt: Set it to the value passed from event trigger.
    public static void SetGazedAtBahubali(bool gazedAt)
    { 
        isLookedAtBahubali = gazedAt;
    }

    public void PlayNandiVideo()
    {
        isLordBahubaliVideo = true;
        StartCoroutine(ShowMainVideoPlane());

        videoBahubali.Play();
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
