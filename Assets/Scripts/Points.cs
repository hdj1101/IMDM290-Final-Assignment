using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.WSA;

public class Points : MonoBehaviour
{
    public int totalPoints;

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

    private bool holdingPose = false;

    private int randomIndex;

    private int prevIndex;
    private int prevPrevIndex;

    private float holdDuration = 2.0f;
    
    private float timeElapsed = 0.0f;
    private int successfulChecks = 0;


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
        // updateList.Add(lamScript);
        updateList.Add(rudraScript);
        updateList.Add(rudraScript);

        randomIndex = 0;
        prevIndex = -1;
        prevPrevIndex = -2;

        Debug.Log(scriptList[totalPoints].GetType().Name);
    }

    // Update is called once per frame
    void Update()
    {
        if (!handsActive)
        {
            UpdateHandPos();
        }
        else if (holdingPose)
        {
            poseHolder();
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

                prevPrevIndex = prevIndex;
                if (totalPoints < scriptList.Count)
                {
                    prevIndex = totalPoints;
                }
                else
                {
                    prevIndex = randomIndex;
                }

                // Used after scripts are done
                while (randomIndex == prevIndex || randomIndex == prevPrevIndex)
                {
                    randomIndex = Random.Range(0, scriptList.Count);
                    Debug.Log("Random: " + randomIndex);
                }

                if (totalPoints < scriptList.Count)
                {
                    Debug.Log(scriptList[totalPoints].GetType().Name);
                }
                else
                {
                    Debug.Log(scriptList[randomIndex].GetType().Name);
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

            if (scriptList[totalPoints].CheckGesture())
            {
                holdingPose = true;
                Debug.Log("Holding " + scriptList[totalPoints].GetType().Name);
            }
        }
        else
        {
            updateList[randomIndex].UpdateAverageHandPos();

            if (scriptList[randomIndex].CheckGesture())
            {
                holdingPose = true;
                Debug.Log("Holding " + scriptList[randomIndex].GetType().Name);
            }
        }
    }

    void poseHolder()
    {
        if (timeElapsed < holdDuration)
        {
            if (totalPoints < scriptList.Count)
            {
                updateList[totalPoints].UpdateAverageHandPos();

                if (scriptList[totalPoints].CheckGesture())
                {
                    successfulChecks++;
                }
            }
            else
            {
                updateList[randomIndex].UpdateAverageHandPos();

                if (scriptList[randomIndex].CheckGesture())
                {
                    successfulChecks++;
                }
            }

            timeElapsed += Time.deltaTime;
        }
        else
        {
            if (successfulChecks >= 20)
            {
                // StartCoroutine(Counter(totalPoints));
                totalPoints++;
                Debug.Log("Total Points: " + totalPoints);
                pointAdding = true;
                
                holdingPose = false;

                timeElapsed = 0.0f;
            }
            else
            {
                Debug.Log("Try again");
                
                holdingPose = false;

                timeElapsed = 0.0f;
            }
        }
    }    

    // IEnumerator Counter(int index)
    // {
    //     int waiter = 20;

    //     int isConsistent = (int) waiter / 4;
    //     int checkConsistent = 1;

    //     for (int i = 0; i < waiter; i++)
    //     {
    //         updateList[index].UpdateAverageHandPos();

    //         if (scriptList[index].CheckGesture())
    //         {
    //             checkConsistent++;
    //         }

    //         yield return new WaitForSeconds(1 / waiter);
    //     }

    //     if (checkConsistent >= isConsistent) 
    //     {
    //         totalPoints++;
    //         Debug.Log("Total Points: " + totalPoints);
    //         pointAdding = true;
    //     }
    //     else
    //     {
    //         Debug.Log("You suck dawg");
    //     }
    // }


}
