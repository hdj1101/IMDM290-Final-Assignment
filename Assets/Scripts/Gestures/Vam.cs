using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Vam : MonoBehaviour
{
    public float TtToTtThreshold, ItToImcpThreshold, MtToMmcpThreshold, RtToRmcpThreshold, PtToPmcpThreshold, TtToIpipThresholdLess, TtToIpipThresholdGreater;
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
            // Debug.Log("Hand Distance: " + Vector3.Distance(leftHand,rightHand));
        }
        timeElapsed += Time.deltaTime;
        
        if(isAvailable)
        {   
            if (handsActive &&
               // Thumbs touching
               Vector3.Distance(Gesture.gen.lefthandpos[4],Gesture.gen.righthandpos[4]) <= TtToTtThreshold &&
               // Hands cupped over each other
               (Vector3.Distance(Gesture.gen.lefthandpos[8],Gesture.gen.righthandpos[5]) <= ItToImcpThreshold || Vector3.Distance(Gesture.gen.lefthandpos[5],Gesture.gen.righthandpos[8]) <= ItToImcpThreshold) &&
               (Vector3.Distance(Gesture.gen.lefthandpos[12],Gesture.gen.righthandpos[9]) <= MtToMmcpThreshold || Vector3.Distance(Gesture.gen.lefthandpos[9],Gesture.gen.righthandpos[12]) <= MtToMmcpThreshold) &&
               (Vector3.Distance(Gesture.gen.lefthandpos[16],Gesture.gen.righthandpos[13]) <= RtToRmcpThreshold || Vector3.Distance(Gesture.gen.lefthandpos[16],Gesture.gen.righthandpos[13]) <= RtToRmcpThreshold) &&
               // Thumbs are above other fingers
               (Vector3.Distance(Gesture.gen.lefthandpos[6],Gesture.gen.righthandpos[4]) <= TtToIpipThresholdLess || Vector3.Distance(Gesture.gen.lefthandpos[4],Gesture.gen.righthandpos[6]) <= TtToIpipThresholdLess) &&
               (Vector3.Distance(Gesture.gen.lefthandpos[6],Gesture.gen.righthandpos[4]) >= TtToIpipThresholdGreater || Vector3.Distance(Gesture.gen.lefthandpos[4],Gesture.gen.righthandpos[6]) >= TtToIpipThresholdGreater) &&
               Gesture.gen.lefthandpos[4].y < Gesture.gen.lefthandpos[6].y &&
               Gesture.gen.lefthandpos[4].y < Gesture.gen.lefthandpos[10].y &&
               Gesture.gen.lefthandpos[4].y < Gesture.gen.lefthandpos[14].y &&
               Gesture.gen.lefthandpos[4].y < Gesture.gen.lefthandpos[18].y &&
               Gesture.gen.righthandpos[4].y < Gesture.gen.righthandpos[6].y &&
               Gesture.gen.righthandpos[4].y < Gesture.gen.righthandpos[10].y &&
               Gesture.gen.righthandpos[4].y < Gesture.gen.righthandpos[14].y &&
               Gesture.gen.righthandpos[4].y < Gesture.gen.righthandpos[18].y)
               // NEED TO SEE WHY CANT GRAB PINKY TIP
            {
                isAvailable = false;
                Debug.Log("Checks Approved Vam");
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
