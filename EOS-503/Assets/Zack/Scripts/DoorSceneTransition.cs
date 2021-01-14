using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSceneTransition : MonoBehaviour
{
    [SerializeField] private string scene = null;
    [SerializeField] private bool sceneTransition = false;
    private bool interactable;

    public BoxCollider2D DoorBox;

    public Animator DoorL;
    public Animator DoorR;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interactable = false;

            DoorBox.enabled = true;
            if (DoorL) DoorL.SetBool("isOpen", false);
            if (DoorR) DoorR.SetBool("isOpen", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && interactable)
        {
            DoorBox.enabled = false;
            if (DoorL) DoorL.SetBool("isOpen", true);
            if (DoorR) DoorR.SetBool("isOpen", true);

            if (sceneTransition) StartCoroutine(SceneTransition());
        }
    }

    private IEnumerator SceneTransition()
    {
        Debug.Log("time to transition!");

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(scene);
    }
}
