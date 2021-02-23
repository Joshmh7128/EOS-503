﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneDoor : MonoBehaviour
{
    /// this scene manages an individual door, 
    /// the fading in and out of scenes, loading and unloading scenes, 
    /// and moving the player package & camera package to a 
    /// new transform spot throughout the game and in between scenes.
    /// 
    /// this script was rewritten by Josh on 02/23/21

    [SerializeField] Vector3 destinationVector3; // where is our player going?
    [SerializeField] string destinationScene; // which scene are we going to?
    [SerializeField] string currentScene; // which scene is this?
    [SerializeField] string playerPackageName = "PlaceholderPC"; // what is the name of the player package?
    [SerializeField] string fadeCanvasPackageName = ""; // what is the name of the fade canvas package? This will be under the player prefab
    [SerializeField] GameObject playerPackage; // what is the player package?
    [SerializeField] GameObject cameraPackage; // what is the camera package?
    [SerializeField] bool isLoading; // are we loading?
    [SerializeField] CanvasGroup fadeCanvasGroup; // what is our canvas group?
    [SerializeField] bool fadeState; // true is increase alpha, false is decrease
    [SerializeField] FadeTracker fadeTracker; // tracks whether or not we're fading
    [Header("Fade Transition Speed (0 is slow, 1 is instant)")]
    [SerializeField] float transitionSpeed = 0.025f; // how quickly do you want the alpha to transition? adjust in script for global, or individually on each door

    // start runs before the start of the first frame
    private void Start()
    {
        // find the player object, camera, and fade canvas & tracker
        playerPackage = GameObject.Find(playerPackageName);
        fadeCanvasGroup = GameObject.Find("FadeCanvas").GetComponent<CanvasGroup>();
        fadeTracker = fadeCanvasGroup.gameObject.GetComponent<FadeTracker>();
    }

    // fixed update runs 60 times per second
    private void FixedUpdate()
    {
        // check fade state
        if (fadeTracker.fadeState == true)
        {
            Debug.Log("Fade True");
            if (fadeCanvasGroup.alpha <= 1)
            {   // increase alpha
                fadeCanvasGroup.alpha += transitionSpeed;
                Debug.Log("Fading to black...");
            }
        }

        if (fadeTracker.fadeState == false)
        {
            Debug.Log("Fade False");
            if (fadeCanvasGroup.alpha > 0)
            {
                // decrease alpha
                Debug.Log("Fading to white...");
                fadeCanvasGroup.alpha -= transitionSpeed;
            }
        }
    }

    IEnumerator LoadLocalScene()
    {
        // we are now loading
        isLoading = true;

        // fade to black
        fadeState = true; fadeTracker.fadeState = fadeState;
        Debug.Log("Fading to 1");
        // wait
        yield return new WaitForSeconds(1f);
        // load the new scene
        SceneManager.LoadScene(destinationScene, LoadSceneMode.Additive);
        Debug.Log("Scene Loaded: " + destinationScene);

        #region Depricated Player Tracking
        /*
        // make the one true player
        playerPackage.GetComponent<PlayerController>().isRealPlayer = true;
        cameraPackage.GetComponent<CameraTrackingScript>().isRealCamera = true;
        */
        #endregion

        // move the player
        playerPackage.transform.position = destinationVector3;
        // wait
        Debug.Log("Fading to 0");
        yield return new WaitForSeconds(1f);
        // remove fade
        fadeState = false; fadeTracker.fadeState = fadeState;
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