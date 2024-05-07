using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
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
    public AudioSource gameMusic; 
     void Start()
    {
        pauseMenuPanel.style.display = DisplayStyle.None;
        settingsMenu.style.display = DisplayStyle.None;
    }
    void Awake()
    {
        document = GetComponent<UIDocument>();
        pauseMenuPanel = document.rootVisualElement.Q<VisualElement>("PauseMenu");
        settingsMenu = document.rootVisualElement.Q<VisualElement>("SettingsMenu"); 
        resumeButton = document.rootVisualElement.Q<Button>("ResumeButton");
        settingsButton = document.rootVisualElement.Q<Button>("SettingsButton");
        homeButton = document.rootVisualElement.Q<Button>("HomeButton");
        settingsBackButton = document.rootVisualElement.Q<Button>("SettingsBackButton");

        // Event listeners
        homeButton.clicked += HomeButtonClicked;
        settingsButton.clicked += SettingsButtonClicked;
        resumeButton.clicked += ResumeButtonClicked;
        settingsBackButton.clicked += SettingsBackButtonClicked;
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
        settingsMenu.style.display = DisplayStyle.None;
        Time.timeScale = 0f; 
        gameMusic.Pause(); 
        isPaused = true;
        UnityEngine.Cursor.lockState = UnityEngine.CursorLockMode.None; 
        UnityEngine.Cursor.visible = true; 
    }

    public void ResumeButtonClicked()
    {
        pauseMenuPanel.style.display = DisplayStyle.None;
        settingsMenu.style.display = DisplayStyle.None;
        Time.timeScale = 1f; // Unpause the game
        gameMusic.Play(); // Resume the audio
        isPaused = false;
        UnityEngine.Cursor.lockState = UnityEngine.CursorLockMode.Locked; 
        UnityEngine.Cursor.visible = false; // Hide cursor
    }

    public void SettingsButtonClicked()
    {
        pauseMenuPanel.style.display = DisplayStyle.None;
        settingsMenu.style.display = DisplayStyle.Flex;
    }

    public void HomeButtonClicked()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu"); 
    }

    public void SettingsBackButtonClicked()
    {
        settingsMenu.style.display = DisplayStyle.None;
        pauseMenuPanel.style.display = DisplayStyle.Flex;
    }
}
