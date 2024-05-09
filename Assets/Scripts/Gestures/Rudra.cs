using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rudra : MonoBehaviour, IGestureCheck, IUpdateHands
{
    public float averageRightHandDist;
    public float averageLeftHandDist;

    public float distThreshold;
    public int pointCount; 
    private bool clapAvailable = true;

    // Start is called before the first frame update
    void Start()
    {
        distThreshold = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        // UpdateAverageRightHandPos();
        // UpdateAverageLeftHandPos();
    }

    public void UpdateAverageHandPos()
    {
        // positions are generally between 1(left), 0(right), 0(up), 1(down)

        Vector3 averageRightRingPos =  Gesture.gen.righthandpos[16];
        Vector3 averageRightMiddlePos = Gesture.gen.righthandpos[12];
        Vector3 averageRightThumbPos = Gesture.gen.righthandpos[4];

        float distance1 = Vector3.Distance(averageRightRingPos, averageRightMiddlePos);
        float distance2 = Vector3.Distance(averageRightMiddlePos, averageRightThumbPos);
        float distance3 = Vector3.Distance(averageRightThumbPos, averageRightRingPos);

        // Calculate average distance
        averageRightHandDist = (distance1 + distance2 + distance3) / 3f;

        Vector3 averageLeftRingPos =  Gesture.gen.lefthandpos[16];
        Vector3 averageLeftMiddlePos = Gesture.gen.lefthandpos[12];
        Vector3 averageLeftThumbPos = Gesture.gen.lefthandpos[4];

        distance1 = Vector3.Distance(averageLeftRingPos, averageLeftMiddlePos);
        distance2 = Vector3.Distance(averageLeftMiddlePos, averageLeftThumbPos);
        distance3 = Vector3.Distance(averageLeftThumbPos, averageLeftRingPos);

        // Calculate average distance
        averageLeftHandDist = (distance1 + distance2 + distance3) / 3f;
    }

    void UpdateAverageRightHandPos(){
        
    }

    void UpdateAverageLeftHandPos(){
         
    }

    public bool CheckGesture(){
        
        if (clapAvailable) {
            if((averageLeftHandDist) <= distThreshold ||
                (averageRightHandDist) <= distThreshold){
                // OnRudra();
                clapAvailable = false;
                return true;
            }
        } else {
            if( (averageLeftHandDist) > distThreshold ||
                (averageRightHandDist) > distThreshold){
                clapAvailable = true;

            }
        }
        return false;
    }

    public void OnRudra(){
        float elapsed = 0f;
        if (elapsed < 5 ){
            elapsed += Time.deltaTime;
        } else {
            elapsed -= 5;
            pointCount++;; 


        }
                    pointCount++;; 

        Debug.Log("Lam Point Count: " + pointCount);
        
    }
}
