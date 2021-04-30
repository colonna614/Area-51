using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSongSwitch : MonoBehaviour
{
    public AudioClip mainWaveTheme;
    public AudioClip boss1Song;

    public AudioSource audioSource;

    public static bool mainSongCheck = false;
    public static bool boss1SongCheck = false;
    void Start()
    {
        //audioSource = gameObject.GetComponent<AudioSource>();

        audioSource.clip = mainWaveTheme;
        audioSource.Play();
    }   

    void Update()
    {
        Debug.Log("boss 1 song check = "+boss1SongCheck);

        if (boss1SongCheck == true)
        {
            audioSource.clip = boss1Song;
            audioSource.loop = true;
            audioSource.Play();
            boss1SongCheck = false;
        }
        if (mainSongCheck == true)
        {
            audioSource.clip = mainWaveTheme;
            audioSource.loop = true;
            audioSource.Play();
            mainSongCheck = false;
        }
    }

    //public void ChangeTrack(AudioClip boss1Song)
    //{
     //   audioSource.Stop();
      //  audioSource.Clip = boss1Song;
       // audioSource.Play();
    //}
}
