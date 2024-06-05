using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    public static NavigationController instance = null;

    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

       

    }

    public void GoToIntroScene() 
    {
        Application.LoadLevel(5);
    }
    
    public void GoToMainMenu()
    {
        Application.LoadLevel(6);
    }
    public void NewGame() 
    {
        Application.LoadLevel(9);
    }
    public void GoToControls()
    {
        Application.LoadLevel(7);
    }
    public void GoToCredits()
    {
        Application.LoadLevel(8);
    }
    public void GoToFinalScene()
    {
        Application.LoadLevel(21);
    }
    public void GoToLevel1Scene1()
    {
        Application.LoadLevel(12);
    }
    public void GoToLevel1Scene2()
    {
        Application.LoadLevel(13);

    }
    public void GoToLevel1Cutscene3()
    {
        Application.LoadLevel(11);
    }
    public void GoToLevel1Cutscene2()
    {
        Application.LoadLevel(10);
    }
    public void GoToLevel1Cutscene1()
    {
        Application.LoadLevel(9);
    }
    public void GoToDraculaCutscene()
    {
        Application.LoadLevel(19);
    }
    public void GoToDraculaBossFight()
    {
        Application.LoadLevel(20);
    }
    public void GoToIgorBossFight()
    {
        Application.LoadLevel(16);
    }
    public void GoToLevel2()
    {
        Application.LoadLevel(14);
    }
    public void GoToLevel2Scene1()
    {
        Application.LoadLevel(15);
    }
    public void GoToLevel3()
    {
        Application.LoadLevel(17);
    }
    public void GoToLevel4()
    {
        Application.LoadLevel(18);
    }
    public void GameOver1()
    {
        Application.LoadLevel(0);

    }
    public void GameOver2() 
    {
        Application.LoadLevel(1);

    }
    public void GameOver3() 
    {
        Application.LoadLevel(2);

    }
    public void GameOver4()
    {
        Application.LoadLevel(3);

    }
    public void Quit()
    {
        Application.Quit();
    }



  
    // Update is called once per frame
    void Update()
    {
        
    }
}
