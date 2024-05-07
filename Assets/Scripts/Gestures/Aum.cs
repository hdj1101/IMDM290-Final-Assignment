using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Aum : MonoBehaviour
{
    public float MtToMtThreshold, PmcpToPmcpThreshold;
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
        leftHand = Gesture.gen.lefthandpos[18];
        rightHand = Gesture.gen.righthandpos[18];

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
            
            if (Gesture.gen.righthandpos[13].x < Gesture.gen.righthandpos[14].x)
            {
                // Debug.Log("We're in");
            }
        }
        timeElapsed += Time.deltaTime;
        
        if (isAvailable)
        {   
            if (handsActive &&
               // Middle Fingers Touching
               Vector3.Distance(Gesture.gen.lefthandpos[12],Gesture.gen.righthandpos[12]) <= MtToMtThreshold &&
               // Pinkies Touching
               Vector3.Distance(Gesture.gen.lefthandpos[18],Gesture.gen.righthandpos[18]) <= PmcpToPmcpThreshold &&
               // Middle Fingers raised
               Gesture.gen.lefthandpos[12].y < Gesture.gen.lefthandpos[9].y &&
               Gesture.gen.righthandpos[12].y < Gesture.gen.righthandpos[9].y &&
               // Other fingers pointed down
               // Gesture.gen.lefthandpos[5].y < Gesture.gen.lefthandpos[8].y &&
               Gesture.gen.lefthandpos[13].y < Gesture.gen.lefthandpos[16].y &&
               Gesture.gen.lefthandpos[17].y < Gesture.gen.lefthandpos[19].y &&
               // Gesture.gen.righthandpos[5].y < Gesture.gen.righthandpos[8].y &&
               Gesture.gen.righthandpos[13].y < Gesture.gen.righthandpos[16].y &&
               Gesture.gen.lefthandpos[17].y < Gesture.gen.righthandpos[19].y &&
               // Fingers inside knuckles
               Gesture.gen.lefthandpos[5].x > Gesture.gen.lefthandpos[6].x &&
               Gesture.gen.lefthandpos[13].x > Gesture.gen.lefthandpos[14].x &&
               Gesture.gen.lefthandpos[17].x > Gesture.gen.lefthandpos[18].x &&
               Gesture.gen.righthandpos[5].x < Gesture.gen.righthandpos[6].x &&
               Gesture.gen.righthandpos[13].x < Gesture.gen.righthandpos[14].x &&
               Gesture.gen.righthandpos[17].x < Gesture.gen.righthandpos[18].x
            )
               // NEED TO SEE WHY CANT GRAB PINKY TIP
            {
                isAvailable = false;
                Debug.Log("Checks Approved");
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
