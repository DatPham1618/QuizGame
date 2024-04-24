using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverMenu : MonoBehaviour
{   
    Question Menu;
    public int NumberAnswered = 0;

    [SerializeField] TextMeshProUGUI Score;

    

    

    // void Start(){
    //     DisplayScore();
    // }
// public void DisplayScore(){
    
//    Score.text = "Bạn đã dừng lại ở câu số " + (NumberAnswered + 1);
// }


public void BacktoMenu(){
    // Menu.currentIndex = 0;
    SceneManager.LoadScene("Menu");
}
public void PlayAgain(){
    // Menu.currentIndex = 0;
    SceneManager.LoadScene("GamePlay");
}
}
