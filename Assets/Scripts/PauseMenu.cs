using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene management
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    private UIDocument document;
    private Button resumeButton;
    private Button settingsButton;
    private Button homeButton;
    private Button settingsBackButton;
    private VisualElement pauseMenuPanel;
    private VisualElement settingsMenu; 
    private bool isPaused = false;

    void Start()
    {
        pauseMenuPanel.style.display = DisplayStyle.None;
        settingsMenu.style.display = DisplayStyle.None;
    }
    void Awake()
    {
        pauseMenuPanel = document.rootVisualElement.Q<VisualElement>("PauseMenu");
        settingsMenu = document.rootVisualElement.Q<VisualElement>("SettingsMenu"); 
        resumeButton = document.rootVisualElement.Q<Button>("ResumeButton");
        settingsButton = document.rootVisualElement.Q<Button>("SettingsButton");
        homeButton = document.rootVisualElement.Q<Button>("HomeButton");
        settingsBackButton = document.rootVisualElement.Q<Button>("SettingsBackButton");

        //event listeners
        homeButton.clicked += HomeButtonClicked;
        settingsButton.clicked += SettingsButtonClicked;
        resumeButton.clicked += ResumeButtonClicked;
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
            ResumeButtonClicked();
        }
        else
        {
            PauseButtonClicked();
        }
    }

    public void PauseButtonClicked()
    {
        pauseMenuPanel.style.display = DisplayStyle.Flex;
        Time.timeScale = 0f; //pause
        isPaused = true;
    }

    public void ResumeButtonClicked()
    {
        pauseMenuPanel.style.display = DisplayStyle.None;
        settingsMenu.style.display = DisplayStyle.None;
        Time.timeScale = 1f; //unpause
        isPaused = false;
    }

    public void SettingsButtonClicked()
    {
        pauseMenuPanel.style.display = DisplayStyle.None;
        settingsMenu.style.display = DisplayStyle.Flex;
    }

    public void HomeButtonClicked()
    {
        Time.timeScale = 1f; // reset time
        SceneManager.LoadScene("MainMenu"); 
    }

}
