using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader2 : MonoBehaviour
{
    public Animator crossFade;
    private string nextSceneName; // Name of the next scene to load

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        crossFade.SetTrigger("Start");  //start animation
        yield return new WaitForSeconds(1f);    //wait a second
        //go to next scene
        SceneManager.LoadScene(SceneVFXChecker.sceneIndex); // Load scene by name
    }
}

