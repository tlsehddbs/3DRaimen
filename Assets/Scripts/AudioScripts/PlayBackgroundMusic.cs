using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackgroundMusic : MonoBehaviour
{
    public AudioClip InTitle;
    public AudioClip InGame;
    public AudioClip InResult;
    AudioSource _baudioSource;

    bool playonce = false;


    void Start()
    {
        this._baudioSource = GetComponent<AudioSource>();
        _baudioSource.volume = 0.05f;
        _baudioSource.clip = InGame;
        _baudioSource.Play();
    }

    void Update()
    {
        if ((GameManager.state == GameManager.playerState.Finish || 
             GameManager.state == GameManager.playerState.Fail) && !playonce)
        {
            _baudioSource.clip = InResult;
            _baudioSource.Play();
            playonce = true;
        }
    }
}
