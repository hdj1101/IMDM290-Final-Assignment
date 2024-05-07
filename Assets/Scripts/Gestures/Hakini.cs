using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Hakini : MonoBehaviour
{
    public float TtToTtThreshold, ItToItThreshold, MtToMtThreshold, RtToRtThreshold, WristToWristThresholdGreater;
    private Vector3 leftHand, rightHand;
    private bool isAvailable = true;
    private bool handsActive = false;
    private float timeElapsed = 0.0f;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        CheckGesture();
        UpdateHandPos();
    }

    void UpdateHandPos()
    {
        leftHand = Gesture.gen.lefthandpos[0];
        rightHand = Gesture.gen.righthandpos[0];

        if (leftHand != Vector3.zero && rightHand != Vector3.zero){
            handsActive = true;
        }
    }
    
    // Global position goes 0-1 right to left, 0-1 top to bottom
    void CheckGesture()
    {
        if (timeElapsed >= 1)
        {
            timeElapsed -= 1;
            // Debug.Log(leftHand);
            // Debug.Log(leftHand.x);
            // Debug.Log(leftHand.y);
            // Debug.Log(leftHand.z);
            // Debug.Log(rightHand);
            // Debug.Log(rightHand.x);
            // Debug.Log(rightHand.y);
            // Debug.Log(rightHand.z);
            Debug.Log("Hand Distance: " + Vector3.Distance(leftHand,rightHand));
        }
        timeElapsed += Time.deltaTime;
        
        if(isAvailable)
        {   
            if (handsActive &&
               // Finger tips touching
               Vector3.Distance(Gesture.gen.lefthandpos[4],Gesture.gen.righthandpos[4]) <= TtToTtThreshold &&
               Vector3.Distance(Gesture.gen.lefthandpos[8],Gesture.gen.righthandpos[8]) <= ItToItThreshold &&
               Vector3.Distance(Gesture.gen.lefthandpos[12],Gesture.gen.righthandpos[12]) <= MtToMtThreshold &&
               Vector3.Distance(Gesture.gen.lefthandpos[16],Gesture.gen.righthandpos[16]) <= RtToRtThreshold &&
               // Wrists away from eachother
               Vector3.Distance(Gesture.gen.lefthandpos[0],Gesture.gen.righthandpos[0]) >= WristToWristThresholdGreater &&
               // Finger tips above wrist
               Gesture.gen.lefthandpos[8].y < Gesture.gen.lefthandpos[0].y &&
               Gesture.gen.lefthandpos[12].y < Gesture.gen.lefthandpos[0].y &&
               Gesture.gen.lefthandpos[16].y < Gesture.gen.lefthandpos[0].y &&
               Gesture.gen.righthandpos[8].y < Gesture.gen.righthandpos[0].y &&
               Gesture.gen.righthandpos[12].y < Gesture.gen.righthandpos[0].y &&
               Gesture.gen.righthandpos[12].y < Gesture.gen.righthandpos[0].y &&
               // Finger tips pointed up
               Gesture.gen.lefthandpos[8].y < Gesture.gen.lefthandpos[5].y &&
               Gesture.gen.lefthandpos[12].y < Gesture.gen.lefthandpos[9].y &&
               Gesture.gen.lefthandpos[16].y < Gesture.gen.lefthandpos[13].y &&
               Gesture.gen.righthandpos[8].y < Gesture.gen.righthandpos[5].y &&
               Gesture.gen.righthandpos[12].y < Gesture.gen.righthandpos[9].y &&
               Gesture.gen.righthandpos[12].y < Gesture.gen.righthandpos[13].y)
               // NEED TO SEE WHY CANT GRAB PINKY TIP
            {
                isAvailable = false;
                Debug.Log("Checks Approved Hakini");
            }
        }
        else
        {
            // if(Vector3.Distance(leftHand,rightHand) > unDistThreshold)
            // {
            //     isAvailable = true;
            // }
        }
        
    }
}
