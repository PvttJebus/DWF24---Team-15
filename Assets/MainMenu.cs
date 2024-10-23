using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("GalaxyScene"); // The text inside quotations loads the scene to be played
    }

    public void QuitGame()
    {
       Application.Quit();
    }
    
}
