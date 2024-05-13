using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class TextDisplay : MonoBehaviour
{
    public TMP_Text pointsText; // Reference to the UI Text component

    public Points pointsScript; 
    // Start is called before the first frame update
    void Start()
    {
         if (pointsText == null)
        {
            Debug.LogError("Points Text is not assigned!");
        }

        // Ensure the Points script is assigned in the Inspector
        if (pointsScript == null)
        {
            Debug.LogError("Points Script is not assigned!");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update the UI Text with the current totalPoints value
        if (pointsText != null && pointsScript != null)
        {
            pointsText.text = pointsScript.poseName;
        }
        
    }
}
