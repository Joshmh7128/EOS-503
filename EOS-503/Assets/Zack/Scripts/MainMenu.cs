using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainMenu : MonoBehaviour
{
    // put a reference to audio

    public Toggle fullscreen;
    public Dropdown qualityDropdown;
    public Dropdown resolutionDropdown;
    public Dropdown sceneDropdown;

    Resolution[] resolutions;

    private string currentScene;

    List<string> listOfScenes = new List<string>();

    private void Start()
    {
		// Cursor.lockState = CursorLockMode.None;
		// Cursor.visible = true;

		fullscreen.isOn = Screen.fullScreen;

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " × " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        qualityDropdown.value = QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue();
        
        int sceneNumber = SceneManager.sceneCountInBuildSettings;

        for (int i = 0; i < sceneNumber; i++)
        {
            string sceneName = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            if (sceneName != "MainMenu")
            {
                listOfScenes.Add(sceneName);
            }
        }

        sceneDropdown.ClearOptions();
        sceneDropdown.AddOptions(listOfScenes);
        sceneDropdown.SetValueWithoutNotify(0);
        currentScene = listOfScenes[0];
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        // Do audio shit here
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetScene(int sceneIndex)
    {
        currentScene = listOfScenes[sceneIndex];
    }
}
