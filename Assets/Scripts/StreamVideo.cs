using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StreamVideo : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    private bool stoppedPlaying;
    // Start is called before the first frame update
    void Start()
    {
        stoppedPlaying = false;
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while(!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }

        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
        stoppedPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown || (!videoPlayer.isPlaying && stoppedPlaying == true))
        {
            if(SceneManager.GetActiveScene().name == "IntroScene")
            {
                SceneManager.LoadScene(1);
            }
            else if(SceneManager.GetActiveScene().name == "OutroScene")
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
