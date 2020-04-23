using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    [Header("배경음악")]
    public AudioClip[] bg;
    [Header("클릭")]
    public AudioClip[] click;
    [Header("공격")]
    public AudioClip[] attack;
    [Header("Hit")]
    public AudioClip[] hit;

}
