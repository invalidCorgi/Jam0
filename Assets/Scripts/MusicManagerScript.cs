using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{
    private AudioSource musicManager;
    // Start is called before the first frame update
    void Start()
    {
        musicManager = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
            if(!musicManager.isPlaying)
        {
            musicManager.Play();
        }
    }
}
