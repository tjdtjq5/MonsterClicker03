using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoundPlay : MonoBehaviour
{
    public AudioClip sound;

    public void Start()
    {
        this.GetComponent<AudioSource>().volume = 0;
        this.GetComponent<AudioSource>().clip = sound;
        this.GetComponent<AudioSource>().Play();
        this.GetComponent<AudioSource>().DOFade(1f, 6f);
    }
}
