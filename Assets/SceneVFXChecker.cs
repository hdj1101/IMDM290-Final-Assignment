using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneVFXChecker : MonoBehaviour
{

    public static int sceneIndex = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateIndexEarth()
    {
        sceneIndex = 3;
    }
    public void updateIndexWind()
    {
        sceneIndex = 4;
    }
    public void updateIndexRain()
    {
        sceneIndex = 5;
    }
}
