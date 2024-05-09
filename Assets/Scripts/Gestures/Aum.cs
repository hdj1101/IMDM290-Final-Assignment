using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Aum : MonoBehaviour, IGestureCheck
{
    public float MtToMtThreshold, PmcpToPmcpThreshold;
    private Vector3 leftHand, rightHand;

    private bool handsActive = false;
    private float timeElapsed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        MtToMtThreshold = 0.05f;
        PmcpToPmcpThreshold = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        // CheckGesture();
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
    public bool CheckGesture()
    {
        timeElapsed += Time.deltaTime;

        if (
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
            // Debug.Log("Checks Approved Aum");
            return true;
        }

        return false;
    }
}
