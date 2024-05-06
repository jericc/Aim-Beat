using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject settingsPanel; 
    public GameObject resumeButton;
    public GameObject settingsButton;
    public GameObject returnMainMenuButton;
    private bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false); // Ensure the pause menu is hidden at start
        settingsPanel.SetActive(false); // Also ensure the settings panel is hidden at start
    }
    void Awake()
    {
        // resumeButton.GetComponent<Button>().onClick.AddListener(Resume);
        // settingsButton.GetComponent<Button>().onClick.AddListener(OpenSettings);
        // returnMainMenuButton.GetComponent<Button>().onClick.AddListener(ReturnToMainMenu);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //pause
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsPanel.SetActive(false); 
        Time.timeScale = 1f; //unpause
        isPaused = false;
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true); 
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // reset time
        SceneManager.LoadScene("MainMenu"); 
    }

}
