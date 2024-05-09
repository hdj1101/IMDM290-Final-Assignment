using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lam : MonoBehaviour, IGestureCheck, IUpdateHands
{
    public Vector3 averageRightIndexPos, averageRightThumbPos;
    public Vector3 averageLeftIndexPos, averageLeftThumbPos;

    public float distThreshold;
    public int pointCount; 

    // Start is called before the first frame update
    void Start()
    {
        distThreshold = 0.1f;
    }

    // Update is called once per frame
    //{8,7} AND {4,3}
    void Update()
    {
        // UpdateAverageRightHandPos();
        // UpdateAverageLeftHandPos();
    }

    public void UpdateAverageHandPos()
    {
        // positions are generally between 1(left), 0(right), 0(up), 1(down)

        averageRightIndexPos = Gesture.gen.righthandpos[8];
        averageRightThumbPos = Gesture.gen.righthandpos[4];
        
        averageLeftIndexPos = Gesture.gen.lefthandpos[8];
        averageLeftThumbPos = Gesture.gen.lefthandpos[4];
    }

    public bool CheckGesture(){
        if(Vector3.Distance(averageRightIndexPos,averageRightThumbPos) <= distThreshold ||
            Vector3.Distance(averageLeftIndexPos,averageLeftThumbPos) <= distThreshold){
            // OnLam();
            return true;
        }

        return false;
    }

    public void OnLam(){
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
