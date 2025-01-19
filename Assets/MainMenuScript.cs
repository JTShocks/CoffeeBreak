using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    
    public void PlayGame()
    {

        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    
    void Update()
    {
        
    }
}
