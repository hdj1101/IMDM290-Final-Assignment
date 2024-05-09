using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Namaste : MonoBehaviour, IGestureCheck, IUpdateHands
{
    public Vector3 averageRHPos, averageLHPos;
    public float clapDistThreshold, unclapDistThreshold;
    public int pointCount; 
    private bool clapAvailable = true;
    // Start is called before the first frame update
    void Start()
    {
        clapDistThreshold = 0.1f;
        unclapDistThreshold = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        // UpdateAverageHandPos();
        // CheckNamaste();
    }

    public void UpdateAverageHandPos(){
        /*positions are generally between 1(left), 0(right), 0(up), 1(down)
        */
        Vector3 temp = new Vector3(0,0,0);
        foreach(Vector3 pos in Gesture.gen.lefthandpos){
            temp += pos;
        }
        temp /= Gesture.gen.lefthandpos.Length;
        averageLHPos = temp;
        temp = new Vector3(0,0,0);
        foreach(Vector3 pos in Gesture.gen.righthandpos){
            temp += pos;
        }
        temp /= Gesture.gen.righthandpos.Length;
        averageRHPos = temp;
    }

    public bool CheckGesture(){
        if(clapAvailable){
            // Debug.Log("hand distance" + Vector3.Distance(averageLHPos,averageRHPos));
            if(Vector3.Distance(averageLHPos,averageRHPos) <= clapDistThreshold){
                // OnNamaste();
                clapAvailable = false;
                Debug.Log("We're in");
                return true;
            }
        }else{
            if(Vector3.Distance(averageLHPos,averageRHPos) > unclapDistThreshold){
                clapAvailable = true;
            }
        }

        return false;
        
    }

    
    public void OnNamaste(){
        pointCount++;; 
        // Debug.Log("Point Count: " + pointCount);
        //calculate position ratio
        Vector3 clapPos = -((averageLHPos + averageRHPos)/2);
        Vector3 positionRatio = new Vector3(2*((clapPos.x) + 0.5f),2*((clapPos.y) + 0.5f), 0);
        // Debug.Log(positionRatio);
        
    }
}
