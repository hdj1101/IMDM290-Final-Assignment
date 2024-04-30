using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dia : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string [] Sentences;
    public int Index = 0;
    public float DialougeSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            NextSentence();
        }
    }

    void NextSentence()
    {
        if(Index <= Sentences.Length - 1)
        {
            DialogueText.text ="";
            StartCoroutine(WriteSentence());
        }
    }

    IEnumerator WriteSentence()
    {
        foreach(char Character in Sentences[Index].ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialougeSpeed);
        }
        Index++;
    }
}
