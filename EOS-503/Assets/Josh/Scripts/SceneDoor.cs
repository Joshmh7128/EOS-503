using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDoor : MonoBehaviour
{
    [SerializeField] Transform destinationTransform;
    [SerializeField] Scene destinationScene;
    [SerializeField] GameObject playerPackage;

    private void Start()
    {
        playerPackage = GameObject.Find("Player Controller Package");
    }

    IEnumerator LoadLocalScene()
    {
        // load the new scene
        if (destinationScene.isLoaded == false)
        {
            SceneManager.LoadScene(destinationScene.name, LoadSceneMode.Additive);
        }

        // move the player
        playerPackage.transform.position = destinationTransform.position;

        yield return new WaitForSeconds(1f);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            LoadLocalScene();
        }
    }
}
