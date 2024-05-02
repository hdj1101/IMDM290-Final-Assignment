using Mediapipe.Unity.Holistic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPalm : MonoBehaviour
{
    public Vector3 averageRHPos, averageLHPos;
    public float clapDistThreshold, unclapDistThreshold;
    public MakeSound soundPlayer;
    private bool clapAvailable = true;

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
    
        
    }
        
    void UpdateAverageHandPos(){
       
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

    void CheckClap(){
        if(clapAvailable){
            if(Vector3.Distance(averageLHPos,averageRHPos) <= clapDistThreshold){
                OnClap();
                clapAvailable = false;
            }
        }else{
            if(Vector3.Distance(averageLHPos,averageRHPos) > unclapDistThreshold){
                clapAvailable = true;
            }
        }
        
    }

    

    public void OnClap(){
        Debug.Log("CLAP");
        //calculate position ratio
        Vector3 clapPos = -((averageLHPos + averageRHPos)/2);
        Vector3 positionRatio = new Vector3(2*((clapPos.x) + 0.5f),2*((clapPos.y) + 0.5f), 0);
        Debug.Log(positionRatio);
        soundPlayer.whenClap(positionRatio);
        
    }
   
    
}


