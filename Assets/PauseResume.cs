using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{
    public GameObject PauseScreen;
    public static bool paused;
    public KeyCode PauseButton;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        PauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(PauseButton) && !paused)
        {
            pause();
        }
        else if(Input.GetKeyDown(PauseButton) && paused)
        {
            resume();
        }
        
    }
    public void pause()
    {
        PauseScreen.SetActive(true);
        paused = true;
        Time.timeScale = 0;
    }
    public void resume()
    {
        PauseScreen.SetActive(false);
        paused = false;
        Time.timeScale = 1;
    }
    public void quit()
    {
        Application.LoadLevel(6);
    }
}
