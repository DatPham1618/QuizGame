using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource BackgroundMusic;
    [SerializeField] AudioSource SFXMusic;

    [Header("Audio Clip")]
    [SerializeField] AudioClip WrongAnswer;
    [SerializeField] AudioClip CorrectAnswer;
    [SerializeField] AudioClip Background;

    void Start(){
        BackgroundMusic.clip = Background;
        BackgroundMusic.Play();
    }
    public void PlaySFX(){
        SFXMusic.PlayOneShot(CorrectAnswer);
    }

    public void PlayWrongSFX(){
        SFXMusic.PlayOneShot(WrongAnswer);
    }

}
