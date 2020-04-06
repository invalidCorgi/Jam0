using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSceneAfterTime : MonoBehaviour
{
    public float timeToChangeScene;
    // Start is called before the first frame update
    void Start()
    {
        timeToChangeScene = 113f;
    }

    // Update is called once per frame
    void Update()
    {
        timeToChangeScene -= Time.deltaTime;
        if (timeToChangeScene <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
