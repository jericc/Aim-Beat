using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    private UIDocument document;
    private Button playButton;
    private Button settingsButton;
    private Button exitButton;
    private Button songSelectBackButton;
    private Button settingsBackButton;
    private Button playSongButton;
    private VisualElement mainMenuPanel;
    private VisualElement songSelectPanel;
    private VisualElement settingsMenu; 

    private void Awake()
    {
        document = GetComponent<UIDocument>();

        //query UI elements by name attributes
        mainMenuPanel = document.rootVisualElement.Q<VisualElement>("MainMenu");
        songSelectPanel = document.rootVisualElement.Q<VisualElement>("SongSelect");
        settingsMenu = document.rootVisualElement.Q<VisualElement>("SettingsMenu"); 
        playButton = document.rootVisualElement.Q<Button>("PlayButton");
        settingsButton = document.rootVisualElement.Q<Button>("SettingsButton");
        exitButton = document.rootVisualElement.Q<Button>("ExitButton");
        songSelectBackButton = document.rootVisualElement.Q<Button>("SongSelectBackButton");
        settingsBackButton = document.rootVisualElement.Q<Button>("SettingsBackButton");
        playSongButton = document.rootVisualElement.Q<Button>("PlaySongButton");
        

        // hide song select and settings at start
        songSelectPanel.style.display = DisplayStyle.None;
        settingsMenu.style.display = DisplayStyle.None;

        //event listeners for buttons
        playButton.clicked += PlayButtonClicked;
        settingsButton.clicked += SettingsButtonClicked;
        exitButton.clicked += ExitButtonClicked;
        songSelectBackButton.clicked += SongSelectBackButtonClicked;
        settingsBackButton.clicked += SettingsBackButtonClicked;
        playSongButton.clicked += PlaySongButtonClicked;
    }

    private void PlayButtonClicked()
    {
        mainMenuPanel.style.display = DisplayStyle.None;
        songSelectPanel.style.display = DisplayStyle.Flex;
    }

    private void SettingsButtonClicked()
    {
        mainMenuPanel.style.display = DisplayStyle.None;
        settingsMenu.style.display = DisplayStyle.Flex;
    }

    private void ExitButtonClicked()
    {
        Application.Quit();
    }

    private void SongSelectBackButtonClicked()
    {
        songSelectPanel.style.display = DisplayStyle.None;
        mainMenuPanel.style.display = DisplayStyle.Flex;
    }

    private void SettingsBackButtonClicked()
    {
        settingsMenu.style.display = DisplayStyle.None;
        mainMenuPanel.style.display = DisplayStyle.Flex;
    }
    private void PlaySongButtonClicked()
    {
        SceneManager.LoadScene("One More Time");
    }
}
