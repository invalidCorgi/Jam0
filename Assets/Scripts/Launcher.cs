using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(4);
    }

    public void StartGameWithoutCinamatic()
    {
        SceneManager.LoadScene(4);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
