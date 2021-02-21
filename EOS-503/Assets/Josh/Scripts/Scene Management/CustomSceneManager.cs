using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    /// 
    /// this script handles all of our in game scene management tasks,
    /// such as loading, unloading, or async loading scenes
    /// written by Josh, if there's an issue please contact him
    /// if you need to make edits go ahead, just list them beneath this comment block
    ///  
    ///  

    // use start to declare donotdestroyonload
    private void Start()
    {
        // don't do it.
        DontDestroyOnLoad(this);
    }

    // load a scene in singleton, unloads all other scenes in the process
    public void LoadSingleScene(string targetScene)
    {
        SceneManager.LoadScene(targetScene, LoadSceneMode.Single);
    }

    // load a scene additively
    public void LoadAdditiveScene(string targetScene)
    {
        SceneManager.LoadScene(targetScene, LoadSceneMode.Additive);
    }

    // load a scene async singleton, unloads all other scenes in the process
    public void LoadAsyncSingeScene(string targetScene)
    {
        SceneManager.LoadSceneAsync(targetScene, LoadSceneMode.Single);
    }

    // load a scene async additively
    public void LoadAsyncAdditiveScene(string targetScene)
    {
        SceneManager.LoadSceneAsync(targetScene, LoadSceneMode.Additive);
    }

}
