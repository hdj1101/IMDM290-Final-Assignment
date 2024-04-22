using UnityEngine;

public class Color2DynamicGradient : MonoBehaviour
{
    public Color color1Start;
    public Color color1End;
    public Color color2Start;
    public Color color2End;
    public float lerpSpeed = 1f;
    public float originDelay = 0f;
    public float originScale = 1f;
    public float cycleDuration = 5f; // Adjust this parameter to control the duration of a full cycle

    private Material material;
    private Color currentColor1;
    private Color currentColor2;
    private float originOffset;
    private bool reverseLerp = false;

    void Start()
    {
        // Assuming you've already assigned the material to the GameObject's renderer
        material = GetComponent<Renderer>().material;

        // Initialize current colors
        currentColor1 = color1Start;
        currentColor2 = color2Start;

        // Set the initial colors
        material.SetColor("_Color1", currentColor1);
        material.SetColor("_Color2", currentColor2);

        // Set initial origin offset
        originOffset = Mathf.Sin(Time.time * Mathf.PI / cycleDuration) * originScale;
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
        if (currentColor1 == color1End && currentColor2 == color2End)
        {
            reverseLerp = true;
        }
        else if (currentColor1 == color1Start && currentColor2 == color2Start)
        {
            reverseLerp = false;
        }

        // Update origin offset with delay
        if (Time.time > originDelay)
        {
            originOffset = Mathf.Sin((Time.time - originDelay) * Mathf.PI / cycleDuration) * originScale;
        }

        // Adjust origin offset based on spread value
        float spread = material.GetFloat("_Spread");
        float adjustedOriginOffset = originOffset - (spread / 2f);

        // Update the material's origin property
        material.SetFloat("_Origin", 0.5f + adjustedOriginOffset);

        // Update the material's colors
        material.SetColor("_Color1", currentColor1);
        material.SetColor("_Color2", currentColor2);
    }
}
