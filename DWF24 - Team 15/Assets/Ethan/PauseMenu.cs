using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public SoundPause soundPause;

    void Start()
    {
        pausePanel.SetActive(false);  // Hides pausemenu on start
    }

    void Update()
    {
        // Check if the player presses ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeSelf)
            {
                Resume();  // Resume the game
            }
            else
            {
                Pause();  // Pause the game
            }
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;  // Resume game time
        soundPause?.ResumeAudio();  // Resume the audio
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;  // Pause game time
        soundPause?.PauseAudio();  // Pause the audio
    }

    public void QuitGame()
    {
        Application.Quit();  // Quit the game
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // Stop play mode when quit in editor
#endif
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");  // Loads the Main Menu scene
    }
}
