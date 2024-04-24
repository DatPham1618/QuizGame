using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Question", fileName = "New Question")]
public class QuestionList : ScriptableObject
{   [TextArea(1, 6)] 
    [SerializeField] string question = "Enter your question here";
    [SerializeField] string[] answers = new string[4];
    
    [SerializeField] int correctAnswer;

    public string GetQuestion(){
        return question;
    }
    public string GetAnswer(int index){
        return answers[index];
    }
    public int GetCorrectAnswer(){
        return correctAnswer;
    }

    

}
