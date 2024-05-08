using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lam : MonoBehaviour
{
    public Vector3 averageRightIndexPos, averageRightThumbPos;
    public Vector3 averageLeftIndexPos, averageLeftThumbPos;

    public float distThreshold;
    public int pointCount; 
    private bool clapAvailable = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //{8,7} AND {4,3}
    void Update()
    {
        UpdateAverageRightHandPos();
        UpdateAverageLeftHandPos();
        CheckLam();
    }

    void UpdateAverageRightHandPos(){
        /*positions are generally between 1(left), 0(right), 0(up), 1(down)
        */
        averageRightIndexPos = Gesture.gen.righthandpos[8];
        averageRightThumbPos = Gesture.gen.righthandpos[4];
    }

    void UpdateAverageLeftHandPos(){
        averageLeftIndexPos = Gesture.gen.lefthandpos[8];
        averageLeftThumbPos = Gesture.gen.lefthandpos[4];
    }

    void CheckLam(){
        
        if (clapAvailable) {
            if(Vector3.Distance(averageRightIndexPos,averageRightThumbPos) <= distThreshold ||
                Vector3.Distance(averageLeftIndexPos,averageLeftThumbPos) <= distThreshold){
                OnLam();
                clapAvailable = false;
            }
        } else {
            if( Vector3.Distance(averageRightIndexPos,averageRightThumbPos) > distThreshold ||
                 Vector3.Distance(averageLeftIndexPos,averageLeftThumbPos) > distThreshold ){
                clapAvailable = true;

            }
        }
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
