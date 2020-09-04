using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDoor : MonoBehaviour
{
    [SerializeField] Transform destinationTransform;
    [SerializeField] string destinationScene;
    [SerializeField] string currentScene;
    [SerializeField] GameObject playerPackage;
    [SerializeField] GameObject cameraPackage;
    [SerializeField] bool isLoading;

    // start runs before the start of the first frame
    private void Start()
    {
        // find the player object
        playerPackage = GameObject.Find("Player Controller Package");
        cameraPackage = GameObject.Find("Camera Package");
    }

    IEnumerator LoadLocalScene()
    {
        // we are now loading
        isLoading = true;

        // load the new scene
        SceneManager.LoadScene(destinationScene, LoadSceneMode.Additive);
        // make the one true player
        playerPackage.GetComponent<PlayerController>().isRealPlayer = true;
        cameraPackage.GetComponent<CameraTrackingScript>().isRealCamera = true;
        // wait
        yield return new WaitForSeconds(1f);
        // move the player
        playerPackage.transform.position = destinationTransform.position;
        // wait
        yield return new WaitForSeconds(1f);
        // unload the old scene
        SceneManager.UnloadSceneAsync(currentScene);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (isLoading == false)
            {
                Debug.Log("loading...");
                StartCoroutine(LoadLocalScene());
            }
        }
    }
}