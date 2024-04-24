using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playaudio : MonoBehaviour
{
    [SerializeField] AudioSource Background;
    void Start()
    {
        Background.Play();
    }

    // Update is called once per frame

}
