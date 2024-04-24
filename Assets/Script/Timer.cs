using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float timeToCompleteQuestion = 300f;
    [SerializeField] float timeToShowAnswer = 10f; 
    public bool isAnsweringQuestion;

    public bool loadnextQuestion;
    public float fillFraction;

    public float timerValue; 
    // Update is called once per frame
    void Update()
    {
        TimerUpdate();
    }
    public void CancelTimer(){
        timerValue = 0;
    }
    void TimerUpdate(){
        timerValue -= Time.deltaTime;

        if(isAnsweringQuestion){

            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            
            else{
                
                isAnsweringQuestion = false;
                
                timerValue = timeToShowAnswer;
            }
        }
        else{
            if(timerValue > 0)
            {   
                fillFraction = timerValue / timeToShowAnswer;
            }
            
            else{
                
                isAnsweringQuestion = true;
                
                timerValue = timeToCompleteQuestion;

                loadnextQuestion = true;
            }
        }
    }   

}
