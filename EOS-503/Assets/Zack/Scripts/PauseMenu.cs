using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class PauseMenu : MonoBehaviour
{
	public static bool gameIsPaused = false;

	public GameObject pauseMenuUI;
	public GameObject optionsMenuUI;
	public GameObject debugMenuUI;

	public Toggle fullscreen;
	public Dropdown qualityDropdown;
	public Dropdown resolutionDropdown;
	public Dropdown sceneDropdown;
	public Text reloadButtonText;

	Resolution[] resolutions;

	private string currentScene;

	List<string> listOfScenes = new List<string>();

	private void Start()
	{
		fullscreen.isOn = Screen.fullScreen;

		resolutions = Screen.resolutions;

		resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();

		int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " + resolutions[i].height;
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
		sceneDropdown.SetValueWithoutNotify(SceneManager.GetActiveScene().buildIndex - 1);
		SetScene(SceneManager.GetActiveScene().buildIndex - 1);

		pauseMenuUI.SetActive(false);
		optionsMenuUI.SetActive(false);
		debugMenuUI.SetActive(false);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (gameIsPaused)
			{
				Resume();
			}
			else if (!gameIsPaused)
			{
				Pause();
			}
		}
	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		optionsMenuUI.SetActive(false);
		debugMenuUI.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;

		// Cursor.lockState = CursorLockMode.Locked;
		// Cursor.visible = false;
	}

	void Pause()
	{
		pauseMenuUI.SetActive(true);
		optionsMenuUI.SetActive(false);
		debugMenuUI.SetActive(false);
		Time.timeScale = 0f;
		gameIsPaused = true;

		// Cursor.lockState = CursorLockMode.None;
		// Cursor.visible = true;
	}

	public void SetScene(int sceneIndex)
	{
		currentScene = listOfScenes[sceneIndex];

		if (SceneManager.GetActiveScene().name == currentScene)
		{
			reloadButtonText.text = "<b>Reload Current Scene</b>";
		}
		else
		{
			reloadButtonText.text = "<b>Load Selected Scene</b>";
		}
	}

	public void LoadScene(int index)
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;

		// Cursor.lockState = CursorLockMode.Locked;
		// Cursor.visible = false;

		SceneManager.LoadScene(index);
	}

	public void LoadSelectedScene()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;

		// Cursor.lockState = CursorLockMode.Locked;
		// Cursor.visible = false;

		SceneManager.LoadScene(currentScene);
	}

	public void SetVolume(float volume)
	{
		Debug.Log("Volume: " + volume.ToString());
	}

	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);
		Debug.Log("Quality: " + qualityIndex.ToString());
	}

	public void SetFullscreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
		Debug.Log("Fullscreen: " + isFullscreen.ToString());
	}

	public void SetResolution(int resolutionIndex)
	{
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
		Debug.Log("Resolution: " + resolution.ToString());
	}
}
