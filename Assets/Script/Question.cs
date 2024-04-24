using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Question : MonoBehaviour

{   
    Slider questionMark;
    Audiomanager SFXMusic;
    GameOverMenu LastScore;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI QuesstionPassed;
    
    [Header("Question")]
    public int currentIndex = 0;

    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionList> questions4 = new List<QuestionList>();
    [SerializeField] List<QuestionList> questions2 = new List<QuestionList>();
    [SerializeField] List<QuestionList> questions3 = new List<QuestionList>();
    [SerializeField] List<QuestionList> questions = new List<QuestionList>();
    List<List<QuestionList>> questionLists;

    QuestionList currentQuestion;
    [Header("Answer")]
    [SerializeField] GameObject[] answerButtons;
    bool hasAnswerEarly;

    bool stopSound = true;

    bool GameOver;

    [Header("Sprite")]
     
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite wrongAnswerSprite;
    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    void Awake()
    {   
        questionMark = GameObject.FindGameObjectWithTag("QuestionMark").GetComponent<Slider>();

        SFXMusic = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();

        questionLists = new List<List<QuestionList>>();

        questionLists.Add(questions2);

        questionLists.Add(questions3);

        questionLists.Add(questions4);

        int randomList = UnityEngine.Random.Range(0, questionLists.Count);

        questions = questionLists[randomList];

    }
    void Start()
    {   
        timer = FindObjectOfType<Timer>();
        GetNewQuestion();
        questionLists.Add(questions2);
        questionLists.Add(questions3);
        questionLists.Add(questions4);
    }
    void Update()

    {   
        
        
        timerImage.fillAmount = timer.fillFraction;
        if(GameOver && currentIndex < questions.Count){
        StartCoroutine(LoadSceneAfterDelay("GameOverMenu", 3f));
        GameOver = false; 
        }
        else if(currentIndex >= questions.Count){
        StartCoroutine(LoadSceneAfterDelay("GameFinishMenu", 3f));
        currentIndex = 0;
        }
        if(timer.loadnextQuestion){
            hasAnswerEarly = false;
            SetNewQuestion();
            timer.loadnextQuestion = false;
    }
        else if(!hasAnswerEarly && !timer.isAnsweringQuestion && stopSound){
            StartCoroutine(LoadSceneAfterDelay("GameOverMenu", 3f));
            
            DisplayAnswer(-1);
            ChangestateButton(false);
            stopSound = false;
        }
        
    }   
    public void OnAnswerSelected(int index){
        hasAnswerEarly = true;
        DisplayAnswer(index);
        ChangestateButton(false);
        timer.CancelTimer();
    }
    public void DisplayAnswer(int index){
        if(index == currentQuestion.GetCorrectAnswer()){
            SFXMusic.PlaySFX();
            currentIndex++;
            questionText.text = "Bạn đã trả lời đúng";
            Image imageButton = answerButtons[index].GetComponent<Image>();
            imageButton.sprite = correctAnswerSprite;
            imageButton.color = Color.green;
        }
        else if(index != currentQuestion.GetCorrectAnswer() && index != -1){
            SFXMusic.PlayWrongSFX();
            questionText.text = "Dễ thế này mà còn trả lời sai tôi chịu bạn đấy, đáp án đúng là: \n " + currentQuestion.GetAnswer(currentQuestion.GetCorrectAnswer());
            Image imageButton = answerButtons[currentQuestion.GetCorrectAnswer()].GetComponent<Image>();
            imageButton.sprite = correctAnswerSprite;
            imageButton.color = Color.green;
            Image wrongimageButton = answerButtons[index].GetComponent<Image>();
            wrongimageButton.sprite = wrongAnswerSprite;
            wrongimageButton.color = Color.red;
            GameOver = true;
        }
        else if(index == -1){
            SFXMusic.PlayWrongSFX();
            questionText.text = "Dễ thế này mà còn trả lời sai tôi chịu bạn đấy, đáp án đúng là: \n " + currentQuestion.GetAnswer(currentQuestion.GetCorrectAnswer());
            Image imageButton = answerButtons[currentQuestion.GetCorrectAnswer()].GetComponent<Image>();
            imageButton.sprite = correctAnswerSprite;
            imageButton.color = Color.green;
        }
    }
    IEnumerator LoadTextAfterDelay(int SCurrentIndex, float delay)
{
    yield return new WaitForSeconds(delay);
    QuesstionPassed.text = "Câu hỏi số " + (SCurrentIndex + 1);
    
}
    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
{
    yield return new WaitForSeconds(delay);  
    SceneManager.LoadScene(sceneName);
}       
    public void DisplayQuestion(){
        questionMark.value = currentIndex + 1;
        QuesstionPassed.text = "Câu hỏi số " + (currentIndex+1);
        questionText.text = currentQuestion.GetQuestion();
        for(int i = 0; i < answerButtons.Length; i ++){
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        
            buttonText.text = currentQuestion.GetAnswer(i);
    }
    }
    void ChangestateButton(bool state){
        for (int i = 0; i < answerButtons.Length; i++){
            Button stateButton = answerButtons[i].GetComponent<Button>();
            stateButton.interactable = state;
        }
    }
    void SetNewQuestion(){
        GetNewQuestion();
        SetDefaultButtonSprites();
        ChangestateButton(true);
        DisplayQuestion();
    }

    void GetNewQuestion(){
    currentQuestion = questions[currentIndex]; 
}



    void SetDefaultButtonSprites()
    {
        for(int i = 0; i < answerButtons.Length; i++){
            Image defaultImage = answerButtons[i].GetComponent<Image>();
            defaultImage.sprite = defaultAnswerSprite;
            defaultImage.color = Color.white        ;
        }
    }

}
