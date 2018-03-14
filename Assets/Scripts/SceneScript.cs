using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScript : MonoBehaviour {

    public GameObject FrontWall;
    public GameObject LeftWall;
    public GameObject RightWall;
    public GameObject Floor;
    public GameObject Ceiling;
    public GameObject MainVideoPlane;
    public UnityEngine.Video.VideoPlayer videoMahamastabhisheka;
    public GameObject MahamastabhishekaPlane;
    public GameObject NandiPlane;
    public UnityEngine.Video.VideoPlayer videoNandi;
    bool isNandiVideo;
    bool isMahamastabhishekaVideo;
    public GameObject SwitchVrButton;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "NandiVideoPlane")
                {
                    PlayNandiVideo();
                }

                else if (hit.collider.tag == "Mahamastakabhisheka")
                {
                    PlayMahamastabhishekaVideo();
                }

                else{
                    //do nothing
                }
            }
        }
	}

    public void PlayNandiVideo()
    {
        isNandiVideo = true;
        videoNandi.Play();
        StartCoroutine(HideRoomComponents());
        StartCoroutine(ShowMainVideoPlane());
    }

    public void StopNandiVideo()
    {
        isNandiVideo = false;
        videoNandi.Stop();
        StartCoroutine(ShowRoomComponents());
        StartCoroutine(HideMainVideoPlane());
    }

    public void PlayMahamastabhishekaVideo()
    {
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
    {
        MainVideoPlane.SetActive(false);
        yield return new WaitForEndOfFrame();
    }
    public IEnumerator ShowMainVideoPlane()
    {
        MainVideoPlane.SetActive(true);
        yield return new WaitForEndOfFrame();
    }
}
