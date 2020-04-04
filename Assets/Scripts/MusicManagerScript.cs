using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{
    private AudioSource musicManager;
    private float musicTime;
    // Start is called before the first frame update
    void Start()
    {
        musicTime = 85f;
        musicManager = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(musicTime == 85f)
        {
            musicManager.volume = 0;
        }
        if(musicTime > 83 && musicManager.volume<=1)
        {
            musicManager.volume += Time.deltaTime*0.07f;
        }
        if(musicTime<=2f)
        {
            musicManager.volume -= Time.deltaTime*0.07f;
        }
        musicTime -= Time.deltaTime;
        if(musicTime <=0)
        {
            musicManager.Stop();
            musicManager.Play();
            musicTime = 85f;
        }
    }
}
