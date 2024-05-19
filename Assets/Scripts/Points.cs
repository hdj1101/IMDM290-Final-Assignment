using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Points : MonoBehaviour
{
    public int totalPoints;

    public string poseName = "Namaste";

    public Namaste namasteScript;
    public Lam lamScript;
    public Vam vamScript;
    public Aum aumScript;
    public Hakini hakiniScript;
    public Rudra rudraScript;
    private List<IGestureCheck> scriptList = new List<IGestureCheck>();

    private List<IUpdateHands> updateList = new List<IUpdateHands>(); // TEMP

    private bool handsActive = false;

    private bool pointAdding = false;

    private float timeElapsed = 0.0f;

    private int randomIndex;

    // Start is called before the first frame update
    void Start()
    {
        scriptList.Add(namasteScript);
        scriptList.Add(lamScript);
        scriptList.Add(vamScript);
        // scriptList.Add(aumScript);
        scriptList.Add(hakiniScript);
        scriptList.Add(rudraScript);

        updateList.Add(namasteScript); // TEMP
        updateList.Add(lamScript);
        updateList.Add(lamScript);
        updateList.Add(lamScript);
        updateList.Add(rudraScript);
        updateList.Add(rudraScript);

        Debug.Log(scriptList[totalPoints].GetType().Name);
        poseName = scriptList[totalPoints].GetType().Name;
    }

    // Update is called once per frame
    void Update()
    {
        if (!handsActive)
        {
            UpdateHandPos();
        }
        else if (!pointAdding)
        {
            runGestures();
        }
        else
        {
            if (timeElapsed < 3)
            {
                timeElapsed += Time.deltaTime;
            }
            else
            {
                timeElapsed = 0.0f;
                pointAdding = false;

                // Used after scripts are done
                randomIndex = Random.Range(0, scriptList.Count);

                if (totalPoints >= scriptList.Count)
                {
                    Debug.Log(scriptList[randomIndex].GetType().Name);
                    poseName = scriptList[randomIndex].GetType().Name;
                }
                else
                {
                    Debug.Log(scriptList[totalPoints].GetType().Name);
                    poseName = scriptList[totalPoints].GetType().Name;
                }
            }
        }
    }

    void UpdateHandPos()
    {
        if (Gesture.gen.lefthandpos[0] != Vector3.zero && Gesture.gen.righthandpos[0] != Vector3.zero){
            handsActive = true;
        }
    }

    void runGestures()
    {
        if (totalPoints < scriptList.Count)
        {
            updateList[totalPoints].UpdateAverageHandPos();

            if (scriptList[totalPoints].CheckGesture()){
                    totalPoints++;
                    Debug.Log("Total Points: " + totalPoints);
                    pointAdding = true;
            }
        }
        else
        {
            // Debug.Log("Done");

            updateList[randomIndex].UpdateAverageHandPos();

            // Call the CheckGesture method on the randomly chosen script
            if (scriptList[randomIndex].CheckGesture())
            {
                totalPoints++; // Increment totalPoints if gesture is valid
                Debug.Log("Total Points: " + totalPoints);
                pointAdding = true;
            }
        }
    }
}