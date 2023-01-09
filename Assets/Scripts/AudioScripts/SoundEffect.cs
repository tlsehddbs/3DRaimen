using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioClip useItem;
    public AudioClip hitEffect;
    public AudioClip breakEffect;
    public AudioClip boomEffect;
    AudioSource _audioSource;

    //private bool broke70 = false;
    //private bool broke40 = false;

    private void Awake()
    {
        this._audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //if(GameManager.Hp < 70f && GameManager.Hp > 40f && !broke70)
        //{
        //    _audioSource.clip = breakEffect;
        //    _audioSource.volume = 1;
        //    _audioSource.Play();
        //    broke70 = true;
        //}
        //if(GameManager.Hp < 40f && !broke40)
        //{
        //    _audioSource.clip = breakEffect;
        //    _audioSource.volume = 1;
        //    _audioSource.Play();
        //    broke40 = true;
        //}
    }
}
