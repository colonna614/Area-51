﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSongSwitch : MonoBehaviour
{
    public AudioClip mainWaveTheme;
    public AudioClip boss1Song;
    public AudioClip boss2Song;
    public AudioClip boss3Song;
    public AudioClip boss4Song;


    public AudioSource audioSource;

    public static bool mainSongCheck = false;
    public static bool boss1SongCheck = false;
    public static bool boss2SongCheck = false;
    public static bool boss3SongCheck = false;
    public static bool boss4SongCheck = false;

    void Start()
    {
        //audioSource = gameObject.GetComponent<AudioSource>();

        audioSource.clip = mainWaveTheme;
        audioSource.Play();
    }

    void Update()
    {
        //Debug.Log("boss 1 song check = " + boss1SongCheck);

        if (boss1SongCheck == true)
        {
            audioSource.clip = boss1Song;
            audioSource.loop = true;
            audioSource.Play();
            boss1SongCheck = false;
        }
        if (boss2SongCheck == true)
        {
            audioSource.clip = boss2Song;
            audioSource.loop = true;
            audioSource.Play();
            boss2SongCheck = false;
        }
        if (boss3SongCheck == true)
        {
            audioSource.clip = boss3Song;
            audioSource.loop = true;
            audioSource.Play();
            boss3SongCheck = false;
        }
        if (boss4SongCheck == true)
        {
            audioSource.clip = boss4Song;
            audioSource.loop = true;
            audioSource.Play();
            boss4SongCheck = false;
        }
        if (mainSongCheck == true)
        {
            audioSource.clip = mainWaveTheme;
            audioSource.loop = true;
            audioSource.Play();
            mainSongCheck = false;
        }
    }

}
