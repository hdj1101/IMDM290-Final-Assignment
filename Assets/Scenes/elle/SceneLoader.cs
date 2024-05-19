<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator crossFade;

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
        Scene scene = SceneManager.GetActiveScene();    
        int nextLevelBuildIndex = 1 - scene.buildIndex;
        SceneManager.LoadScene(nextLevelBuildIndex); 
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator crossFade;
    public string nextSceneName; // Name of the next scene to load

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
        SceneManager.LoadScene(nextSceneName); // Load scene by name
    }
}

>>>>>>> Stashed changes
