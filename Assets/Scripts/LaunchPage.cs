using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchPage : MonoBehaviour
{
    public Button StartButton;
    public Button SettingsButton;
    public Button ExitButton;
    public Button CreditsButton; 

    public void Start()
    {
        Time.timeScale = 0f;
        StartButton.onClick.AddListener(StartGame);
        SettingsButton.onClick.AddListener(OpenSettings);
        ExitButton.onClick.AddListener(ExitGame);
        CreditsButton.onClick.AddListener(OpenCredits); 
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); 
        Time.timeScale = 1f;
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void ExitGame()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
