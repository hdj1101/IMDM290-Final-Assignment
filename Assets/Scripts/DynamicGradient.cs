using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicGradient : MonoBehaviour
{
    private Color color1Start;
    public Color color1End;
    private Color color2Start;
    public Color color2End;
    public float lerpSpeed = 0.5f;


    private Material material;
    private Color currentColor1;
    private Color currentColor2;
    private float intensityOffset1;
    private float intensityOffset2;
    private bool reverseLerp = false;

    void Start()
    {
        // Assuming you've already assigned the material to the GameObject's renderer
        material = GetComponent<Renderer>().material;

        // Initialize current colors
        color1Start = material.GetColor("_Color1");
        color2Start = material.GetColor("_Color2");
        currentColor1 = material.GetColor("_Color1");
        currentColor2 = material.GetColor("_Color2");
    }

    void Update()
    {
        // Lerping between the start and end colors, with the ability to reverse the lerp direction
        if (!reverseLerp)
        {
            currentColor1 = Color.Lerp(currentColor1, color1End, Time.deltaTime * lerpSpeed);
            currentColor2 = Color.Lerp(currentColor2, color2End, Time.deltaTime * lerpSpeed);
        }
        else
        {
            currentColor1 = Color.Lerp(currentColor1, color1Start, Time.deltaTime * lerpSpeed);
            currentColor2 = Color.Lerp(currentColor2, color2Start, Time.deltaTime * lerpSpeed);
        }

        // Check if lerping has reached the end or start colors, then reverse the lerp direction
        if (currentColor1 == color1End && currentColor2 == color2End
            )
        {
            reverseLerp = true;
        }
        else if (currentColor1 == color1Start && currentColor2 == color2Start
                 )
        {
            reverseLerp = false;
        }

        // Update the material's colors
        material.SetColor("_Color1", currentColor1);
        material.SetColor("_Color2", currentColor2);
    }
}